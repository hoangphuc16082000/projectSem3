using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcelOnServices.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required()]
        public string Fullname { get; set; }
        [Required()]
        public string Phone { get; set; }
        [Required()]
        public string Email { get; set; }
        [Required()]
        public string Address { get; set; }
        [Required()]
        public string Website { get; set; }
        [Required()]
        public string ContactPerson { get; set; }
    }
}