﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApplyApp.Models;
using HRApplyApp.Data;
using HRApplyApp.UI.Models;

namespace HRApplyApp.UI.Controllers
{
    public class PoliciesController : Controller
    {
        // GET: Policies
        public ActionResult Index()
        {
            var repo = new PolicyRepository();
            repo.RootPath = Server.MapPath("~/");
            var pvm = new PoliciesByCategoryVM();
            pvm.AllPolicies = repo.GetAll();
            pvm.Polcatlist = repo.GetAllPolicyCategories();

            return View("Index", pvm);
        }

        [HttpPost]
        public ActionResult AddPolicy()
        {
            var p = new Policy();

            p.PolicyName = Request.Form["Name"];
            p.PolicyDescription = Request.Form["Description"];
            p.Category = Request.Form["Category"];

            var repo = new PolicyRepository();
            repo.RootPath = Server.MapPath("~/");
            repo.Add(p);

            return RedirectToAction("Manage");
        }

        public ActionResult Manage()
        {
            var repo = new PolicyRepository();
            repo.RootPath = Server.MapPath("~/");
            var policies = repo.GetAll();
            return View(policies);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var repo = new PolicyRepository();
            repo.RootPath = Server.MapPath("~/");
            var policy = repo.GetPolicyById(id);

            repo.Delete(policy.PolicyID);

            return RedirectToAction("Manage");
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var repo = new PolicyRepository();
            repo.RootPath = Server.MapPath("~/");
            var pol = repo.GetPolicyById(id);
            return View(pol);
        }

        [HttpPost]
        public ActionResult EditPolicy(int id)
        {
            Policy policy = new Policy();
            policy.PolicyID = int.Parse(Request.Form["id"]);
            policy.PolicyName = Request.Form["Name"];
            policy.PolicyDescription = Request.Form["Description"];
            policy.Category = Request.Form["Category"];

            var repo = new PolicyRepository();
            repo.RootPath = Server.MapPath("~/");
            repo.Edit(policy);

            return RedirectToAction("Manage");
        }

        [HttpPost]
        public ActionResult PoliciesByCategory(PoliciesByCategoryVM pvm)
        {
            var repo = new PolicyRepository {RootPath = Server.MapPath("~/")};
            pvm.Policies = repo.GetAll().Where(p=>p.Category == pvm.Category).ToList();

            return View(pvm);
        }

        public ActionResult ManageCategory(PoliciesByCategoryVM pvm)
        {
            var repo = new PolicyRepository { RootPath = Server.MapPath("~/") };
            pvm.Polcatlist = repo.GetAllPolicyCategories();

            return View(pvm);
        }
    }
}