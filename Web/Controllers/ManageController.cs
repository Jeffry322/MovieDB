/*using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public sealed class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ManageController> _logger;

        public ManageController(ILogger<ManageController> logger,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var imageBytes = user.ProfilePicture;

            var model = new IndexViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                ImagePreviewBase64 = $"data:image/pngbase64,{Convert.ToBase64String(imageBytes!)}"
            };

            return View(model);
        }
    }
}
*/