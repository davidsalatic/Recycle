namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Minorchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materijals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ReciklaznoMestoes", "NazivMaterijala", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ReciklaznoMestoes", "Mat_Id", c => c.Int());
            CreateIndex("dbo.ReciklaznoMestoes", "Mat_Id");
            AddForeignKey("dbo.ReciklaznoMestoes", "Mat_Id", "dbo.Materijals", "Id");
            DropColumn("dbo.ReciklaznoMestoes", "Materijal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReciklaznoMestoes", "Materijal", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.ReciklaznoMestoes", "Mat_Id", "dbo.Materijals");
            DropIndex("dbo.ReciklaznoMestoes", new[] { "Mat_Id" });
            DropColumn("dbo.ReciklaznoMestoes", "Mat_Id");
            DropColumn("dbo.ReciklaznoMestoes", "NazivMaterijala");
            DropTable("dbo.Materijals");
        }
    }
}
