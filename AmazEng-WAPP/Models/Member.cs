using AmazEng_WAPP.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AmazEng_WAPP.Models
{
    public class Member : ICustomSoftDelete
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(80)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [StringLength(80)]
        public string Email { get; set; }
        [StringLength(255)]
        public string ProfilePicture { get; set; }
        public DateTime? LastLoginAt { get; set; }
        [StringLength(150)]
        public string RememberToken { get; set; }
        public DateTime? TokenExpiresAt { get; set; }
        public int BrowsedIdiomCount { get; set; }//default 0
        public DateTime? DeletedAt { get; set; }

        internal int GetTodayBrowsedToday()
        {
            return this.GetHistoryLibrary().LibraryIdioms.Where(li => li.AddedAt.ToLocalTime() > DateTime.Today).Count();
        }

        public virtual ICollection<Library> Libraries { get; set; }

        //public Member()
        //{

        //    List<Library> libraries = new List<Library>();

        //    libraries.Add(
        //        new Library
        //        {
        //            LibraryType = LibraryType.GetFavouriteLibraryType(),
        //            Member = this,
        //        }
        //    );
        //    libraries.Add(
        //        new Library
        //        {
        //            LibraryType = LibraryType.GetHistoryLibraryType(),
        //            Member = this,
        //        }
        //    );
        //    libraries.Add(
        //        new Library
        //        {
        //            LibraryType = LibraryType.GetLearnLaterLibraryType(),
        //            Member = this,
        //        }
        //    );

        //    this.Libraries = libraries;
        //}

        public Library GetFavouriteLibrary()
        {
            return this.Libraries.Where(l => l.LibraryTypeId == LibraryType.GetFavouriteLibraryType().Id).First();
        }

        public Library GetHistoryLibrary()
        {
            return this.Libraries.Where(l => l.LibraryTypeId == LibraryType.GetHistoryLibraryType().Id).First();
        }

        public Library GetLearnLaterLibrary()
        {
            return this.Libraries.Where(l => l.LibraryTypeId == LibraryType.GetLearnLaterLibraryType().Id).First();
        }

        internal void ToggleIdiomInFavouriteLibrary(Idiom idiom, AmazengContext db)
        {
            Library favouriteLibrary = this.GetFavouriteLibrary();
            bool isFavourite = favouriteLibrary.IsIdiomInLibrary(idiom.Id);

            if (isFavourite)
            {
                favouriteLibrary.RemoveIdiom(idiom, db);
                return;
            }
            favouriteLibrary.AddIdiom(idiom, db);
        }

        internal void ToggleIdiomInLearnLaterLibrary(Idiom idiom, AmazengContext db)
        {
            Library learnLaterLibrary = this.GetLearnLaterLibrary();
            bool isLearnLater = learnLaterLibrary.IsIdiomInLibrary(idiom.Id);

            if (isLearnLater)
            {
                learnLaterLibrary.RemoveIdiom(idiom, db);
                return;
            }
            learnLaterLibrary.AddIdiom(idiom, db);
        }
    }
}