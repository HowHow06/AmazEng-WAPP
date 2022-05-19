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
            if (Request.IsAuthenticated)
            {
                Member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
                IsFavourite = Member.GetFavouriteLibrary().GetIdioms().Contains(Idiom);
                IsLearnLater = Member.GetLearnLaterLibrary().GetIdioms().Contains(Idiom);
            }

            Idiom = db.Idioms.Find(IdiomId);

            HtmlGenericControl meaningControl = new HtmlGenericControl("span");
            meaningControl.InnerText = Idiom.GetMeanings().First();
            phMeaning.Controls.Add(meaningControl);
            Util.LogOutput(IsFavourite.ToString());
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
            Library favouriteLibrary = Member.GetFavouriteLibrary();
            //if (favouriteLibrary.LibraryIdioms is null)
            //{
            //    favouriteLibrary.LibraryIdioms = new List<LibraryIdiom>();
            //}

            //favouriteLibrary.LibraryIdioms.Add(
            //    new LibraryIdiom
            //    {
            //        IdiomId = Idiom.Id,
            //        LibraryId = favouriteLibrary.Id
            //    }
            //    );
            //Util.LogOutput("saving...");
            //db.SaveChanges();
        }

        protected void btnLearnLater_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect(GetRouteUrl("LoginRoute", new { }));
                return;
            }
        }
    }
}