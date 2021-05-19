using Encryption.Enums;
using Encryption.Models;
using Encryption.Utility;
using Microsoft.AspNetCore.Identity;

namespace Encryption.DataAccess
{
    public static class ApplicationDBInitializer
    {
        public static void Seed(UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedAdministrator(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (ERoles role in EnumUtil.GetValues<ERoles>())
            {
                if (roleManager.FindByNameAsync(role.ToString()).Result == null)
                {
                    roleManager.CreateAsync(new IdentityRole(role.ToString())).Wait();
                }
            }
        }

        public static void SeedAdministrator(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync(SD.ADMIN_USERNAME).Result == null)
            {
                ApplicationUser administrator = new()
                {
                    UserName = SD.ADMIN_USERNAME,
                    FirstName = SD.ADMIN_FIRST_NAME,
                    LastName = SD.ADMIN_LAST_NAME,
                    Email = SD.ADMIN_EMAIL,
                    LockoutEnabled = SD.ADMIN_IS_LOCKED_OUT_ENABLED,                    
                    EmailConfirmed = SD.ADMIN_IS_EMAIL_CONFIRMED,
                    PhoneNumber = SD.ADMIN_PHONE_NUMBER,
                    PhoneNumberConfirmed = SD.ADMIN_IS_PHONE_NUMBER_CONFIRMED,
                };

                IdentityResult result = userManager.CreateAsync(administrator, SD.ADMIN_PASSWORD).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(administrator, SD.ROLE_ADMINISTRATOR).Wait();
                }
            }
        }
    }
}
