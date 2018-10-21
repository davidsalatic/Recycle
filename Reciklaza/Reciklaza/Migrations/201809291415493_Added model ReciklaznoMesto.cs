namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedmodelReciklaznoMesto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReciklaznoMestoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 50),
                        Grad = c.String(nullable: false, maxLength: 20),
                        Adresa = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReciklaznoMestoes");
        }
    }
}
