namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cart : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Games", name: "Cart_CartId", newName: "CartId");
            RenameIndex(table: "dbo.Games", name: "IX_Cart_CartId", newName: "IX_CartId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Games", name: "IX_CartId", newName: "IX_Cart_CartId");
            RenameColumn(table: "dbo.Games", name: "CartId", newName: "Cart_CartId");
        }
    }
}
