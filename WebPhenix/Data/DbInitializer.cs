using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebPhenix.Data
{
    public static class DbInitializer
    {
        private const string SUADMIN = "SUAdministrator";
        private const string ADMIN = "Administrator";
        private const string HRMANAGER = "HRManager";

        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var exist = false;
            exist = await roleManager.RoleExistsAsync(SUADMIN);
            if (!exist) await roleManager.CreateAsync(new AppRole(SUADMIN));
            exist = await roleManager.RoleExistsAsync(ADMIN);
            if (!exist) await roleManager.CreateAsync(new AppRole(ADMIN));
            exist = await roleManager.RoleExistsAsync(HRMANAGER);
            if (!exist) await roleManager.CreateAsync(new AppRole(HRMANAGER));

            var user = await userManager.FindByEmailAsync("jstix.bogdan.kandela@gmail.com");
            if (user == null)
            {
                var newUser = new AppUser
                {
                    UserName = "jstix.bogdan.kandela@gmail.com",
                    Email = "jstix.bogdan.kandela@gmail.com",
                    FirstName = "Bogdan",
                    LastName = "Kandela",
                };
                var result = await userManager.CreateAsync(newUser,"Qwerty123456!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newUser, SUADMIN);
                }

            }
        }
    }
}
