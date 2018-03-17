using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using Assessment.Models.RoleManagementViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assessment.Controllers
{
    public class RoleManagementController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public RoleManagementController(
            RoleManager<IdentityRole> roleManager,
          UserManager<ApplicationUser> userManager,
          ILogger<ManageController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();

            return View(users);
        }

        [HttpGet]
        public async Task<ActionResult> EditUserRoles([FromQuery] string userId)
        {
            //find the user
            var user = _userManager.Users.First(u => u.Id.Equals(userId));
            
            //get their roles
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserRolesViewModel();
            model.User = user;
            model.UserRoles = userRoles.ToList();
            //list of all roles available in the application
            model.ApplicationRoles = _roleManager.Roles.ToList().Select(x => x.Name).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditUserRoles([FromForm] EditUserRolesViewModel model)
        {
            //find the user
            var user = _userManager.Users.First(u => u.Id.Equals(model.User.Id));

            //add/remove roles from user as appropriate
            foreach (var appRole in model.ApplicationRoles)
            {
                if(model.UserRoles != null && model.UserRoles.Contains(appRole))
                {
                    await _userManager.AddToRoleAsync(user, appRole);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, appRole);
                }
            }

            //get list of roles back from server
            //could use model, fetching from server just in-case it didn't succeed for some reason
            var userRoles = await _userManager.GetRolesAsync(user);

            model.UserRoles = userRoles.ToList();

            return View(model);
        }

    }
}