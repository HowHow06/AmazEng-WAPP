namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLastLoginAtToMemberAndAdminTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "LastLoginAt", c => c.DateTime());
            AddColumn("dbo.Members", "LastLoginAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "LastLoginAt");
            DropColumn("dbo.Admins", "LastLoginAt");
        }
    }
}
