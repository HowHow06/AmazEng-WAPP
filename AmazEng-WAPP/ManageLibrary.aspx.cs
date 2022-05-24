using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class ManageLibrary : System.Web.UI.Page
    {
        public int totalHistoryCount = 0;
        public int totalFavouriteCount = 0;
        public int totalLearnLaterCount = 0;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<AmazEng_WAPP.Models.Idiom> GridHistory_GetData()
        {
            //string searchKey = Request.QueryString["q"] is null ? string.Empty : Request.QueryString["q"].ToString();
            //string tagsKey = Request.QueryString["tags"] is null ? string.Empty : Request.QueryString["tags"].ToString();
            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            IQueryable<Idiom> query = member.GetHistoryLibrary().GetIdioms().AsQueryable();

            //searchKey = searchKey.ToLower();
            //if (!string.IsNullOrEmpty(searchKey))
            //{
            //    query = query.Where(i => i.Name.ToLower().Contains(searchKey) || i.Meaning.ToLower().Contains(searchKey));
            //}

            //if (!string.IsNullOrEmpty(tagsKey))
            //{
            //    List<String> tags = tagsKey.Split(',').ToList();
            //    query = query.Where(i => i.Tags.Where(t => tags.Contains(t.Name)).Any());
            //}

            totalHistoryCount = query.Count();
            return query;
        }

        protected void GridHistory_DataBound(object sender, EventArgs e)
        {
            int currentCount = GridHistory.PageSize > totalHistoryCount ? totalHistoryCount : GridHistory.PageSize;
            int currentPageIndex = GridHistory.PageIndex + 1;
            int fristItemIndex = totalHistoryCount != 0 ? (currentPageIndex - 1) * GridHistory.PageSize + 1 : 0;
            lblHistoryCount.Text = $"Showing {fristItemIndex}-{currentCount * currentPageIndex} of {totalHistoryCount} results.";
        }
        public IQueryable<AmazEng_WAPP.Models.Idiom> GridFavourite_GetData()
        {
            //string searchKey = Request.QueryString["q"] is null ? string.Empty : Request.QueryString["q"].ToString();
            //string tagsKey = Request.QueryString["tags"] is null ? string.Empty : Request.QueryString["tags"].ToString();
            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            IQueryable<Idiom> query = member.GetFavouriteLibrary().GetIdioms().AsQueryable();

            //searchKey = searchKey.ToLower();
            //if (!string.IsNullOrEmpty(searchKey))
            //{
            //    query = query.Where(i => i.Name.ToLower().Contains(searchKey) || i.Meaning.ToLower().Contains(searchKey));
            //}

            //if (!string.IsNullOrEmpty(tagsKey))
            //{
            //    List<String> tags = tagsKey.Split(',').ToList();
            //    query = query.Where(i => i.Tags.Where(t => tags.Contains(t.Name)).Any());
            //}

            totalFavouriteCount = query.Count();
            return query;
        }

        protected void GridFavourite_DataBound(object sender, EventArgs e)
        {
            int currentCount = GridFavourite.PageSize > totalFavouriteCount ? totalFavouriteCount : GridFavourite.PageSize;
            int currentPageIndex = GridFavourite.PageIndex + 1;
            int fristItemIndex = totalFavouriteCount != 0 ? (currentPageIndex - 1) * GridFavourite.PageSize + 1 : 0;
            lblFavouriteCount.Text = $"Showing {fristItemIndex}-{currentCount * currentPageIndex} of {totalFavouriteCount} results.";
        }
        public IQueryable<AmazEng_WAPP.Models.Idiom> GridLearnLater_GetData()
        {
            //string searchKey = Request.QueryString["q"] is null ? string.Empty : Request.QueryString["q"].ToString();
            //string tagsKey = Request.QueryString["tags"] is null ? string.Empty : Request.QueryString["tags"].ToString();
            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            IQueryable<Idiom> query = member.GetLearnLaterLibrary().GetIdioms().AsQueryable();

            //searchKey = searchKey.ToLower();
            //if (!string.IsNullOrEmpty(searchKey))
            //{
            //    query = query.Where(i => i.Name.ToLower().Contains(searchKey) || i.Meaning.ToLower().Contains(searchKey));
            //}

            //if (!string.IsNullOrEmpty(tagsKey))
            //{
            //    List<String> tags = tagsKey.Split(',').ToList();
            //    query = query.Where(i => i.Tags.Where(t => tags.Contains(t.Name)).Any());
            //}

            totalLearnLaterCount = query.Count();
            return query;
        }

        protected void GridLearnLater_DataBound(object sender, EventArgs e)
        {
            int currentCount = GridLearnLater.PageSize > totalLearnLaterCount ? totalLearnLaterCount : GridLearnLater.PageSize;
            int currentPageIndex = GridLearnLater.PageIndex + 1;
            int fristItemIndex = totalLearnLaterCount != 0 ? (currentPageIndex - 1) * GridLearnLater.PageSize + 1 : 0;
            lblLearnLaterCount.Text = $"Showing {fristItemIndex}-{currentCount * currentPageIndex} of {totalLearnLaterCount} results.";
        }

        protected void GridLearnLater_PageIndexChanged(object sender, EventArgs e)
        {
            //GridLearnLater.PageIndex = e.;
            //54           bindmygrd()
        }
    }
}