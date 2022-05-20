namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMemberIdToNullableFeedbackTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "MemberId", "dbo.Members");
            DropIndex("dbo.Feedbacks", new[] { "MemberId" });
            AlterColumn("dbo.Feedbacks", "MemberId", c => c.Int());
            CreateIndex("dbo.Feedbacks", "MemberId");
            AddForeignKey("dbo.Feedbacks", "MemberId", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "MemberId", "dbo.Members");
            DropIndex("dbo.Feedbacks", new[] { "MemberId" });
            AlterColumn("dbo.Feedbacks", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "MemberId");
            AddForeignKey("dbo.Feedbacks", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
    }
}
