using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcelOnServices.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Service name cannot be blank")]
        [Display(Name = "Service name")]
        public string ServiceName { get; set; }
        [Required(ErrorMessage = "Price cannot be blank")]
        [Display(Name = "Price")]
        public double Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderServiceDetail> OrderServiceDetails { get; set; }
    }
}