namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stavkas", "TipMaterijala_Id", "dbo.Materijals");
            DropForeignKey("dbo.Stavkas", "ReciklaznoMesto_Id", "dbo.ReciklaznoMestoes");
            DropIndex("dbo.Stavkas", new[] { "TipMaterijala_Id" });
            DropIndex("dbo.Stavkas", new[] { "ReciklaznoMesto_Id" });
            DropTable("dbo.Stavkas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipMaterijala_Id = c.Int(nullable: false),
                        ReciklaznoMesto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Stavkas", "ReciklaznoMesto_Id");
            CreateIndex("dbo.Stavkas", "TipMaterijala_Id");
            AddForeignKey("dbo.Stavkas", "ReciklaznoMesto_Id", "dbo.ReciklaznoMestoes", "Id");
            AddForeignKey("dbo.Stavkas", "TipMaterijala_Id", "dbo.Materijals", "Id", cascadeDelete: true);
        }
    }
}
