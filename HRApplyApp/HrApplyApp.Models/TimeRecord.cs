using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApplyApp.Models
{
    public class TimeRecord
    {
        [Required]
        public int EmpID { get; set; }
        [Required]
        public DateTime DateWorked { get; set; }
        [Required]
        public decimal HoursWorked { get; set; }
    }
}
