using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApplyApp.Models;
using HRApplyApp.Data;

namespace HRApplyApp.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Resume newResume)
        {
            newResume.DateofApplication = DateTime.Now;
            var repo = new ResumeRepository();
            repo.RootPath = Server.MapPath("~/");
            repo.Add(newResume);
            

            if (ModelState.IsValid)
            {
                return View("Result", newResume);
            }

            return View();
        }


        public ActionResult Result2()
        {
            return View("Result2");
        }

        public ActionResult Admin()
        {
            var repo = new ResumeRepository();
            repo.RootPath = Server.MapPath("~/");
            var resumes = repo.GetAll();

            return View(resumes);
        }
    }
}