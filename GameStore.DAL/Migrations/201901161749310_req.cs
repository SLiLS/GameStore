namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class req : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Games");
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OperationSystem = c.String(),
                        CPU = c.String(),
                        RAM = c.String(),
                        VideoCard = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Games", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Games", "Id");
            DropColumn("dbo.Games", "GameId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GameId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Requirements", "Id", "dbo.Games");
            DropIndex("dbo.Requirements", new[] { "Id" });
            DropPrimaryKey("dbo.Games");
            DropColumn("dbo.Games", "Id");
            DropTable("dbo.Requirements");
            AddPrimaryKey("dbo.Games", "GameId");
        }
    }
}
