namespace Supporter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serif1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IlacDepolari",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepoAdi = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Problemler", "IlacDepoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Problemler", "IlacDepoId");
            AddForeignKey("dbo.Problemler", "IlacDepoId", "dbo.IlacDepolari", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Problemler", "IlacDepoId", "dbo.IlacDepolari");
            DropIndex("dbo.Problemler", new[] { "IlacDepoId" });
            DropColumn("dbo.Problemler", "IlacDepoId");
            DropTable("dbo.IlacDepolari");
        }
    }
}
