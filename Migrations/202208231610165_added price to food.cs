namespace Menu_x_Me_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpricetofood : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "Price");
        }
    }
}
