using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApplyApp.Models
{
    public class TimeRecord
    {
        public int EmpID { get; set; }
        public DateTime DateWorked { get; set; }
        public decimal HoursWorked { get; set; }
    }
}
