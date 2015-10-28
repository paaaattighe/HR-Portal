using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApplyApp.Models
{
    public class PolicyCategory
    {
        public string PolicyCategoryName { get; set; }
        public List<Policy> PolicyList { get; set; } 
    }
}
