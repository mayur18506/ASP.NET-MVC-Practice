using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _21.Data_Annotation.Models
{
    public class Employee
    {
        [DisplayName("ID")]
        [Required(ErrorMessage ="Id is mandatory")]
        public int EmployeeId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage ="Name is mandatory")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="Name should be in between 5 & 20")]
        public string EmployeeName { get; set; }

        [DisplayName("Age")]
        [Required(ErrorMessage = "Age is mandatory")]
        [Range(20,60)]
        public int? EmployeeAge { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is mandatory")]
        public string EmployeeGender { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is mandatory")]
        [RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$",ErrorMessage ="Invalid Email")]
        public string EmployeeEmail { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Employee Password is mandatory")]
        [RegularExpression(
        @"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^A-Za-z0-9]).{8,}$",
        ErrorMessage = "Password must contain 8+ characters, uppercase, lowercase, digit and special character."
    )]
        [DataType(DataType.Password)]
        public string EmployeeePassword { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Employee Confirm Password is mandatory")]
        [Compare("EmployeeePassword",ErrorMessage ="Password is not Identical")]
        [DataType(DataType.Password)]

        public string EmpConfirmPassword { get; set; }

        [DisplayName("Organization Name")]
        [ReadOnly(true)]
        public string EmpOrganizationName { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is mandatory")]
        [DataType(DataType.MultilineText)]

        public string EmpAddress { get; set; }

        [DisplayName("Joining Date")]
        [Required(ErrorMessage = "Date is mandatory")]
        [DataType(DataType.Date)]
        public string EmpJoiningDate { get; set; }

        [DisplayName("Joining Time")]
        [Required(ErrorMessage = "Time is mandatory")]
        [DataType(DataType.Time)]
        public string EmpJoiningTime { get; set; }
    }
}