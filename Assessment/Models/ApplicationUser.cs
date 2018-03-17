using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Data;
using Microsoft.AspNetCore.Identity;

namespace Assessment.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [InverseProperty("Worker")]
        public virtual ICollection<Case> WorkerCases { get; set; }

        [InverseProperty("Reviewer")]
        public virtual ICollection<Case> ReviewerCases { get; set; }

        [InverseProperty("Approver")]
        public virtual ICollection<Case> ApproverCases { get; set; }
    }
}
