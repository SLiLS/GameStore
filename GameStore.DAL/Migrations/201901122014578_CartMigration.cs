namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Game_GameId", "dbo.Games");
            DropIndex("dbo.Orders", new[] { "Game_GameId" });
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CartId);
            
            AddColumn("dbo.Games", "Cart_CartId", c => c.Int());
            CreateIndex("dbo.Games", "Cart_CartId");
            AddForeignKey("dbo.Games", "Cart_CartId", "dbo.Carts", "CartId");
            DropColumn("dbo.Orders", "Game_GameId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Game_GameId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Games", "Cart_CartId", "dbo.Carts");
            DropIndex("dbo.Games", new[] { "Cart_CartId" });
            DropColumn("dbo.Games", "Cart_CartId");
            DropTable("dbo.Carts");
            CreateIndex("dbo.Orders", "Game_GameId");
            AddForeignKey("dbo.Orders", "Game_GameId", "dbo.Games", "GameId");
        }
    }
}
