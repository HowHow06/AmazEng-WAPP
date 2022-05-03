using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Models
{
    [Table("Quizzes")]
    public class Quiz : ICustomSoftDelete, IHasTimeStamp
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MemberId { get; set; }
        public int PlayCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<Idiom> Idioms { get; set; }
    }
}