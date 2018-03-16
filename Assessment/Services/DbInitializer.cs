using Assessment.Data;
using Assessment.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Services
{
    public static class DbInitializer
    {
        private const string _password = "Test123$";

        private const string _adminEmail = "lukehansen+admin@gmail.com";
        private const string _adminUserName = "Admin";
        private const string _adminRole = "Admin";

        private const string _workerEmail = "lukehansen+worker@gmail.com";
        private const string _workerUserName = "Worker";
        private const string _workerRole = "Worker";

        private const string _reviewerEmail = "lukehansen+reviewer@gmail.com";
        private const string _reviewerUserName = "Reviewer";
        private const string _reviewerRole = "Reviewer";

        private const string _approverEmail = "lukehansen+approver@gmail.com";
        private const string _approverUserName = "Approver";
        private const string _approverRole = "Approver";

        public static async Task Initialize(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            await CreateRoles(roleManager);
            await CreateUsers(userManager);

            await AddUserToRole(userManager, _adminEmail, _adminRole);
            await AddUserToRole(userManager, _workerEmail, _workerRole);
            await AddUserToRole(userManager, _reviewerEmail, _reviewerRole);
            await AddUserToRole(userManager, _approverEmail, _approverRole);

        }

        private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            await CreateRole(roleManager, _adminRole);
            await CreateRole(roleManager, _workerRole);
            await CreateRole(roleManager, _reviewerRole);
            await CreateRole(roleManager, _approverRole);
        }
  
        private static async Task CreateUsers(UserManager<ApplicationUser> userManager)
        {
            await CreateUser(userManager, _adminUserName, _adminEmail, _password);
            await CreateUser(userManager, _workerUserName, _workerEmail, _password);
            await CreateUser(userManager, _reviewerUserName, _reviewerEmail, _password);
            await CreateUser(userManager, _approverUserName, _approverEmail, _password);
        }

        private static async Task CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var ir = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
        
        private static async Task CreateUser(UserManager<ApplicationUser> userManager, string userName, string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if(user == null)
            {
                var newUser = new ApplicationUser
                {
                    UserName = userName,
                    Email = email
                };

                var userResult = await userManager.CreateAsync(newUser, password);
            }
        }
        private static async Task AddUserToRole(UserManager<ApplicationUser> userManager, string email, string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            var userIsInRole = await userManager.IsInRoleAsync(user, role);

            if (user != null && !userIsInRole)
            {
                var result1 = await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
