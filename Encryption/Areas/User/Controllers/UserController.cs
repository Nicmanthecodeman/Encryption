using Encryption.Models;
using Encryption.Services;
using Encryption.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Encryption.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;        
        private ApplicationUser _currentUser;

        public UserController(IWebHostEnvironment webHostEnvironment,
                              UserResolverService userResolverService)
        {
            _webHostEnvironment = webHostEnvironment;            
            _currentUser = userResolverService.GetUserAsync().Result;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]        
        public async Task<ActionResult> GetProfilePicture()
        {            
            if (_currentUser.ProfilePicture == null)
            {
                byte[] defaultProfilePicture = await System.IO.File.ReadAllBytesAsync(GetDefaultProfilePicturePath());
                return new FileContentResult(defaultProfilePicture, SD.USER_DEFAULT_PROFILE_PICTURE_MIMETYPE);
            }

            return new FileContentResult(_currentUser.ProfilePicture, MediaTypeNames.Image.Jpeg);
        }

        private string GetDefaultProfilePicturePath()
        {
            return Path.Combine(_webHostEnvironment.WebRootPath, SD.USER_DEFAULT_PROFILE_PICTURE);
        }
    }
}
