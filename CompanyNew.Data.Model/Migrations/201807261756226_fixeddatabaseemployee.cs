namespace CompanyNew.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixeddatabaseemployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DateDeleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "DateDeleted", c => c.DateTime(nullable: false));
        }
    }
}
