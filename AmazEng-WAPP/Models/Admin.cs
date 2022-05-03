using System;
using System.ComponentModel.DataAnnotations;

namespace AmazEng_WAPP.Models
{
    public class Admin : ICustomSoftDelete
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        [Required]
        public int RoleId { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual AdminRole Role { get; set; }
    }

}