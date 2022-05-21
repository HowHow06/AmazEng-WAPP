using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class IdiomDetail : System.Web.UI.Page
    {
        public Idiom Idiom { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var idRouteData = RouteData.Values["Id"];
            if (idRouteData is null)
            {
                Response.Redirect(GetRouteUrl("ResultRoute", new { }));
                return;
            }
            AmazengContext db = new AmazengContext();
            Idiom = db.Idioms.Find(Convert.ToInt32(idRouteData));
            //AmazengContext db = new AmazengContext();
            this.Title = Idiom.Name;
            Util.LogOutput("load");


            if (!IsPostBack)
            {
                TryAddIdiomToMemberHistory(db);
            }

        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            RefreshFavrouriteAndLearnLaterIcon(db);
            RenderFavouriteCount();
            RenderPronunciation();
            RenderIdiomName();
            RenderMeaning();
            RenderExample();
            RenderOrigin();
            RenderTags();
            RenderButtonCommandArgument();
            Util.LogOutput("render");
        }

        private void RenderButtonCommandArgument()
        {
            btnFavourite.CommandArgument = Idiom.Id.ToString();
            btnLearnLater.CommandArgument = Idiom.Id.ToString();
        }

        private void RenderIdiomName()
        {
            lblIdiomName.Text = Util.CapitalizeFirstLetter(Idiom.Name);
        }

        private void TryAddIdiomToMemberHistory(AmazengContext db)
        {
            if (!Request.IsAuthenticated)
            {
                return;
            }
            Member member = db.GetMemberByUsername(User.Identity.Name);
            if (member == null)
            {
                return;
            }

            var query = member.GetHistoryLibrary().LibraryIdioms.Where(li => li.IdiomId == Idiom.Id);
            if (query.Any())
            {
                LibraryIdiom existingLibraryIdiom = query.First();
                existingLibraryIdiom.AddedAt = DateTime.UtcNow;
                db.SaveChanges();
                Util.LogOutput("Updated to history");
            }
            else
            {
                member.GetHistoryLibrary().AddIdiom(Idiom, db);
                Util.LogOutput("Added to history");
            }
            member.BrowsedIdiomCount++;
            db.SaveChanges();

        }

        private void RenderFavouriteCount()
        {
            lblFavouriteCount.Text = Idiom.GetFavouriteCount().ToString();
            return;
        }

        private void RenderPronunciation()
        {
            if (string.IsNullOrEmpty(Idiom.Pronunciation))
            {
                return;
            }

            HtmlGenericControl control = new HtmlGenericControl("p");
            control.InnerText = "How to pronounce?";
            HtmlGenericControl audioControl = new HtmlGenericControl("audio");
            audioControl.Attributes.Add("src", Idiom.Pronunciation);
            audioControl.Attributes.Add("type", "audio/mpeg");
            audioControl.Attributes.Add("preload", "none");
            audioControl.Attributes.Add("controls", "");
            audioControl.InnerText = "Your browser does not support audio.";



            phPronunciation.Controls.Add(control);
            phPronunciation.Controls.Add(audioControl);
        }

        private void RenderOrigin()
        {
            HtmlGenericControl control = new HtmlGenericControl("p");
            control.InnerHtml = Idiom.FormatOrigin();

            phOrigin.Controls.Add(control);
        }

        private void RenderExample()
        {
            HtmlGenericControl control = new HtmlGenericControl();
            control.InnerHtml = Idiom.FormatExample();

            phExample.Controls.Add(control);
        }

        private void RenderMeaning()
        {
            HtmlGenericControl control = new HtmlGenericControl();
            control.InnerHtml = Idiom.FormatMeaning();

            phMeaning.Controls.Add(control);
        }

        private void RenderTags()
        {
            HtmlGenericControl tagsControl = new HtmlGenericControl();
            tagsControl.InnerHtml = Idiom.FormatTags();

            phTags.Controls.Add(tagsControl);
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

        //// The id parameter should match the DataKeyNames value set on the control
        //// or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public AmazEng_WAPP.Models.Idiom FormIdiom_GetItem([RouteData] int? id)
        //{
        //    if (id is null)
        //    {
        //        Response.Redirect(GetRouteUrl("ExploreRoute", new { }));
        //        return null;
        //    }

        //    AmazengContext db = new AmazengContext();
        //    var idiom = db.Idioms.Find(id);

        //    if (idiom is null)
        //    {
        //        Response.Redirect(GetRouteUrl("ExploreRoute", new { }));
        //        return null;
        //    }

        //    return idiom;
        //}

        protected void btnFavourite_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                string returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
                Response.Redirect($"/login?alert=true&ReturnUrl={returnUrl}");
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
                string returnUrl = Server.UrlEncode(Request.Url.PathAndQuery);
                Response.Redirect($"/login?alert=true&ReturnUrl={returnUrl}");
                return;
            }

            var btn = (LinkButton)sender;
            int idiomId = Convert.ToInt32(btn.CommandArgument);

            AmazengContext db = new AmazengContext();
            Member member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
            member.ToggleIdiomInLearnLaterLibrary(db.Idioms.Find(idiomId), db);
        }


        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            var txtName = txtReportName;
            var txtEmail = txtReportEmail;
            var txtDescription = txtReportDescription;

            string name = txtName.Text;
            string email = txtEmail.Text;
            string description = txtDescription.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(description))
            {
                Util.ShowAlert(this, "Please fill in all the fields.");
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                Util.ShowAlert(this, "Please fill in a valid email.");
                return;
            }

            AmazengContext db = new AmazengContext();
            db.Feedbacks.Add(
                new Feedback
                {
                    IssuerName = name,
                    IssuerEmail = email,
                    Content = description,
                    IdiomId = Idiom.Id,
                    SentAt = DateTime.UtcNow
                }
                );

            db.SaveChanges();
            Util.ShowAlert(this, "Thank you for your feedback, a message is sent to admin to address this problem.");

        }
    }
}