namespace volksoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Salaries_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SalaryDate = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LOP = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true);
            
            DropTable("dbo.States");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.SalaryModels");
        }
    }
}
