namespace Reciklaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedadminoptionS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "LoginErrorMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "LoginErrorMessage");
        }
    }
}
