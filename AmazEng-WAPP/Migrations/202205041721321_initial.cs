namespace AmazEng_WAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminRoles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Permission = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Admins",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Username = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    ProfilePicture = c.String(),
                    RoleId = c.Int(nullable: false),
                    DeletedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Feedbacks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdiomId = c.Int(nullable: false),
                    MemberId = c.Int(nullable: false),
                    IssuerName = c.String(),
                    IssuerEmail = c.String(),
                    SentAt = c.DateTime(nullable: false),
                    Content = c.String(nullable: false),
                    DeletedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Idioms", t => t.IdiomId, cascadeDelete: true)
                .Index(t => t.IdiomId)
                .Index(t => t.MemberId);

            CreateTable(
                "dbo.Idioms",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Meaning = c.String(nullable: false),
                    Pronunciation = c.String(),
                    ViewCount = c.Int(nullable: false, defaultValue: 0),
                    Example = c.String(),
                    Origin = c.String(),
                    DeletedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.LibraryIdioms",
                c => new
                {
                    LibraryId = c.Int(nullable: false),
                    IdiomId = c.Int(nullable: false),
                    AddedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.LibraryId, t.IdiomId })
                .ForeignKey("dbo.Idioms", t => t.IdiomId, cascadeDelete: true)
                .ForeignKey("dbo.Libraries", t => t.LibraryId, cascadeDelete: true)
                .Index(t => t.LibraryId)
                .Index(t => t.IdiomId);

            CreateTable(
                "dbo.Libraries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MemberId = c.Int(nullable: false),
                    LibraryTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LibraryTypes", t => t.LibraryTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.LibraryTypeId);

            CreateTable(
                "dbo.LibraryTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Members",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Username = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    ProfilePicture = c.String(),
                    EmailVerifiedAt = c.DateTime(),
                    RememberToken = c.String(),
                    BrowsedIdiomCount = c.Int(nullable: false, defaultValue: 0),
                    DeletedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MemberId = c.Int(nullable: false),
                    IssuerName = c.String(),
                    IssuerEmail = c.String(),
                    Subject = c.String(nullable: false),
                    SentAt = c.DateTime(nullable: false),
                    Content = c.String(nullable: false),
                    DeletedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);

            CreateTable(
                "dbo.Quizzes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    MemberId = c.Int(nullable: false),
                    PlayCount = c.Int(nullable: false, defaultValue: 0),
                    CreatedAt = c.DateTime(nullable: false),
                    ModifiedAt = c.DateTime(nullable: false),
                    DeletedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);

            CreateTable(
                "dbo.Tags",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.QuizIdioms",
                c => new
                {
                    QuizId = c.Int(nullable: false),
                    IdiomId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.QuizId, t.IdiomId })
                .ForeignKey("dbo.Quizzes", t => t.QuizId, cascadeDelete: true)
                .ForeignKey("dbo.Idioms", t => t.IdiomId, cascadeDelete: true)
                .Index(t => t.QuizId)
                .Index(t => t.IdiomId);

            CreateTable(
                "dbo.IdiomTags",
                c => new
                {
                    IdiomId = c.Int(nullable: false),
                    TagId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.IdiomId, t.TagId })
                .ForeignKey("dbo.Idioms", t => t.IdiomId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.IdiomId)
                .Index(t => t.TagId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "IdiomId", "dbo.Idioms");
            DropForeignKey("dbo.IdiomTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.IdiomTags", "IdiomId", "dbo.Idioms");
            DropForeignKey("dbo.Quizzes", "MemberId", "dbo.Members");
            DropForeignKey("dbo.QuizIdioms", "IdiomId", "dbo.Idioms");
            DropForeignKey("dbo.QuizIdioms", "QuizId", "dbo.Quizzes");
            DropForeignKey("dbo.Messages", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Libraries", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Feedbacks", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Libraries", "LibraryTypeId", "dbo.LibraryTypes");
            DropForeignKey("dbo.LibraryIdioms", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.LibraryIdioms", "IdiomId", "dbo.Idioms");
            DropForeignKey("dbo.Admins", "RoleId", "dbo.AdminRoles");
            DropIndex("dbo.IdiomTags", new[] { "TagId" });
            DropIndex("dbo.IdiomTags", new[] { "IdiomId" });
            DropIndex("dbo.QuizIdioms", new[] { "IdiomId" });
            DropIndex("dbo.QuizIdioms", new[] { "QuizId" });
            DropIndex("dbo.Quizzes", new[] { "MemberId" });
            DropIndex("dbo.Messages", new[] { "MemberId" });
            DropIndex("dbo.Libraries", new[] { "LibraryTypeId" });
            DropIndex("dbo.Libraries", new[] { "MemberId" });
            DropIndex("dbo.LibraryIdioms", new[] { "IdiomId" });
            DropIndex("dbo.LibraryIdioms", new[] { "LibraryId" });
            DropIndex("dbo.Feedbacks", new[] { "MemberId" });
            DropIndex("dbo.Feedbacks", new[] { "IdiomId" });
            DropIndex("dbo.Admins", new[] { "RoleId" });
            DropTable("dbo.IdiomTags");
            DropTable("dbo.QuizIdioms");
            DropTable("dbo.Tags");
            DropTable("dbo.Quizzes");
            DropTable("dbo.Messages");
            DropTable("dbo.Members");
            DropTable("dbo.LibraryTypes");
            DropTable("dbo.Libraries");
            DropTable("dbo.LibraryIdioms");
            DropTable("dbo.Idioms");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Admins");
            DropTable("dbo.AdminRoles");
        }
    }
}
