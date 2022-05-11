namespace CarWorld.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CarWorld.Common;
    using CarWorld.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class RolesSeeder : ISeeder
    {      
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);

            var user = new ApplicationUser()
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                ImagePath = GlobalConstants.DefaultUserImagePath,
            };

            if (dbContext.Users.Any())
            {
                return;
            }

            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user, "123456");
            user.PasswordHash = hashed;
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await userManager.CreateAsync(user);
            await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);

            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
