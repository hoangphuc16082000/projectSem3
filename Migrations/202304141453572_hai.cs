namespace ExcelOnServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderServices", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderServices", "EmployeeId");
            AddForeignKey("dbo.OrderServices", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderServices", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.OrderServices", new[] { "EmployeeId" });
            DropColumn("dbo.OrderServices", "EmployeeId");
        }
    }
}
