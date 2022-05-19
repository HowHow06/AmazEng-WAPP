using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AmazEng_WAPP.Models.Idiom> GridIdioms_GetData([RouteData] string searchKey)
        {
            AmazengContext db = new AmazengContext();
            if (string.IsNullOrEmpty(searchKey))
            {
                return db.Idioms;
            }

            return db.Idioms.Where(i => i.Name.ToLower().Contains(searchKey.ToLower()));
        }
    }
}