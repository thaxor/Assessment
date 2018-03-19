using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Data
{
    public class UserCaseLoad
    {
        public string UserName { get; set; }
        public int WorkerCases { get; set; }
        public int ReviewedCases { get; set; }
        public int ApprovedCases { get; set; }
    }
}
