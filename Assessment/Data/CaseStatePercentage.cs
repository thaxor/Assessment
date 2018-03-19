using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Data
{
    public class CaseStatePercentage
    {
        public string UserName { get; set; }
        public float PercentUserCasesReviewed { get; set; }
        public float PercentUserCasesApproved { get; set; }
        public float PercentUserTotalCasesReviewed { get; set; }
        public float PercentUserTotalCasesApproved { get; set; }
    }
}
