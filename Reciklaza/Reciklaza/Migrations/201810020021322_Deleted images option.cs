namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletedimagesoption : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materijals", "ImagePath");
            DropColumn("dbo.ReciklaznoMestoes", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReciklaznoMestoes", "ImagePath", c => c.String());
            AddColumn("dbo.Materijals", "ImagePath", c => c.String());
        }
    }
}
