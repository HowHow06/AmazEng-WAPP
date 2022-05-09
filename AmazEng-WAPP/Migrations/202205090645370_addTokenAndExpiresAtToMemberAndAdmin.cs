namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTokenAndExpiresAtToMemberAndAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "RememberToken", c => c.String());
            AddColumn("dbo.Admins", "TokenExpiresAt", c => c.DateTime());
            AddColumn("dbo.Members", "TokenExpiresAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "TokenExpiresAt");
            DropColumn("dbo.Admins", "TokenExpiresAt");
            DropColumn("dbo.Admins", "RememberToken");
        }
    }
}
