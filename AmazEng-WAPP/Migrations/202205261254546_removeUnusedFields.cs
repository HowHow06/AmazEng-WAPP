namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class removeUnusedFields : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Feedbacks", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Feedbacks", "FK_dbo.Feedbacks_dbo.Members_MemberId");
            //DropForeignKey("dbo.Messages", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Messages", "FK_dbo.Messages_dbo.Members_MemberId");
            DropIndex("dbo.Feedbacks", new[] { "Member_Id" });
            DropIndex("dbo.Messages", new[] { "Member_Id" });
            DropColumn("dbo.Feedbacks", "Member_Id");
            DropColumn("dbo.Messages", "Member_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Messages", "Member_Id", c => c.Int());
            AddColumn("dbo.Feedbacks", "Member_Id", c => c.Int());
            CreateIndex("dbo.Messages", "Member_Id");
            CreateIndex("dbo.Feedbacks", "Member_Id");
            AddForeignKey("dbo.Messages", "Member_Id", "dbo.Members", "Id");
            AddForeignKey("dbo.Feedbacks", "Member_Id", "dbo.Members", "Id");
        }
    }
}
