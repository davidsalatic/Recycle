namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddeddatavalidationsforMaterijal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReciklaznoMestoes", "Naziv", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.ReciklaznoMestoes", "Adresa", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ReciklaznoMestoes", "Telefon", c => c.String(maxLength: 25));
            AlterColumn("dbo.ReciklaznoMestoes", "Email", c => c.String(maxLength: 60));
            AlterColumn("dbo.ReciklaznoMestoes", "Website", c => c.String(maxLength: 100));
            AlterColumn("dbo.ReciklaznoMestoes", "NazivMaterijala", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReciklaznoMestoes", "NazivMaterijala", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ReciklaznoMestoes", "Website", c => c.String(maxLength: 50));
            AlterColumn("dbo.ReciklaznoMestoes", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.ReciklaznoMestoes", "Telefon", c => c.String(maxLength: 50));
            AlterColumn("dbo.ReciklaznoMestoes", "Adresa", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ReciklaznoMestoes", "Naziv", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
