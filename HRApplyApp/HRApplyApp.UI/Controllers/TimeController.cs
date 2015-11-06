using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRApplyApp.Data;

namespace HRApplyApp.UI.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time
        public ActionResult Index()
        {
            var repo = new EmployeeRepository();
            var employees = repo.GetAll();
            return View(employees);
        }
    }
}