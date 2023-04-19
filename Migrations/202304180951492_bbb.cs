namespace ExcelOnServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bbb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Note");
        }
    }
}
