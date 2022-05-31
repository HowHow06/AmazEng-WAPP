
namespace AmazEng_WAPP.Migrations
{
    using AmazEng_WAPP.Class.Auth;
    using AmazEng_WAPP.DataAccess;
    using AmazEng_WAPP.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Hosting;

    internal sealed class Configuration : DbMigrationsConfiguration<AmazEng_WAPP.DataAccess.AmazengContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AmazEng_WAPP.DataAccess.AmazengContext context)
        {
            ClearIdiomsAndTagsTable(context);

            InitializeLibraryTypes(context);

            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            InitialiseTagData(context);
            InitialiseIdiomData(context);
            // add member
            InitialiseDefaultMember(context);

            ClearAdminAndRoleTable(context);
            InitialiseAdminRole(context);
            // add admin
            InitialiseDefaultAdmin(context);

            ClearMessageAndFeedbackTable(context);
            InitialiseMessageAndFeedback(context);

            ClearLibraryIdiomsTable(context);
            InitialiseLibraryIdioms(context);
        }

        private void ClearLibraryIdiomsTable(AmazengContext context)
        {
            context.Database.ExecuteSqlCommand(@"
                DELETE FROM [dbo].LibraryIdioms;
            ");
            Console.WriteLine("Cleared Library-Idioms data");
        }

        // this function will throw exception
        private void InitialiseLibraryIdioms(AmazengContext context)
        {
            var members = context.Members.ToList();
            Random random = new Random();
            Idiom idiom;
            int loopCount;
            foreach (var member in members)
            {
                loopCount = random.Next(2);
                for (int i = 0; i < loopCount; i++)
                {
                    idiom = Idiom.GetRandomIdiom(context);
                    member.GetHistoryLibrary().AddIdiom(idiom, context);
                }

                loopCount = random.Next(2);
                for (int i = 0; i < loopCount; i++)
                {
                    idiom = Idiom.GetRandomIdiom(context);
                    member.GetFavouriteLibrary().AddIdiom(idiom, context);
                }

                loopCount = random.Next(2);
                for (int i = 0; i < loopCount; i++)
                {
                    idiom = Idiom.GetRandomIdiom(context);
                    member.GetLearnLaterLibrary().AddIdiom(idiom, context);
                }
            }

            context.SaveChanges();
            Console.WriteLine("Randomly inserted idioms to libraries");
        }

        private void InitialiseMessageAndFeedback(AmazengContext context)
        {
            for (int i = 0; i < 20; i++)
            {
                context.Messages.AddOrUpdate(
                        new Message
                        {
                            IssuerEmail = Faker.Internet.Email(),
                            IssuerName = Faker.Name.FullName(),
                            Subject = Faker.Lorem.Sentence(),
                            Content = Faker.Lorem.Paragraph(),
                            SentAt = DateTime.UtcNow,
                        }
                    );
                context.Feedbacks.AddOrUpdate(
                        new Feedback
                        {
                            IssuerEmail = Faker.Internet.Email(),
                            IssuerName = Faker.Name.FullName(),
                            Idiom = context.Idioms.ToList().ElementAt(i + 20),
                            Content = Faker.Lorem.Paragraph(),
                            SentAt = DateTime.UtcNow,
                        }
                    );
            }

            context.SaveChanges();
            Console.WriteLine("Created Message and Feedback types");
        }

        private void ClearMessageAndFeedbackTable(AmazengContext context)
        {
            context.Database.ExecuteSqlCommand(@"
                DELETE FROM [dbo].Messages;
                DELETE FROM [dbo].Feedbacks;
                DBCC CHECKIDENT ('Messages', RESEED, 0);
                DBCC CHECKIDENT ('Feedbacks', RESEED, 0);
            ");
            Console.WriteLine("Cleared Message and Feedback data");
        }

        private void InitializeLibraryTypes(AmazengContext context)
        {
            context.Database.ExecuteSqlCommand(@"
                DELETE FROM [dbo].LibraryTypes;
                DBCC CHECKIDENT ('LibraryTypes', RESEED, 0);
            ");
            Console.WriteLine("Cleared Library Types");
            context.LibraryTypes.AddOrUpdate(
                 new LibraryType
                 {
                     Name = "Favourite"
                 },
                 new LibraryType
                 {
                     Name = "History"
                 },
                 new LibraryType
                 {
                     Name = "LearnLater"
                 }
                 );
            context.SaveChanges();
            Console.WriteLine("Created library types");
        }

        private void ClearAdminAndRoleTable(AmazengContext context)
        {
            context.Database.ExecuteSqlCommand(@"
                DELETE FROM [dbo].Admins;
                DELETE FROM [dbo].AdminRoles;
                DBCC CHECKIDENT ('Admins', RESEED, 0);
                DBCC CHECKIDENT ('AdminRoles', RESEED, 0);
            ");
            Console.WriteLine("Cleared Admin Role and Admin data");
        }

        private void InitialiseAdminRole(AmazengContext context)
        {
            context.AdminRoles.AddOrUpdate(
                new AdminRole
                {
                    Id = 1,
                    Name = "Admin",
                    Permission = JsonConvert.SerializeObject(new
                    {
                        Dashboard = true,
                        ManageMembers = true,
                        ManageIdioms = true,
                        ManageIdiomTags = true,
                        ManageAdmins = false,
                        ManageMessages = true,
                        ManageIdiomFeedback = true,
                    })
                },
                new AdminRole
                {
                    Id = 2,
                    Name = "Super Admin",
                    Permission = JsonConvert.SerializeObject(new
                    {
                        Dashboard = true,
                        ManageMembers = true,
                        ManageIdioms = true,
                        ManageIdiomTags = true,
                        ManageAdmins = true,
                        ManageMessages = true,
                        ManageIdiomFeedback = true,
                    })
                }
                );
            context.SaveChanges();
            Console.WriteLine("Created admin role");
        }

        private void InitialiseDefaultMember(AmazengContext context)
        {

            context.Database.ExecuteSqlCommand(@"
                DELETE FROM [dbo].Members;
                DBCC CHECKIDENT ('Members', RESEED, 0);
            ");

            Console.WriteLine("Cleared Members Table Data");
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                context.Members.AddOrUpdate(
                               new Member
                               {
                                   Name = Faker.Name.FullName(Faker.NameFormats.Standard),
                                   Username = $"{Faker.Name.Last()}{i}",
                                   Password = Auth.CreatePasswordHash("member"),
                                   //Email = $"limhowardbb+member0{i}@gmail.com",
                                   Email = Faker.Internet.Email(),
                                   BrowsedIdiomCount = random.Next(60)
                               }
                               );
            }

            context.SaveChanges();
            Console.WriteLine("Created default member");
        }

        private void InitialiseDefaultAdmin(AmazengContext context)
        {
            context.Admins.AddOrUpdate(
                new Admin
                {
                    Id = 1,
                    Name = "Jerry the Admin",
                    Username = "admin",
                    Password = Auth.CreatePasswordHash("admin"),
                    Email = "limhowardbbsuperadmin@gmail.com",
                    Role = context.GetSuperAdminRole()
                },
                 new Admin
                 {
                     Name = "Berry Newbie Admin",
                     Username = "normalAdmin",
                     Password = Auth.CreatePasswordHash("admin"),
                     Email = "limhowardbbnormaladmin@gmail.com",
                     Role = context.GetNormalAdminRole()
                 }
                );
            context.SaveChanges();
            Console.WriteLine("Created default admin");
        }

        private void ClearIdiomsAndTagsTable(AmazengContext context)
        {
            context.Database.ExecuteSqlCommand(@"
                DELETE FROM [dbo].Idioms;
                DELETE FROM [dbo].Tags;
                DELETE FROM [dbo].IdiomTags;
                DBCC CHECKIDENT ('Idioms', RESEED, 0);
                DBCC CHECKIDENT ('Tags', RESEED, 0);
            ");
            Console.WriteLine("Cleared Idiom and Tag data");
        }

        private void InitialiseIdiomData(AmazengContext context)
        {
            List<String> errorIdiom = new List<string>();
            Random random = new Random();
            using (var reader = new StreamReader(MapPath("~/Assets/data/final_idioms_data_v4.tsv")))
            {
                bool isFirstLine = true;
                int i = 0;
                while (!reader.EndOfStream)
                {
                    //if (i > 20)
                    //{
                    //    break;
                    //}
                    var line = reader.ReadLine();
                    var values = line.Split('\t');
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }
                    string idiomName = values[0];
                    string meaning = values[1];
                    string example = values[2];
                    string origin = values[3];
                    string pronunciation = values[5];
                    string tagCsv = values[6];

                    var tagNames = tagCsv.Split(',').ToList();
                    // remove default first character tag, and "xyz" tag
                    tagNames = tagNames.Where(tagName => tagName.Length != 1 && tagName != "xyz").ToList();
                    // get first character as tag
                    string firstCharacter = Regex.Replace(idiomName, @"\(.+?\)", "").Trim().Substring(0, 1);
                    tagNames.Add(firstCharacter);

                    List<Tag> tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                    Idiom idiom = new Idiom
                    {
                        Id = i,
                        Name = idiomName,
                        Meaning = meaning,
                        Example = example,
                        Origin = origin,
                        Tags = tags,
                        Pronunciation = pronunciation,
                        ViewCount = random.Next(20) * random.Next(20)
                    };
                    //foreach (var tag in tags)
                    //{
                    //    idiom.Tags.Add(tag);
                    //}
                    context.Idioms.AddOrUpdate(idiom);
                    i++;
                }
            }
            context.SaveChanges();
            Console.WriteLine("Completed creating Idiom data");
        }

        private void InitialiseTagData(AmazengContext context)
        {

            using (var reader = new StreamReader(MapPath("~/Assets/data/tags-v1.csv"))) //relative to bin folder 
            {
                bool isFirstLine = true;
                int i = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    string tagName = values[1];
                    context.Tags.AddOrUpdate(
                        new Tag { Id = i, Name = tagName }
                        );
                    i++;
                }
            }

            context.SaveChanges();
            Console.WriteLine("Completed creating Tag data");

        }

        private string MapPath(string filePath)
        {
            if (HttpContext.Current != null)
                return HostingEnvironment.MapPath(filePath);

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath; //was AbsolutePath but didn't work with spaces according to comments
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, ".." + filePath.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}
