using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AmazEng_WAPP.Models
{
    public class Library
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int LibraryTypeId { get; set; }

        public virtual LibraryType LibraryType { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<LibraryIdiom> LibraryIdioms { get; set; }

        // shorter way to retrieve idioms
        //public ICollection<Idiom> Idioms { get { return LibraryIdioms.Select(e => e.Idiom).ToList(); } }
        public ICollection<Idiom> GetIdioms()
        {
            return LibraryIdioms.Select(e => e.Idiom).ToList();
        }
    }
}