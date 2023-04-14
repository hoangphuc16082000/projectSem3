using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExcelOnServices.Models
{
    public class ExcelOnServiceContext:DbContext
    {
        public ExcelOnServiceContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }

        public System.Data.Entity.DbSet<ExcelOnServices.Models.OrderServiceDetail> OrderServiceDetails { get; set; }
    }
}