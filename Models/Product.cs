using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcelOnServices.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Product name cannot be blank.")]
        [Display(Name ="Product name")]
        public string ProdName { get; set; }
        [Required(ErrorMessage = "Product description cannot be blank.")]
        [Display(Name = "Product description")]
        public string ProdDesc { get; set; }
        [Required(ErrorMessage = "Description image cannot be blank.")]
        [Display(Name = "Description image")]
        public string DescImg { get; set; }
        [Required(ErrorMessage = "Customer cannot be blank.")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}