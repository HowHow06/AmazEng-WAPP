using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Models
{
    public class LibraryIdiom
    {
        [Key]
        [Column(Order = 1)]
        public int LibraryId { get; set; }
        [Key, Column(Order = 2)]
        public int IdiomId { get; set; }
        [Required]
        public DateTime AddedAt { get; set; }

        public virtual Library Library { get; set; }
        public virtual Idiom Idiom { get; set; }
    }
}