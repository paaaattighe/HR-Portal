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

        [HttpPost]
        public ActionResult SubmitTime(TimeRecord record)
        {
            var repo = new EmployeeRepository();
            repo.AddTimeRecordToDB(record);

            return RedirectToAction("TimeSheet");
        }

        public ActionResult TimeSheet()
        {
            var repo = new EmployeeRepository();
            var timeRecords = repo.GetTimeRecords();
            var employeeList = repo.GetAll();
            foreach (var employee in employeeList)
            {
                employee.TimeRecords = new List<TimeRecord>();

                foreach (var timeRecord in timeRecords.Where(timeRecord => timeRecord.EmpID == employee.EmpID))
                {
                    employee.TimeRecords.Add(timeRecord);
                    employee.TimeRecords = employee.TimeRecords.OrderBy(s=>s.DateWorked).ToList();
                }
            }

            return View(employeeList);
        }
    }
}