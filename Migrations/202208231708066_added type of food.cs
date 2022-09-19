namespace Menu_x_Me_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtypeoffood : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "TypeFood", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "TypeFood");
        }
    }
}
