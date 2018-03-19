using Assessment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<UserCaseLoad> UserCaseLoadReport { get; set; }
        public IEnumerable<CaseStatePercentage> CaseStatePercentageReport { get; set; }
    }
}
