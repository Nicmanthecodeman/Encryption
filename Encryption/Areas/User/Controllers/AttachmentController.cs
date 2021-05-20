using Encryption.DataAccess.Repository.IRepository;
using Encryption.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encryption.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class AttachmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public AttachmentController(
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {            
            IEnumerable<Attachment> attachments = await _unitOfWork.Attachment
                .GetAllAsync(filter: attachment => attachment.ApplicationUserId == _userManager.GetUserId(User));

            return Json(new { data = attachments });
        }

        [HttpGet]
        public async Task<IActionResult> Download(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Download Failed" });
            }

            Attachment attachment = await _unitOfWork.Attachment
                .GetAsync(id.GetValueOrDefault());

            if (attachment == null)
            {
                return Json(new { success = false, message = "Download Failed" });
            }

            return File(attachment.Content, attachment.MimeType, attachment.FileName);

        }

        #endregion
    }
}
