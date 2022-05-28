using System;
using System.ComponentModel.DataAnnotations;

namespace AmazEng_WAPP.Models
{
    public class Message : ICustomSoftDelete
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string IssuerName { get; set; }
        [Required]
        [StringLength(50)]
        public string IssuerEmail { get; set; }
        [Required]
        [StringLength(255)]
        public string Subject { get; set; }
        [Required]
        public DateTime SentAt { get; set; }
        [Required]
        [StringLength(3000)]
        public string Content { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}