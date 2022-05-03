using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}