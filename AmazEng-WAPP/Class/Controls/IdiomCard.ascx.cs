using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.Class.Controls
{
    public partial class IdiomCard : System.Web.UI.UserControl
    {
        public int IdiomId { get; set; }
        public Idiom Idiom { get; set; }
        public string CssClass { get; set; }
        public Member Member { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && IdiomId > 0)
            {
                AmazengContext db = new AmazengContext();
                Idiom = db.Idioms.Find(IdiomId);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            AmazengContext db = new AmazengContext();
            SetThisIdiom(db);
            RenderMeaningPreview();
            RefreshFavrouriteAndLearnLaterIcon(db);
        }

        private void SetThisIdiom(AmazengContext db)
        {
            int idiomId;
            if (IsPostBack)
            {
                idiomId = Convert.ToInt32(hdnIdiomId.Value);
            }
            else
            {
                idiomId = IdiomId;
            }
            Idiom = db.Idioms.Find(idiomId);
        }

        private void RenderMeaningPreview()
        {
            // add to meaning preview
            HtmlGenericControl meaningControl = new HtmlGenericControl("span");
            meaningControl.InnerText = Idiom.GetMeanings().First();
            phMeaning.Controls.Add(meaningControl);
        }

        protected void RefreshFavrouriteAndLearnLaterIcon(AmazengContext db)
        {
            bool isFavourite = false;
            bool isLearnLater = false;
            if (Request.IsAuthenticated)
            {
                Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
                isFavourite = member.GetFavouriteLibrary().IsIdiomInLibrary(Idiom.Id);
                isLearnLater = member.GetLearnLaterLibrary().IsIdiomInLibrary(Idiom.Id);

            }

            if (isFavourite)
            {
                iIsFavourite.Visible = true;
                iIsNotFavourite.Visible = false;
            }
            else
            {
                iIsFavourite.Visible = false;
                iIsNotFavourite.Visible = true;
            }

            if (isLearnLater)
            {
                iIsLearnLater.Visible = true;
                iIsNotLearnLater.Visible = false;
            }
            else
            {
                iIsLearnLater.Visible = false;
                iIsNotLearnLater.Visible = true;
            }

        }

        protected void btnFavourite_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/login?alert");
                return;
            }

            var btn = (LinkButton)sender;
            int idiomId = Convert.ToInt32(btn.CommandArgument);

            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            member.ToggleIdiomInFavouriteLibrary(db.Idioms.Find(idiomId), db);
        }

        protected void btnLearnLater_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/login?alert");
                return;
            }

            var btn = (LinkButton)sender;
            int idiomId = Convert.ToInt32(btn.CommandArgument);

            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            member.ToggleIdiomInLearnLaterLibrary(db.Idioms.Find(idiomId), db);
        }
    }
}