using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AmazEng_WAPP.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new AmazengContext();

            using (var reader = new StreamReader(@"data\tags-v1.csv")) //relative to bin folder 
            {
                bool isFirstLine = true;
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
                    //context.Tags.AddOrUpdate(
                    //    new Tag { Name = tagName }
                    //    );
                }
            }
            using (var reader = new StreamReader(@"data\final_idioms_data_v1.csv"))
            {
                bool isFirstLine = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
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

                    var tagNames = tagCsv.Split(',');
                    // remove default first character tag, and "xyz" tag
                    tagNames = tagNames.Where(tagName => tagName.Length != 1 && tagName != "xyz").ToArray();
                    // get first character as tag
                    string tempStr = Regex.Replace(idiomName, @"\(.+\)", "").Trim();
                    string firstCharacter = tempStr.Substring(0, 1);
                    tagNames.Append(firstCharacter);

                    //List<Tag> tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                    //context.Idioms.AddOrUpdate(
                    //    new Idiom
                    //    {
                    //        Name = idiomName,
                    //        Meaning = meaning,
                    //        Example = example,
                    //        Origin = origin,
                    //        Pronunciation = pronunciation,
                    //        Tags = tags
                    //    }
                    //    );

                }
            }
        }
    }
}
