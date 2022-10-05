namespace Menu_x_Me_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedOrderModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "FkInvoiceID", "dbo.InvoiceModels");
            DropForeignKey("dbo.Orders", "FkProdId", "dbo.Foods");
            DropIndex("dbo.Orders", new[] { "FkProdId" });
            DropIndex("dbo.Orders", new[] { "FkInvoiceID" });
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "FkProdId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "FkProdId");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Orders", "FkInvoiceID");
            DropTable("dbo.InvoiceModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InvoiceModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateInvoice = c.DateTime(),
                        Total_Bill = c.Single(nullable: false),
                        FKUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Orders", "FkInvoiceID", c => c.Int());
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "FkProdId", c => c.Int());
            AddPrimaryKey("dbo.Orders", "Id");
            CreateIndex("dbo.Orders", "FkInvoiceID");
            CreateIndex("dbo.Orders", "FkProdId");
            AddForeignKey("dbo.Orders", "FkProdId", "dbo.Foods", "Id");
            AddForeignKey("dbo.Orders", "FkInvoiceID", "dbo.InvoiceModels", "ID");
        }
    }
}
