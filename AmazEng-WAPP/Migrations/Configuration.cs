namespace AmazEng_WAPP.Migrations
{
    using AmazEng_WAPP.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

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

            using (var reader = new StreamReader(@"data\tags-v1.csv")) //relative to bin folder 
            {
                bool isFirstLine = true;
                while (!reader.EndOfStream)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    string tagName = values[1];
                    context.Tags.AddOrUpdate(
                        new Tag { Name = tagName }
                        );
                }
            }
            //using (var reader = new StreamReader(@"data\final_idioms_data_v1.csv"))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        var line = reader.ReadLine();
            //        var values = line.Split(';');



            //        //var values[0]
            //    }
            //}
        }
    }
}
