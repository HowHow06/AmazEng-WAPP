namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMemberIdToNullableInMessageTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "MemberId", "dbo.Members");
            DropIndex("dbo.Messages", new[] { "MemberId" });
            AlterColumn("dbo.Messages", "MemberId", c => c.Int());
            CreateIndex("dbo.Messages", "MemberId");
            AddForeignKey("dbo.Messages", "MemberId", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "MemberId", "dbo.Members");
            DropIndex("dbo.Messages", new[] { "MemberId" });
            AlterColumn("dbo.Messages", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "MemberId");
            AddForeignKey("dbo.Messages", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
    }
}
