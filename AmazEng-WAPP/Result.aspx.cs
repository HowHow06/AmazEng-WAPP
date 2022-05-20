using AmazEng_WAPP.Class.Utils;
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
        int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AmazEng_WAPP.Models.Idiom> GridIdioms_GetData()
        {
            string searchKey = Request.QueryString["q"] is null ? string.Empty : Request.QueryString["q"].ToString();
            string tagsKey = Request.QueryString["tags"] is null ? string.Empty : Request.QueryString["tags"].ToString();
            AmazengContext db = new AmazengContext();
            IQueryable<Idiom> query = db.Idioms;
            searchKey = searchKey.ToLower();
            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(i => i.Name.ToLower().Contains(searchKey) || i.Meaning.ToLower().Contains(searchKey));
            }

            if (!string.IsNullOrEmpty(tagsKey))
            {
                List<String> tags = tagsKey.Split(',').ToList();
                query = query.Where(i => i.Tags.Where(t => tags.Contains(t.Name)).Any());
            }

            totalCount = query.Count();
            return query;
        }

        protected void GridIdioms_DataBound(object sender, EventArgs e)
        {
            int currentCount = GridIdioms.PageSize > totalCount ? totalCount : GridIdioms.PageSize;
            int currentPageIndex = GridIdioms.PageIndex + 1;
            int fristItemIndex = totalCount != 0 ? (currentPageIndex - 1) * GridIdioms.PageSize + 1 : 0;
            lblResultCount.Text = $"Showing {fristItemIndex}-{currentCount * currentPageIndex} of {totalCount} results.";
        }
    }
}