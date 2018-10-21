namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedimagepathtomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materijals", "ImagePath", c => c.String());
            AddColumn("dbo.ReciklaznoMestoes", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReciklaznoMestoes", "ImagePath");
            DropColumn("dbo.Materijals", "ImagePath");
        }
    }
}
