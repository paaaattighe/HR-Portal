using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HrApplyApp.Models
{
    public class Resume //: IValidatableObject
    {
        
        public int ApplicantId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string  LastName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ConfirmEmail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        
        public string SkypeName { get; set; }
        [Required]
        public string Education { get; set; }
        
        public string Salary { get; set; }
        [Required]
        public string WorkHistory { get; set; }
        
        public string Position { get; set; }

        public DateTime DateofApplication { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("Please enter your first name...", new[] { "FirstName" }));
            }
            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Please enter your last name...", new[] { "LastName" }));
            }
            if (string.IsNullOrEmpty(StreetAddress))
            {
                errors.Add(new ValidationResult("Please enter your street address...", new[] { "StreetAddress" }));
            }
            if (string.IsNullOrEmpty(City))
            {
                errors.Add(new ValidationResult("Please enter your city...", new[] { "City" }));
            }
            if (string.IsNullOrEmpty(State))
            {
                errors.Add(new ValidationResult("Please enter your state...", new[] { "State" }));
            }
            if (string.IsNullOrEmpty(Country))
            {
                errors.Add(new ValidationResult("Please enter your country...", new[] { "Country" }));
            }
            if (string.IsNullOrEmpty(Zipcode))
            {
                errors.Add(new ValidationResult("Please enter your zipcode...", new[] { "Zipcode" }));
            }
            if (string.IsNullOrEmpty(Email))
            {
                errors.Add(new ValidationResult("Please enter your email address...", new[] { "Email" }));
            }
            if (string.IsNullOrEmpty(ConfirmEmail))
            {
                errors.Add(new ValidationResult("Please confirm your email address...", new[] { "ConfirmEmail" }));
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                errors.Add(new ValidationResult("Please enter your phone number...", new[] { "PhoneNumber" }));
            }
            if (string.IsNullOrEmpty(SkypeName))
            {
                errors.Add(new ValidationResult("Please enter your skype name...", new[] { "SkypeName" }));
            }
            if (string.IsNullOrEmpty(Education))
            {
                errors.Add(new ValidationResult("Please enter your education...", new[] { "Education" }));
            }
            if (string.IsNullOrEmpty(Salary))
            {
                errors.Add(new ValidationResult("Please enter your desired starting salary...", new[] { "Salary" }));
            }
            if (string.IsNullOrEmpty(WorkHistory))
            {
                errors.Add(new ValidationResult("Please enter your Work History...", new[] { "WorkHistory" }));
            }
            if (string.IsNullOrEmpty(Position))
            {
                errors.Add(new ValidationResult("Please enter your first postion...", new[] { "Position" }));
            }
            if (Email != ConfirmEmail)
            {
                errors.Add(new ValidationResult("Your email needs confirming...", new[] { "ConfirmEmail" }));
            }

            return errors;
        }
    }
}
