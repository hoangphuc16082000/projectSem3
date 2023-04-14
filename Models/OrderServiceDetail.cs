using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelOnServices.Models
{
    public class OrderServiceDetail
    {
        public int Id { get; set; }
        public int OrderServiceId { get; set; }
        public int ServiceId { get; set; }
        public float Price { get; set; }
        public Service Service { get; set; }
        public OrderService OrderService { get; set; }
    }
}