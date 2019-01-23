namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Games");
            AlterColumn("dbo.Games", "GameId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Games", "GameId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Games");
            AlterColumn("dbo.Games", "GameId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Games", "GameId");
        }
    }
}
