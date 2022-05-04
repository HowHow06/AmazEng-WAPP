using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Models
{
    public class IdiomTag
    {
        [Key]
        [Column(Order = 1)]
        public int IdiomId { get; set; }
        public virtual Idiom Idiom { get; set; }
        [Key, Column(Order = 2)]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

    }
}