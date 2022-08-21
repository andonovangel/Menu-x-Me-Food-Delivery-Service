namespace Menu_x_Me_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedClientFoodRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodClients",
                c => new
                    {
                        Food_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Food_Id, t.Client_Id })
                .ForeignKey("dbo.Foods", t => t.Food_Id, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Food_Id)
                .Index(t => t.Client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.FoodClients", "Food_Id", "dbo.Foods");
            DropIndex("dbo.FoodClients", new[] { "Client_Id" });
            DropIndex("dbo.FoodClients", new[] { "Food_Id" });
            DropTable("dbo.FoodClients");
        }
    }
}
