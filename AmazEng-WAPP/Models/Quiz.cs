using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Models
{
    [Table("Quizzes")]
    public class Quiz : ICustomSoftDelete, IHasTimeStamp
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int PlayCount { get; set; } //default 0
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<Idiom> Idioms { get; set; }

    }
}