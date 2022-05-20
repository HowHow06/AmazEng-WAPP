﻿using AmazEng_WAPP.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace AmazEng_WAPP.Models
{
    public class Idiom : ICustomSoftDelete
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Meaning { get; set; }
        public string Example { get; set; }
        public string Origin { get; set; }
        public string Pronunciation { get; set; }
        public int ViewCount { get; set; }//default 0
        public DateTime? DeletedAt { get; set; }


        public virtual ICollection<LibraryIdiom> LibraryIdioms { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }

        //public ICollection<Library> Libraries { get { return LibraryIdioms.Select(e => e.Library).ToList(); } }

        public ICollection<Library> GetLibraries()
        {
            return LibraryIdioms.Select(e => e.Library).ToList();
        }

        public ICollection<string> GetMeanings()
        {
            dynamic meanings = JsonConvert.DeserializeObject(this.Meaning);
            List<string> meaningList = new List<string>();

            foreach (var meaning in meanings)
            {
                if (meaning.ToString().Length == 0)
                {
                    continue;
                }
                meaningList.Add(HttpUtility.UrlDecode(meaning.ToString()));
            }

            return meaningList;
        }

        public string FormatMeaning()
        {
            dynamic meanings = JsonConvert.DeserializeObject(this.Meaning);
            StringBuilder stringBuilder = new StringBuilder();
            int i = 1;

            foreach (var meaning in meanings)
            {
                if (meaning.ToString().Length == 0)
                {
                    continue;
                }
                stringBuilder.Append($"<p>{i}. {HttpUtility.UrlDecode(meaning.ToString())}</p>");
                i++;
            }

            return stringBuilder.ToString();
        }

        public string GetDecodedMeaning()
        {
            return HttpUtility.UrlDecode(this.Meaning);
        }

        public string FormatExample()
        {
            dynamic examples = JsonConvert.DeserializeObject(this.Example);
            StringBuilder stringBuilder = new StringBuilder();
            int i = 1;

            foreach (var example in examples)
            {
                if (example.ToString().Length == 0)
                {
                    continue;
                }
                stringBuilder.Append($"<p>{i}. {HttpUtility.UrlDecode(example.ToString())}</p>");
                i++;
            }

            return stringBuilder.ToString();
        }

        public string FormatOrigin()
        {
            if (string.IsNullOrEmpty(this.Origin))
            {
                return "<p>-</p>";
            }


            return $"<p>{this.Origin}</p>";
        }

        public string FormatTags()
        {
            if (this.Tags is null || this.Tags.Count() == 0)
            {
                return string.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("<p><b>Check out the similar idioms: </b>");
            stringBuilder.Append("Check out the similar idioms: \n");

            foreach (var tag in this.Tags)
            {
                stringBuilder.Append($"<a href='/result?tags={tag.Name}' target='_blank'><u>{tag.Name}</u></a>\t");
                //stringBuilder.Append($"{tag.Name}\t");
            }

            //stringBuilder.Append("</p>");

            return stringBuilder.ToString();
        }

        public int GetFavouriteCount()
        {
            AmazengContext db = new AmazengContext();
            int count = 0;
            foreach (var member in db.Members)
            {
                var query = member.GetFavouriteLibrary().GetIdioms().Where(i => i.Id == this.Id);
                if (query != null && query.Any())
                {
                    count++;
                }
            }
            return count;
        }
    }
}