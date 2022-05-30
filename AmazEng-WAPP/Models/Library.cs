using AmazEng_WAPP.DataAccess;
using System;
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

        internal void AddIdiom(Idiom idiom, AmazengContext db)
        {
            if (this.LibraryIdioms is null)
            {
                this.LibraryIdioms = new List<LibraryIdiom>();
            }
            if (this.IsIdiomInLibrary(idiom.Id))
            {
                var libraryIdiom = this.LibraryIdioms.Where(i => i != null && i.IdiomId == idiom.Id).First();
                libraryIdiom.AddedAt = DateTime.UtcNow;
            }
            else
            {
                this.LibraryIdioms.Add(
                   new LibraryIdiom
                   {
                       IdiomId = idiom.Id,
                       LibraryId = this.Id
                   }
                   );
            }

            db.SaveChanges();
        }

        internal void RemoveIdiom(Idiom idiom, AmazengContext db)
        {
            if (this.LibraryIdioms is null)
            {
                this.LibraryIdioms = new List<LibraryIdiom>();
            }
            this.LibraryIdioms.Remove(this.LibraryIdioms.Where(li => li.IdiomId == idiom.Id).First());
            db.SaveChanges();
        }

        internal bool IsIdiomInLibrary(int idiomId)
        {
            var idioms = this.GetIdioms();
            if (!idioms.Any())
            {
                return false;
            }
            return idioms.Where(i => i != null && i.Id == idiomId).Any();
        }
    }
}