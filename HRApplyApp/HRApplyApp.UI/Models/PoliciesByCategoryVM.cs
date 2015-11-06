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
        public string Category { get; set; }
        public List<PolicyCategory> Polcatlist { get; set; }
        public List<SelectListItem> SelectCategories { get; set; }

        public List<Policy> CreatePolicyList(string cat)
        {
            List<Policy> pollist = new List<Policy>();
            pollist = pollist.Where(p => p.Category == cat).ToList();
            return pollist;
        }

        public List<SelectListItem> CreateCategorySelectList(string cat)
        {
            List<PolicyCategory> polcatlist = new List<PolicyCategory>();
            polcatlist = polcatlist.Where(p => p.PolicyCategoryName == cat).ToList();
            List<SelectListItem> polcatsellist = new List<SelectListItem>();
            foreach (var p in polcatlist)
            {
                var newItem = new SelectListItem();
                newItem.Text = p.PolicyCategoryName;

                polcatsellist.Add(newItem);
            }
            return polcatsellist;

        }
    }
}
