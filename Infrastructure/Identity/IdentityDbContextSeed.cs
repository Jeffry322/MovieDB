using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public sealed class IdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Constants.ADMIN_ROLE));

            var deffaultUser = new ApplicationUser
            {
                UserName = "Sashka",
                Email = "sashka@mail.com",
                ProfilePicture = await File.ReadAllBytesAsync("wwwroot/images/default-profile-picture.png")
            };

            await userManager.CreateAsync(deffaultUser, AuthorizationConstants.Constants.DEFAULT_PASSWORD);

            var adminUsername = "Admin";
            var adminUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@mail.com",
                ProfilePicture = await File.ReadAllBytesAsync("wwwroot/images/default-profile-picture.png")
            };

            await userManager.CreateAsync(adminUser, AuthorizationConstants.Constants.DEFAULT_PASSWORD);
            adminUser = await userManager.FindByEmailAsync(adminUsername);
            if (adminUser != null)
            {
                await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Constants.ADMIN_ROLE);
            }
        }
    }
}
