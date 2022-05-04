using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazEng_WAPP.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Idiom> Idioms { get; set; }
        public virtual ICollection<IdiomTag> IdiomTags { get; set; }

    }
}