namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNvarcharLengthLimit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdminRoles", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AdminRoles", "Permission", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Admins", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Admins", "Username", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Admins", "ProfilePicture", c => c.String(maxLength: 255));
            AlterColumn("dbo.Admins", "RememberToken", c => c.String(maxLength: 150));
            AlterColumn("dbo.Feedbacks", "IssuerName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Feedbacks", "IssuerEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Feedbacks", "Content", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Idioms", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Idioms", "Meaning", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Idioms", "Example", c => c.String(maxLength: 500));
            AlterColumn("dbo.Idioms", "Origin", c => c.String(maxLength: 500));
            AlterColumn("dbo.Idioms", "Pronunciation", c => c.String(maxLength: 255));
            AlterColumn("dbo.LibraryTypes", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Members", "Username", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Members", "Password", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Members", "ProfilePicture", c => c.String(maxLength: 255));
            AlterColumn("dbo.Members", "RememberToken", c => c.String(maxLength: 150));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Messages", "IssuerName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Messages", "IssuerEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Messages", "Subject", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false, maxLength: 3000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "IssuerEmail", c => c.String());
            AlterColumn("dbo.Messages", "IssuerName", c => c.String());
            AlterColumn("dbo.Tags", "Name", c => c.String());
            AlterColumn("dbo.Members", "RememberToken", c => c.String());
            AlterColumn("dbo.Members", "ProfilePicture", c => c.String());
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.LibraryTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Idioms", "Pronunciation", c => c.String());
            AlterColumn("dbo.Idioms", "Origin", c => c.String());
            AlterColumn("dbo.Idioms", "Example", c => c.String());
            AlterColumn("dbo.Idioms", "Meaning", c => c.String(nullable: false));
            AlterColumn("dbo.Idioms", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Feedbacks", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Feedbacks", "IssuerEmail", c => c.String());
            AlterColumn("dbo.Feedbacks", "IssuerName", c => c.String());
            AlterColumn("dbo.Admins", "RememberToken", c => c.String());
            AlterColumn("dbo.Admins", "ProfilePicture", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AdminRoles", "Permission", c => c.String(nullable: false));
            AlterColumn("dbo.AdminRoles", "Name", c => c.String(nullable: false));
        }
    }
}
