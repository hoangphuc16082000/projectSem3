using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcelOnServices.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Department name cannot be blank")]
        [Display(Name="Department Name")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Phone number cannot be blank")]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Contact person cannot be blank")]
        [Display(Name = "Contact person")]
        public string ContactPerson { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}