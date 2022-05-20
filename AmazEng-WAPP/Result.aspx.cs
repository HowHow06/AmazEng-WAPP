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
            //BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            string searchKey = Request.QueryString["q"] is null ? string.Empty : Request.QueryString["q"].ToString();
            AmazengContext db = new AmazengContext();
            List<Idiom> idioms;
            int currentPageIndex = GridIdioms.PageIndex == 0 ? 1 : GridIdioms.PageIndex;
            int currentPageSize = GridIdioms.PageSize;

            if (string.IsNullOrEmpty(searchKey))
            {
                idioms = db.Idioms.ToList();
                //idioms = db.Idioms.OrderBy(i => i.Id).Skip((currentPageIndex - 1) * currentPageSize).Take(currentPageSize).ToList();
            }
            else
            {
                idioms = db.Idioms.Where(i => i.Name.ToLower().Contains(searchKey.ToLower())).ToList();
                //idioms = db.Idioms.Where(i => i.Name.ToLower().Contains(searchKey.ToLower())).OrderBy(i => i.Id).Skip((currentPageIndex - 1) * currentPageSize).Take(currentPageSize).ToList();
            }
            GridIdioms.DataSource = idioms;
            GridIdioms.DataBind();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AmazEng_WAPP.Models.Idiom> GridIdioms_GetData([RouteData] string SearchKey)
        {
            string searchKey = Request.QueryString["q"] is null ? string.Empty : Request.QueryString["q"].ToString();
            string tagsKey = Request.QueryString["tags"] is null ? string.Empty : Request.QueryString["tags"].ToString();
            AmazengContext db = new AmazengContext();
            IQueryable<Idiom> query = db.Idioms;
            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(i => i.Name.ToLower().Contains(searchKey.ToLower()));
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
            lblResultCount.Text = $"Showing {(currentPageIndex - 1) * GridIdioms.PageSize + 1}-{currentCount * currentPageIndex} of {totalCount} results.";
        }
    }
}