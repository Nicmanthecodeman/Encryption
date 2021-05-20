using Encryption.DataAccess.Repository.IRepository;
using Encryption.Models;
using Encryption.Models.ViewModels;
using Encryption.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encryption.Areas.User.Controllers
{
    [Area("User")]
    public class EncryptController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private ApplicationUser _currentUser;

        public EncryptController(IUnitOfWork unitOfWork,
            UserResolverService userResolverService,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _currentUser = userResolverService.GetUserAsync()
                .Result;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult Encrypt()
        {
            EncryptionVM encryptionVM = new();

            return View(encryptionVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Encrypt(EncryptionVM encryptionVM)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = _passwordHasher.HashPassword(null, encryptionVM.Password);

                List<Attachment> attachments = await _unitOfWork.Attachment
                    .ProjectFilesToAttachmentList(
                        files: encryptionVM.FormFiles,
                        password: hashedPassword,
                        user: _currentUser);

                await _unitOfWork.Attachment
                    .AddRangeAsync(attachments);
                await _unitOfWork.SaveAsync();                
            }

            return View(encryptionVM);
        }
    }
}
