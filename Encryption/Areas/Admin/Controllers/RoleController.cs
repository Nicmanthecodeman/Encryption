using Encryption.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encryption.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMINISTRATOR)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(string id)
        {
            IdentityRole role = new();

            if (string.IsNullOrEmpty(id))
            {
                return View(role);
            }

            role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(IdentityRole role)
        {
            IdentityRole identityRole = await _roleManager.FindByIdAsync(role.Id);

            if (identityRole != null)
            {
                identityRole.Name = role.Name;
                await _roleManager.UpdateAsync(identityRole);
            }
            else
            {
                await _roleManager.CreateAsync(role);
            }

            return RedirectToAction(nameof(Index));
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<IdentityRole> roles = await _roleManager.Roles
                                                         .ToListAsync();

            return Json(new { data = roles });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole roleToDelete = await _roleManager.FindByIdAsync(id);

            if (roleToDelete == null)
            {
                return Json(new { success = false, message = "Operation Failed! Role not found." });
            }

            await _roleManager.DeleteAsync(roleToDelete);

            return Json(new { success = true, message = "Operation Successful!" });
        }

        #endregion
    }
}
