using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Utils
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public SeedData(ApplicationDbContext context , RoleManager<IdentityRole> roleManager , UserManager<ApplicationUser> userManager ) 
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task DataSeedingAsync()
        {
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
               await context.Database.MigrateAsync();
            }
            if (! await context.Categories.AnyAsync())
            {
               await context.Categories.AddRangeAsync(
                    new Category { Name = "Clothes" },
                    new Category { Name = "Mobiles" }
                    );
            }
            if (! await context.Brands.AnyAsync())
            {
               await context.Brands.AddRangeAsync(
                    new Brand { Name = "Samsung"},
                    new Brand { Name = "Apple"},
                    new Brand { Name="Nike"}
                    );
            }
            await context.SaveChangesAsync();
        }

        public async Task IdentityDataSeedingAsync()
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }
            if (!await userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                    Email = "Yazan@gmail.com",
                    FullName = "Yazan Sabri",
                    PhoneNumber = "1234567890",
                    UserName="ySabri"
                };
                var user2 = new ApplicationUser()
                {
                    Email = "yamen@gmail.com",
                    FullName = "yamen Sabri",
                    PhoneNumber = "05554122654",
                    UserName = "yySabri"
                };
                var user3 = new ApplicationUser()
                {
                    Email = "basheer@gmail.com",
                    FullName = "Basheer Dawoud",
                    PhoneNumber = "142579658",
                    UserName = "Bdawoud"
                };
                await userManager.CreateAsync(user1,"Pass@1212");
                await userManager.CreateAsync(user2,"Pass@1313");
                await userManager.CreateAsync(user3,"Pass@1414");

                await userManager.AddToRoleAsync(user1, "Admin");
                await userManager.AddToRoleAsync(user2, "SuperAdmin");
                await userManager.AddToRoleAsync(user3, "Customer");

            }
            await context.SaveChangesAsync();
        }
    }
}
