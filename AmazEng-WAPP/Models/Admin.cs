using System;
using System.ComponentModel.DataAnnotations;

namespace AmazEng_WAPP.Models
{
    public class Admin : ICustomSoftDelete
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(80)]
        public string Username { get; set; }
        [Required]
        [StringLength(80)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(255)]
        public string ProfilePicture { get; set; }
        public DateTime? LastLoginAt { get; set; }
        [StringLength(150)]
        public string RememberToken { get; set; }
        public DateTime? TokenExpiresAt { get; set; }
        [Required]
        public int RoleId { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual AdminRole Role { get; set; }
    }

}