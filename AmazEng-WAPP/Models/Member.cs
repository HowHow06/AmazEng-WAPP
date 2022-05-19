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
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string RememberToken { get; set; }
        public DateTime? TokenExpiresAt { get; set; }
        public int BrowsedIdiomCount { get; set; }//default 0
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }

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
    }
}