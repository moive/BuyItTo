namespace BuyItTo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        lastname = c.String(nullable: false, maxLength: 100),
                        address = c.String(nullable: false, maxLength: 200),
                        invoiceAddress = c.String(maxLength: 200),
                        shippingAddress = c.String(maxLength: 200),
                        phone = c.String(nullable: false, maxLength: 20),
                        email = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        createDate = c.DateTime(nullable: false),
                        customerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.customers", t => t.customerID, cascadeDelete: true)
                .Index(t => t.customerID);
            
            CreateTable(
                "dbo.orders_detail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 10, scale: 2),
                        productID = c.Int(nullable: false),
                        orderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.products", t => t.productID, cascadeDelete: true)
                .ForeignKey("dbo.orders", t => t.orderID, cascadeDelete: true)
                .Index(t => t.productID)
                .Index(t => t.orderID);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        createDate = c.DateTime(nullable: false),
                        name = c.String(nullable: false, maxLength: 100),
                        description = c.String(nullable: false),
                        price = c.Decimal(nullable: false, precision: 10, scale: 2),
                        categoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.products_category", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID);
            
            CreateTable(
                "dbo.products_category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.orders_detail", "orderID", "dbo.orders");
            DropForeignKey("dbo.orders_detail", "productID", "dbo.products");
            DropForeignKey("dbo.products", "categoryID", "dbo.products_category");
            DropForeignKey("dbo.orders", "customerID", "dbo.customers");
            DropIndex("dbo.products", new[] { "categoryID" });
            DropIndex("dbo.orders_detail", new[] { "orderID" });
            DropIndex("dbo.orders_detail", new[] { "productID" });
            DropIndex("dbo.orders", new[] { "customerID" });
            DropTable("dbo.products_category");
            DropTable("dbo.products");
            DropTable("dbo.orders_detail");
            DropTable("dbo.orders");
            DropTable("dbo.customers");
        }
    }
}
