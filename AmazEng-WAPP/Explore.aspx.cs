using AmazEng_WAPP.Class.Utils;
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
    public partial class Explore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateAndDisplayRandomIdiom();
            }

            if (Request.IsAuthenticated)
            {
                AmazengContext db = new AmazengContext();
                Member member = db.GetMemberByUsername(User.Identity.Name);
                lblViewCount.Text = member.GetTodayBrowsedToday().ToString();
                lblViewCountStatement.Visible = true;
            }
            BindDataToRepeater();
            txtSearchKey.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "')");
        }

        private void GenerateAndDisplayRandomIdiom()
        {
            AmazengContext db = new AmazengContext();
            Idiom idiom = Idiom.GetRandomIdiom(db);
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.InnerText = Util.CapitalizeFirstLetter(idiom.Name);
            a.Attributes.Add("href", $"/idiom/{idiom.Id}");
            a.Attributes.Add("class", $"on-hover-current-color on-hover-underline");
            phIdiomOfTheDay.Controls.Add(a);
            lblIdiomMeaning.Text = idiom.GetMeanings().First();
        }

        private void BindDataToRepeater()
        {
            AmazengContext db = new AmazengContext();
            repeaterIdioms.DataSource = db.Idioms.Take(4).ToList();
            repeaterIdioms.DataBind();
        }

        protected void btnRegenerateIdiom_Click(object sender, EventArgs e)
        {
            GenerateAndDisplayRandomIdiom();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKey = txtSearchKey.Text;
            Response.Redirect($"/result?q={searchKey}");
        }
    }
}