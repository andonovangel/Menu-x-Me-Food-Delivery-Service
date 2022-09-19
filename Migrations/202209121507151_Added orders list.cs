namespace Menu_x_Me_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedorderslist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        Unit_Price = c.Int(nullable: false),
                        Order_Bill = c.Single(nullable: false),
                        Order_Date = c.DateTime(),
                        FkProdId = c.Int(),
                        FkInvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceModels", t => t.FkInvoiceID)
                .ForeignKey("dbo.Foods", t => t.FkProdId)
                .Index(t => t.FkProdId)
                .Index(t => t.FkInvoiceID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "FkProdId", "dbo.Foods");
            DropForeignKey("dbo.Orders", "FkInvoiceID", "dbo.InvoiceModels");
            DropIndex("dbo.Orders", new[] { "FkInvoiceID" });
            DropIndex("dbo.Orders", new[] { "FkProdId" });
            DropTable("dbo.InvoiceModels");
            DropTable("dbo.Orders");
        }
    }
}
