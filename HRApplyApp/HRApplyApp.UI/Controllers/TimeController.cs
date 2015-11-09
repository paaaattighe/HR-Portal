using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApplyApp.Models;
using HRApplyApp.Data;

namespace HRApplyApp.UI.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var repo = new EmployeeRepository();
                emp = repo.GetAll().FirstOrDefault(m => m.EmpID == emp.EmpID);
                return View("Clock", emp);
            }

            return View(emp);
        }

        [HttpPost]
        public ActionResult ClockIn(Employee emp)
        {
            var repo = new EmployeeRepository();
            var checkemp = repo.GetAll().FirstOrDefault(m => m.EmpID == emp.EmpID);

            if (checkemp != null && checkemp.IsClockedIn == 0)
            {
                repo.EmployeeClockIn(emp.EmpID);
                emp.ClockIn = DateTime.Now;
                return View("SuccessfulClockIn", emp);
            }
            return View("UnsuccessfulClockIn", emp);
        }

        [HttpPost]
        public ActionResult ClockOut(Employee emp)
        {
            var repo = new EmployeeRepository();
            var checkemp = repo.GetAll().FirstOrDefault(m => m.EmpID == emp.EmpID);

            if (checkemp != null && checkemp.IsClockedIn == 1)
            {
                repo.EmployeeClockOut(emp.EmpID);
                emp.ClockOut = DateTime.Now;
                emp.HoursWorked = emp.ClockOut - checkemp.ClockIn;
                return View("SuccessfulClockOut", emp);
            }
            return View("UnsuccessfulClockOut", emp);
        }
    }
}