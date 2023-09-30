using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Identity.Pages.Account
{
    public sealed class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public required InputModel Input { get; set; }

        public string? ReturnUrl { get; set; }

        public RegisterModel(ILogger<RegisterModel> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public sealed class InputModel
        {
            [Required]
            [Display(Name = "User Name")]
            [StringLength(64, ErrorMessage = "User name must be at least 6 characters long and at max 64 characters long", MinimumLength = 6)]
            public string? UserName { get; set; }

            [Display(Name = "Profile Picture")]
            public IFormFile? ProfilePicture { get; set; }
            public string ImagePreviewBase64 { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Password must be at least 6 characters long and at max 100 characters long", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string? Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }
        }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input?.UserName, Email = Input?.Email };

                await PictureHandler(user);

                var result = await _userManager.CreateAsync(user, Input?.Password!);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private async Task PictureHandler(ApplicationUser user)
        {
            if (Input?.ProfilePicture != null)
            {
                using var memoryStream = new MemoryStream();
                await Input.ProfilePicture.CopyToAsync(memoryStream);

                var imageBytes = memoryStream.ToArray();
                Input.ImagePreviewBase64 = $"data:image/png;base64,{Convert.ToBase64String(imageBytes)}";

                if (memoryStream.Length < 2097152)
                {
                    user.ProfilePicture = imageBytes;
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
            else
            {
                user.ProfilePicture = GetDefaultProfilePicture();
            }
        }

        private byte[] GetDefaultProfilePicture()
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "default-profile-picture.png");
            return System.IO.File.ReadAllBytes(imagePath);
        }
    }
}
