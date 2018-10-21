namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Backto1entity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stavkas", "Mat_Id", "dbo.Materijals");
            DropForeignKey("dbo.Stavkas", "ReciklaznoMesto_Id", "dbo.ReciklaznoMestoes");
            DropForeignKey("dbo.ReciklaznoMestoes", "TipMaterijala_Id", "dbo.Materijals");
            DropIndex("dbo.ReciklaznoMestoes", new[] { "TipMaterijala_Id" });
            DropIndex("dbo.Stavkas", new[] { "Mat_Id" });
            DropIndex("dbo.Stavkas", new[] { "ReciklaznoMesto_Id" });
            AddColumn("dbo.ReciklaznoMestoes", "Materijal", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.ReciklaznoMestoes", "TipMaterijala_Id");
            DropTable("dbo.Materijals");
            DropTable("dbo.Stavkas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CenaPoKg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mat_Id = c.Int(nullable: false),
                        ReciklaznoMesto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materijals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ReciklaznoMestoes", "TipMaterijala_Id", c => c.Int());
            DropColumn("dbo.ReciklaznoMestoes", "Materijal");
            CreateIndex("dbo.Stavkas", "ReciklaznoMesto_Id");
            CreateIndex("dbo.Stavkas", "Mat_Id");
            CreateIndex("dbo.ReciklaznoMestoes", "TipMaterijala_Id");
            AddForeignKey("dbo.ReciklaznoMestoes", "TipMaterijala_Id", "dbo.Materijals", "Id");
            AddForeignKey("dbo.Stavkas", "ReciklaznoMesto_Id", "dbo.ReciklaznoMestoes", "Id");
            AddForeignKey("dbo.Stavkas", "Mat_Id", "dbo.Materijals", "Id", cascadeDelete: true);
        }
    }
}
