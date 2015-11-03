using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApplyApp.Models;

namespace HRApplyApp.UI.Models
{
    public class PoliciesByCategoryVM
    {

        public List<Policy> Policies { get; set; }
        public List<Policy> AllPolicies { get; set; } 
        public PolicyCategory Category { get; set; }
        public List<PolicyCategory> Polcatlist { get; set; }

        public List<Policy> CreatePolicyList(PolicyCategory polcat, List<Policy> pollist)
        {
            var pols = new List<Policy>();
            pols = pollist.Where(p => p.Category == polcat.PolicyCategoryName).ToList();
            return pols;
        }
    }
}
