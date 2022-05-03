using System;
using System.ComponentModel.DataAnnotations;

namespace AmazEng_WAPP.Models
{
    public class Message : ICustomSoftDelete
    {
        [Key, Required]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string IssuerName { get; set; }
        public string IssuerEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public DateTime SentAt { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual Member Member { get; set; }

    }
}