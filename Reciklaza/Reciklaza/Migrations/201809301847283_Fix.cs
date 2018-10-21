namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipMaterijala_Id = c.Int(nullable: false),
                        ReciklaznoMesto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materijals", t => t.TipMaterijala_Id, cascadeDelete: true)
                .ForeignKey("dbo.ReciklaznoMestoes", t => t.ReciklaznoMesto_Id)
                .Index(t => t.TipMaterijala_Id)
                .Index(t => t.ReciklaznoMesto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stavkas", "ReciklaznoMesto_Id", "dbo.ReciklaznoMestoes");
            DropForeignKey("dbo.Stavkas", "TipMaterijala_Id", "dbo.Materijals");
            DropIndex("dbo.Stavkas", new[] { "ReciklaznoMesto_Id" });
            DropIndex("dbo.Stavkas", new[] { "TipMaterijala_Id" });
            DropTable("dbo.Stavkas");
        }
    }
}
