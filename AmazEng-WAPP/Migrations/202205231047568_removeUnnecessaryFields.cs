namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUnnecessaryFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuizIdioms", "QuizId", "dbo.Quizzes");
            DropForeignKey("dbo.QuizIdioms", "IdiomId", "dbo.Idioms");
            DropForeignKey("dbo.Quizzes", "MemberId", "dbo.Members");
            DropIndex("dbo.Quizzes", new[] { "MemberId" });
            DropIndex("dbo.QuizIdioms", new[] { "QuizId" });
            DropIndex("dbo.QuizIdioms", new[] { "IdiomId" });
            RenameColumn(table: "dbo.Feedbacks", name: "MemberId", newName: "Member_Id");
            RenameColumn(table: "dbo.Messages", name: "MemberId", newName: "Member_Id");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_MemberId", newName: "IX_Member_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_MemberId", newName: "IX_Member_Id");
            DropColumn("dbo.Members", "EmailVerifiedAt");
            DropTable("dbo.Quizzes");
            DropTable("dbo.QuizIdioms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuizIdioms",
                c => new
                    {
                        QuizId = c.Int(nullable: false),
                        IdiomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizId, t.IdiomId });
            
            CreateTable(
                "dbo.Quizzes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        MemberId = c.Int(nullable: false),
                        PlayCount = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "EmailVerifiedAt", c => c.DateTime());
            RenameIndex(table: "dbo.Messages", name: "IX_Member_Id", newName: "IX_MemberId");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_Member_Id", newName: "IX_MemberId");
            RenameColumn(table: "dbo.Messages", name: "Member_Id", newName: "MemberId");
            RenameColumn(table: "dbo.Feedbacks", name: "Member_Id", newName: "MemberId");
            CreateIndex("dbo.QuizIdioms", "IdiomId");
            CreateIndex("dbo.QuizIdioms", "QuizId");
            CreateIndex("dbo.Quizzes", "MemberId");
            AddForeignKey("dbo.Quizzes", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuizIdioms", "IdiomId", "dbo.Idioms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuizIdioms", "QuizId", "dbo.Quizzes", "Id", cascadeDelete: true);
        }
    }
}
