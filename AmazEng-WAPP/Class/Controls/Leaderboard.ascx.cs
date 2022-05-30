using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.Class.Controls
{
    public partial class Leaderboard : System.Web.UI.UserControl
    {

        public string CssClass { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AmazEng_WAPP.Models.Member> GridLeaderboard_GetData()
        {
            AmazengContext db = new AmazengContext();
            IQueryable<Member> query;

            query = db.Members.Where(m => m.DeletedAt == null).OrderByDescending(m => m.BrowsedIdiomCount).Take(10);
            var list = query.ToList();
            return query;
        }

        //protected void GridLeaderboard_DataBound(object sender, EventArgs e)
        //{
        //    GridLeaderboard.Sort("BrowsedIdiomCount", SortDirection.Descending);
        //}
    }
}