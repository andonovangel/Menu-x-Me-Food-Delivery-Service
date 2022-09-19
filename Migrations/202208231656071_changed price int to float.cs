namespace Menu_x_Me_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpriceinttofloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Price", c => c.Int(nullable: false));
        }
    }
}
