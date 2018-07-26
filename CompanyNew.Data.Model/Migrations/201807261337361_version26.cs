namespace CompanyNew.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "MarkOfCar", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "MarkOfCar");
        }
    }
}
