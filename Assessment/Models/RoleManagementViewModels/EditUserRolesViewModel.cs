using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models.RoleManagementViewModels
{
    public class EditUserRolesViewModel
    {
        public ApplicationUser User { get; set; }
        public List<string> UserRoles { get; set; }
        public List<string> ApplicationRoles { get; set; }
    }
}
