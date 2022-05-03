using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazEng_WAPP.Models
{
    internal interface IHasTimeStamp
    {
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
    }
}
