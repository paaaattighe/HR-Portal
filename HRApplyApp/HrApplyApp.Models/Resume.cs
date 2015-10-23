using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApplyApp.Models
{
    public class Resume
    {
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string SkypeName { get; set; }
        public string Education { get; set; }
        public string Salary { get; set; }
        public string WorkHistory { get; set; }
        public string Position { get; set; }
        public DateTime DateofApplication { get; set; }
    }
}
