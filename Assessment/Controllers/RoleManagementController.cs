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

        
        public async Task<ActionResult> EditUserRoles([FromQuery] string userId)
        {
            var user = _userManager.Users.First(u => u.Id.Equals(userId));
            
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserRolesViewModel();

            model.User = user;
            model.UserRoles = userRoles.ToList();
            model.ApplicationRoles = _roleManager.Roles.ToList().Select(x => x.Name).ToList();

            return View(model);
        }

    }
}