namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomePageDesign : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReciklaznoMestoes", "CenaPoKg", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReciklaznoMestoes", "CenaPoKg", c => c.Int(nullable: false));
        }
    }
}
