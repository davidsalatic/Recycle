namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changestomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReciklaznoMestoes", "Telefon", c => c.String(maxLength: 50));
            AddColumn("dbo.ReciklaznoMestoes", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.ReciklaznoMestoes", "Website", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReciklaznoMestoes", "Website");
            DropColumn("dbo.ReciklaznoMestoes", "Email");
            DropColumn("dbo.ReciklaznoMestoes", "Telefon");
        }
    }
}
