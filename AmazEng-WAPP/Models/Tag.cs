using AmazEng_WAPP.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Idiom> Idioms { get; set; }

        public static bool IsTagNameExisted(AmazengContext db, string name, int tagIdToExclude)
        {
            var query = db.Tags.Where(t =>
                t.Name == name &&
                t.Id != tagIdToExclude
            );
            return query.Any();
        }

        public static bool IsTagNameExisted(AmazengContext db, string name)
        {
            var query = db.Tags.Where(t =>
                t.Name == name
            );
            return query.Any();
        }
    }
}