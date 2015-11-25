using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApplyApp.Models;

namespace HRApplyApp.UI.Models
{
    public class TimeVM
    {
        public List<SelectListItem> Employees { get; set; }
        public decimal HoursWorked { get; set; }
        [DataType(DataType.Date)]
        public DateTime DayWorked { get; set; }

        public TimeVM(List<Employee> employees)
        {
            Employees = new List<SelectListItem>();

            foreach (var emp in employees)
            {
                var se = new SelectListItem();

                se.Text = emp.LastName + ", " + emp.FirstName;
                se.Value = emp.EmpID.ToString();

                Employees.Add(se);
            }
        }
    }
}