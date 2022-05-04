using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Models
{
    public class QuizIdiom
    {
        [Key]
        [Column(Order = 1)]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
        [Key, Column(Order = 2)]
        public int IdiomId { get; set; }
        public virtual Idiom Idiom { get; set; }
    }
}