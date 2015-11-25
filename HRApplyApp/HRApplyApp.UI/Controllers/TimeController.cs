using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApplyApp.Models;
using HRApplyApp.Data;
using HRApplyApp.UI.Models;

namespace HRApplyApp.UI.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time
        public ActionResult Index()
        {
            var repo = new EmployeeRepository();
            var employeeList = repo.GetAll();
            var vm =  new TimeVM(employeeList);

            return View(vm);
        }

        public ActionResult TimeSheet()
        {
            return View();
        }
    }
}