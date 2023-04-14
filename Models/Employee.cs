using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcelOnServices.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee name cannot be blank")]
        [Display(Name = "Employee name")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Gender cannot be blank")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email cannot be blank")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage="Phone number cannot be blank")]
        [Display(Name="Phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address cannot be blank")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Department cannot be blank")]
        [Display(Name = "Department")]

        public virtual ICollection<OrderService> OrderServices { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}