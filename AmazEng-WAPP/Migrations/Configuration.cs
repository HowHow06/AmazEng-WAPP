namespace AmazEng_WAPP.Migrations
{
    using AmazEng_WAPP.DataAccess;
    using AmazEng_WAPP.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal sealed class Configuration : DbMigrationsConfiguration<AmazEng_WAPP.DataAccess.AmazengContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AmazEng_WAPP.DataAccess.AmazengContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            InitialiseTagData(context);
            InitialiseIdiomData(context);
        }

        private void InitialiseIdiomData(AmazengContext context)
        {
            using (var reader = new StreamReader(@"data\final_idioms_data_v1.tsv"))
            {
                bool isFirstLine = true;
                int i = 0;
                while (!reader.EndOfStream)
                {
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
                        Tags = new List<Tag>(),
                        Pronunciation = pronunciation,
                    };
                    foreach (var tag in tags)
                    {
                        idiom.Tags.Add(tag);
                    }
                    context.Idioms.AddOrUpdate(idiom);
                    i++;
                }
            }
            Console.WriteLine("Completed creating Idiom data");
        }

        private void InitialiseTagData(AmazengContext context)
        {

            using (var reader = new StreamReader(@"data\tags-v1.csv")) //relative to bin folder 
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

            Console.WriteLine("Completed creating Tag data");

        }
    }
}
