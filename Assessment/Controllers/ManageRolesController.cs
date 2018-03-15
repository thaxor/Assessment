using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class ManageRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageRolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Implement each of the following features:
        //Role management for the following roles:
        //Worker
            //Write access
            //Create new cases
        //Reviewer
            //Read access
            //Review cases
        //Approver
            //Read access
            //Approve cases


        #region Custom
        public async Task createRolesandUsers()
        {
            var x = false;

            if (false)
            {
                bool adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
                if (!adminRoleExists)
                {

                    //create the admin role if it's not there
                    //faster than writing the sql
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    await _roleManager.CreateAsync(role);

                    var user = new ApplicationUser();
                    user.UserName = "admin";
                    user.Email = "luke.hansen+admin@gmail.com";

                    string userPWD = "mzxe!23Test";

                    var chkUser = await _userManager.CreateAsync(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Succeeded)
                    {
                        var result1 = await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }

                // creating Creating Manager role     
                bool workerRoleExists = await _roleManager.RoleExistsAsync("Worker");
                if (!workerRoleExists)
                {
                    var role = new IdentityRole();
                    role.Name = "Worker";
                    await _roleManager.CreateAsync(role);

                    //refactor into function
                    var user = new ApplicationUser();
                    user.UserName = "admin";
                    user.Email = "luke.hansen+admin@gmail.com";

                    string userPWD = "mzxe!23Test";

                    var chkUser = await _userManager.CreateAsync(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Succeeded)
                    {
                        var result1 = await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }

                bool reviewerRoleExists = await _roleManager.RoleExistsAsync("Reviewer");
                if (!reviewerRoleExists)
                {
                    var role = new IdentityRole();
                    role.Name = "Reviewer";
                    await _roleManager.CreateAsync(role);

                    var user = new ApplicationUser();
                    user.UserName = "Reviewer";
                    user.Email = "luke.hansen+reviewer@gmail.com";

                    string userPWD = "mzxe!23Test";

                    var chkUser = await _userManager.CreateAsync(user, userPWD);

                    if (chkUser.Succeeded)
                    {
                        var result1 = await _userManager.AddToRoleAsync(user, "Reviewer");
                    }
                }

                bool approverRoleExists = await _roleManager.RoleExistsAsync("Approver");
                if (!approverRoleExists)
                {
                    var role = new IdentityRole();
                    role.Name = "Approver";
                    await _roleManager.CreateAsync(role);

                    var user = new ApplicationUser();
                    user.UserName = "Approver";
                    user.Email = "luke.hansen+approver@gmail.com";

                    string userPWD = "mzxe!23Test";

                    var chkUser = await _userManager.CreateAsync(user, userPWD);

                    if (chkUser.Succeeded)
                    {
                        var result1 = await _userManager.AddToRoleAsync(user, "Approver");
                    }
                }
            }
            
        }
        #endregion
    }
}