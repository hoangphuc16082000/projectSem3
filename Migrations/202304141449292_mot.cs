namespace ExcelOnServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        ContactPerson = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        ContactPerson = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.OrderServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Total = c.Single(nullable: false),
                        Paid = c.Single(nullable: false),
                        Debt = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderServiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderServiceId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderServices", t => t.OrderServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.OrderServiceId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdName = c.String(nullable: false),
                        ProdDesc = c.String(nullable: false),
                        DescImg = c.String(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderServiceDetails", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.OrderServiceDetails", "OrderServiceId", "dbo.OrderServices");
            DropForeignKey("dbo.OrderServices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Products", new[] { "CustomerId" });
            DropIndex("dbo.OrderServiceDetails", new[] { "ServiceId" });
            DropIndex("dbo.OrderServiceDetails", new[] { "OrderServiceId" });
            DropIndex("dbo.OrderServices", new[] { "CustomerId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropTable("dbo.Products");
            DropTable("dbo.Services");
            DropTable("dbo.OrderServiceDetails");
            DropTable("dbo.OrderServices");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Customers");
        }
    }
}
