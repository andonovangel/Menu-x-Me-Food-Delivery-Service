namespace Menu_x_Me_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedpopularity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Popularity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "Popularity");
        }
    }
}
