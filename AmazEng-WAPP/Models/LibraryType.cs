using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazEng_WAPP.Models
{
    public class LibraryType
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Library> Libraries { get; set; }
    }
}