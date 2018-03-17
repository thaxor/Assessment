using Assessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models.CaseViewModels
{
    public class CaseListViewModel
    {
        public List<Case> NeedReview { get; set; }
        public List<Case> NeedApproval { get; set; }
        public List<Case> Completed { get; set; }
    }
}
