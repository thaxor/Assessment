using Assessment.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment.Data
{
    public class Case
    {
        public int CaseId { get; set; }
        public string Message { get; set; }

        [ForeignKey("WorkerForeignKey")]
        public virtual ApplicationUser Worker { get; set; }

        [ForeignKey("ReviewerForeignKey")]
        public virtual ApplicationUser Reviewer { get; set; }

        [ForeignKey("ApproverForeignKey")]
        public virtual ApplicationUser Approver { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
