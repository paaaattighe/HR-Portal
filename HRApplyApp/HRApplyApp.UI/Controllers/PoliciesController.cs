using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApplyApp.Models;
using HRApplyApp.Data;

namespace HRApplyApp.UI.Controllers
{
    public class PoliciesController : Controller
    {
        // GET: Policies
        public ActionResult Index()
        {
            var repo = new PolicyRepository();
            repo.RootPath = Server.MapPath("~/");
            var policylist = repo.GetAll();
            var categories = repo.GetPoliciesByCategory(policylist);

            return View("Index", categories);
        }

        //[HttpPost]
        //public ActionResult AddPolicy(Policy newPolicy)
        //{
        //    var repo = new PolicyRepository();
        //    repo.RootPath = Server.MapPath("~/");
        //    repo.Add(newPolicy);
        //    return View("Index", newPolicy);
        //}

        //public ActionResult Delete()
        //{
        //    var repo = new PolicyRepository();
        //    repo.RootPath = Server.MapPath("~/");

        //    repo.Delete();
        //}
    }
}