using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcelOnServices.Models
{
    public class OrderService
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer cannot be blank.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Order date cannot be blank.")]
        [Display(Name = "Order date")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Description cannot be blank.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Order total cannot be blank.")]
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public float Total { get; set; }
        [Required(ErrorMessage = "Paid cannot be blank.")]
        [Display(Name = "Paid")]
        public float Paid { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Debt")]
        public float Debt { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public virtual ICollection<OrderServiceDetail> OrderServiceDetails { get; set; }
        public Customer Customer { get; set; }
    }
}