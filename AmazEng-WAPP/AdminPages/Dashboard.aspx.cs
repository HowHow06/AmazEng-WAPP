using AmazEng_WAPP.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext(); ;
            RenderTotalIdiomViewCount(db);
            RenderTotalMemberCount(db);
            RenderActiveMemberCount(db);
            RenderCuurentMonthYear();
        }

        private void RenderCuurentMonthYear()
        {
            string currentMonthYear = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month)} {DateTime.Now.Year}";
            lblCurrentMonthYear1.Text = currentMonthYear;
            lblCurrentMonthYear2.Text = currentMonthYear;
            lblCurrentMonthYear3.Text = currentMonthYear;
        }

        private void RenderTotalMemberCount(AmazengContext db)
        {
            lblMemberCount.Text = db.Members.Count().ToString();
        }

        private void RenderActiveMemberCount(AmazengContext db)
        {
            lblActiveMemberCount.Text = db.Members.Where(m =>
                !m.DeletedAt.HasValue &&
                m.LastLoginAt.HasValue &&
                m.LastLoginAt.Value.Month == DateTime.UtcNow.Month
            ).Count().ToString();
        }

        private void RenderTotalIdiomViewCount(AmazengContext db)
        {
            lblTotalIdiomViewCount.Text = db.Idioms.Sum(i => i.ViewCount).ToString();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AmazEng_WAPP.Models.Idiom> GridMostViewIdiom_GetData()
        {
            AmazengContext db = new AmazengContext();
            var query = db.Idioms.OrderByDescending(i => i.ViewCount).Take(10);
            return query;
        }
    }
}