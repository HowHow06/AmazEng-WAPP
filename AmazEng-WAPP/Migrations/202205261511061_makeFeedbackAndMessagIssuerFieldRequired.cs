namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeFeedbackAndMessagIssuerFieldRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "IssuerName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Feedbacks", "IssuerEmail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Messages", "IssuerName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Messages", "IssuerEmail", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "IssuerEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Messages", "IssuerName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Feedbacks", "IssuerEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Feedbacks", "IssuerName", c => c.String(maxLength: 50));
        }
    }
}
