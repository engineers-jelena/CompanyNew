namespace CompanyNew.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        NameOfEmployee = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nameOfCompany = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropIndex("dbo.Cars", new[] { "EmployeeId" });
            DropTable("dbo.Companies");
            DropTable("dbo.Employees");
            DropTable("dbo.Cars");
        }
    }
}
