using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public string Pronunciation { get; set; }
        public int ViewCount { get; set; }//default 0
        public string Example { get; set; }
        public string Origin { get; set; }
        public DateTime? DeletedAt { get; set; }


        public virtual ICollection<LibraryIdiom> LibraryIdioms { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }

        //public ICollection<Library> Libraries { get { return LibraryIdioms.Select(e => e.Library).ToList(); } }

        public ICollection<Library> GetLibraries()
        {
            return LibraryIdioms.Select(e => e.Library).ToList();
        }
    }
}