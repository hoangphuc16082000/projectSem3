namespace ExcelOnServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bbb1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Fullname", c => c.String());
            AlterColumn("dbo.Employees", "Gender", c => c.String());
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Phone", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            DropColumn("dbo.Employees", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Note", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Fullname", c => c.String(nullable: false));
        }
    }
}
