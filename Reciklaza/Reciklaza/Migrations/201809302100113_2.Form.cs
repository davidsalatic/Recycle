namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2Form : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materijals", t => t.Mat_Id, cascadeDelete: true)
                .ForeignKey("dbo.ReciklaznoMestoes", t => t.ReciklaznoMesto_Id)
                .Index(t => t.Mat_Id)
                .Index(t => t.ReciklaznoMesto_Id);
            
            AddColumn("dbo.ReciklaznoMestoes", "CenaPoKg", c => c.Int(nullable: false));
            AddColumn("dbo.ReciklaznoMestoes", "TipMaterijala_Id", c => c.Int());
            CreateIndex("dbo.ReciklaznoMestoes", "TipMaterijala_Id");
            AddForeignKey("dbo.ReciklaznoMestoes", "TipMaterijala_Id", "dbo.Materijals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReciklaznoMestoes", "TipMaterijala_Id", "dbo.Materijals");
            DropForeignKey("dbo.Stavkas", "ReciklaznoMesto_Id", "dbo.ReciklaznoMestoes");
            DropForeignKey("dbo.Stavkas", "Mat_Id", "dbo.Materijals");
            DropIndex("dbo.Stavkas", new[] { "ReciklaznoMesto_Id" });
            DropIndex("dbo.Stavkas", new[] { "Mat_Id" });
            DropIndex("dbo.ReciklaznoMestoes", new[] { "TipMaterijala_Id" });
            DropColumn("dbo.ReciklaznoMestoes", "TipMaterijala_Id");
            DropColumn("dbo.ReciklaznoMestoes", "CenaPoKg");
            DropTable("dbo.Stavkas");
        }
    }
}
