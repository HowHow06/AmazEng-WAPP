using AmazEng_WAPP.DataAccess;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AmazEng_WAPP.Models
{
    public class LibraryType
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Library> Libraries { get; set; }

        public static LibraryType GetFavouriteLibraryType()
        {
            return new AmazengContext().LibraryTypes.Where(lt => lt.Name == "Favourite").First();
        }

        public static LibraryType GetHistoryLibraryType()
        {
            return new AmazengContext().LibraryTypes.Where(lt => lt.Name == "History").First();
        }

        public static LibraryType GetLearnLaterLibraryType()
        {
            return new AmazengContext().LibraryTypes.Where(lt => lt.Name == "LearnLater").First();
        }
    }
}