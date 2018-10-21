namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changestomodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReciklaznoMestoes", "Mat_Id", "dbo.Materijals");
            DropIndex("dbo.ReciklaznoMestoes", new[] { "Mat_Id" });
            DropColumn("dbo.ReciklaznoMestoes", "Mat_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReciklaznoMestoes", "Mat_Id", c => c.Int());
            CreateIndex("dbo.ReciklaznoMestoes", "Mat_Id");
            AddForeignKey("dbo.ReciklaznoMestoes", "Mat_Id", "dbo.Materijals", "Id");
        }
    }
}
