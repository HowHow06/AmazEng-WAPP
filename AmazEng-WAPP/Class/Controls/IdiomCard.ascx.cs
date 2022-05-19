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
        public bool IsFavourite { get; set; }
        public bool IsLearnLater { get; set; }
        public string CssClass { get; set; }
        public Member Member { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            Idiom = db.Idioms.Find(IdiomId);

            // add to meaning preview
            HtmlGenericControl meaningControl = new HtmlGenericControl("span");
            meaningControl.InnerText = Idiom.GetMeanings().First();
            phMeaning.Controls.Add(meaningControl);

            Util.LogOutput("testing");

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            RefreshFavrouriteAndLearnLaterIcon(db);
        }

        protected void RefreshFavrouriteAndLearnLaterIcon(AmazengContext db)
        {
            if (Request.IsAuthenticated)
            {
                Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
                IsFavourite = member.GetFavouriteLibrary().IsIdiomInLibrary(Idiom.Id);
                IsLearnLater = member.GetLearnLaterLibrary().IsIdiomInLibrary(Idiom.Id);
            }

            if (IsFavourite)
            {
                iIsFavourite.Visible = true;
                iIsNotFavourite.Visible = false;
            }
            else
            {
                iIsFavourite.Visible = false;
                iIsNotFavourite.Visible = true;
            }

            if (IsLearnLater)
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
                Response.Redirect(GetRouteUrl("LoginRoute", new { }));
                return;
            }

            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            Library favouriteLibrary = member.GetFavouriteLibrary();
            IsFavourite = favouriteLibrary.IsIdiomInLibrary(Idiom.Id);

            if (IsFavourite)
            {
                Util.LogOutput("removingasdas ");
                favouriteLibrary.RemoveIdiom(Idiom, db);
            }
            else
            {
                Util.LogOutput("creatingasdasd ");
                favouriteLibrary.AddIdiom(Idiom, db);

            }
        }

        protected void btnLearnLater_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect(GetRouteUrl("LoginRoute", new { }));
                return;
            }

            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            Library learnLaterLibrary = member.GetLearnLaterLibrary();
            IsLearnLater = learnLaterLibrary.IsIdiomInLibrary(Idiom.Id);

            if (IsLearnLater)
            {
                Util.LogOutput("removing ");
                learnLaterLibrary.RemoveIdiom(Idiom, db);
                return;
            }
            Util.LogOutput("creating");
            learnLaterLibrary.AddIdiom(Idiom, db);
        }
    }
}