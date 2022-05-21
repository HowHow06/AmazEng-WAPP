using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages.IdiomPages
{
    public partial class ViewIdiom : System.Web.UI.Page
    {
        public Idiom Idiom { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            SelectMode();
            if (FormIdiomDetail.CurrentMode != FormViewMode.Insert)
            {
                SetCurrentIdiom();
            }
            if (FormIdiomDetail.CurrentMode == FormViewMode.ReadOnly)
            {
                RenderViewMeaning();
                RenderViewExample();
                RenderViewPronunciation();
                RenderViewTags();
            }

            if (FormIdiomDetail.CurrentMode == FormViewMode.Edit && !IsPostBack)
            {
                RenderEditTags();
            }

            if (FormIdiomDetail.CurrentMode == FormViewMode.Insert && !IsPostBack)
            {
                RenderEditTags();
            }
        }

        private void RenderEditTagsValue()
        {
            var literalControl = FormIdiomDetail.FindControl("lblEditDisplayTags") as Literal;
            var control = FormIdiomDetail.FindControl("lstEditTags") as ListBox;
            StringBuilder str = new StringBuilder();

            //linq query to get all selected items from listbox
            var items = from ListItem li in control.Items
                        where li.Selected == true
                        select li;

            foreach (ListItem li in items)
            {
                str.Append($"{li.Text },\t");
            }

            str.Remove(str.Length - 2, 2);
            literalControl.Text = str.ToString();
        }

        private void RenderEditTags()
        {
            AmazengContext db = new AmazengContext();
            var control = FormIdiomDetail.FindControl("lstEditTags") as ListBox;
            control.DataSource = db.Tags.OrderBy(t => t.Name).ToList();
            control.DataTextField = "Name";
            control.DataValueField = "Id";
            control.DataBind();

            List<Tag> tags = Idiom.Tags.ToList();
            foreach (ListItem item in control.Items)
            {
                if (!tags.Where(t => t.Id.ToString() == item.Value).Any())
                {
                    continue;
                }
                item.Selected = true;
            }

            //RenderEditTagsValue();
        }

        private void RenderViewTags()
        {
            var tags = Idiom.Tags;
            if (tags is null || tags.Count() == 0)
            {
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var tag in tags)
            {
                stringBuilder.Append($"{tag.Name},");
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            var lblViewTags = FormIdiomDetail.FindControl("lblViewTags") as Literal;
            lblViewTags.Text = stringBuilder.ToString();
        }

        private void RenderViewPronunciation()
        {
            string pronunciation = Idiom.Pronunciation;
            var phViewPronunciation = FormIdiomDetail.FindControl("phViewPronunciation") as PlaceHolder;

            if (string.IsNullOrEmpty(pronunciation))
            {
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.Attributes.Add("class", "form-text");
                p.InnerText = "-";
                phViewPronunciation.Controls.Add(p);
                return;
            }

            HtmlGenericControl audioControl = new HtmlGenericControl("audio");
            audioControl.Attributes.Add("src", Idiom.Pronunciation);
            audioControl.Attributes.Add("type", "audio/mpeg");
            audioControl.Attributes.Add("preload", "none");
            audioControl.Attributes.Add("controls", "");
            audioControl.InnerText = "Your browser does not support audio.";

            phViewPronunciation.Controls.Add(audioControl);
        }

        private void RenderViewExample()
        {
            List<string> examples = Idiom.GetExamples().ToList();
            foreach (string example in examples)
            {
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.Attributes.Add("class", "form-text");
                p.InnerText = example;
                FormIdiomDetail.FindControl("phViewExample").Controls.Add(p);
            }
        }

        private void SelectMode()
        {
            var modeRouteData = RouteData.Values["Mode"];
            string mode = "";
            if (modeRouteData is object)
            {
                mode = modeRouteData.ToString();
            }

            if (string.Equals(mode, "edit", StringComparison.OrdinalIgnoreCase))
            {
                //is edit mode
                FormIdiomDetail.ChangeMode(FormViewMode.Edit);
                return;
            }

            if (string.Equals(mode, "new", StringComparison.OrdinalIgnoreCase))
            {
                //is edit mode
                FormIdiomDetail.ChangeMode(FormViewMode.Insert);
            }
        }

        private void SetCurrentIdiom()
        {
            var idRouteData = RouteData.Values["Id"];
            int id;
            if (idRouteData is null)
            {
                Response.Redirect(GetRouteUrl("AdminViewIdiomRoute", new { id = 1 }));
                //Response.Redirect(GetRouteUrl("AdminIdiomsRoute", new { }));
                return;
            }

            id = Convert.ToInt32(idRouteData.ToString());

            AmazengContext db = new AmazengContext();
            var idiom = db.Idioms.Find(id);

            if (idiom is null || idiom.DeletedAt != null)
            {
                Response.Redirect(GetRouteUrl("AdminIdiomsRoute", new { }));
                return;
            }
            Idiom = idiom;
        }

        private void RenderViewMeaning()
        {
            List<string> meanings = Idiom.GetMeanings().ToList();
            foreach (string meaning in meanings)
            {
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.Attributes.Add("class", "form-text");
                p.InnerText = meaning;
                FormIdiomDetail.FindControl("phViewMeaning").Controls.Add(p);
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public AmazEng_WAPP.Models.Idiom FormIdiomDetail_GetItem([RouteData] int? id)
        {
            if (id is null)
            {
                Response.Redirect(GetRouteUrl("AdminIdiomsRoute", new { }));
                return null;
            }

            AmazengContext db = new AmazengContext();
            var idiom = db.Idioms.Find(id);

            if (idiom is null || idiom.DeletedAt != null)
            {
                Response.Redirect(GetRouteUrl("AdminIdiomsRoute", new { }));
                return null;
            }
            return idiom;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var idiomIdData = RouteData.Values["Id"];

            if (idiomIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Idiom idiom;
            int idiomId = Convert.ToInt32((string)idiomIdData);

            idiom = db.Idioms.Find(idiomId);

            db.Idioms.Remove(idiom);
            db.SaveChanges();
            Util.ShowAlertAndRedirect(Page, "Deleted Successfully!", GetRouteUrl("AdminIdiomsRoute", new { }));
        }

        protected void lstEditTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            Util.LogOutput("asdasd");
            RenderEditTagsValue();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            AmazengContext db = new AmazengContext();
            Idiom idiom;
            List<Tag> tags = new List<Tag>();
            var uploadEditPronunciation = FormIdiomDetail.FindControl("uploadEditPronunciation") as FileUpload;
            var txtEditName = FormIdiomDetail.FindControl("txtEditName") as TextBox;
            var txtEditOrigin = FormIdiomDetail.FindControl("txtEditOrigin") as TextBox;
            var txtEditMeaning = FormIdiomDetail.FindControl("txtEditMeaning") as TextBox;
            var txtEditExample = FormIdiomDetail.FindControl("txtEditExample") as TextBox;
            var lstEditTags = FormIdiomDetail.FindControl("lstEditTags") as ListBox;
            string profileImagePath = null;
            string meaning = txtEditMeaning.Text;
            string example = txtEditExample.Text;
            string formattedMeaning = "";
            string formattedExample = "";


            if (uploadEditPronunciation.HasFile)
            {
                string str = uploadEditPronunciation.FileName;
                profileImagePath = $"/Public/Uploads/Pronunciation/{str}";
                uploadEditPronunciation.PostedFile.SaveAs(Server.MapPath("~" + profileImagePath));
            }

            if (!string.IsNullOrEmpty(meaning))
            {
                formattedMeaning = FormatToJsonString(meaning);
            }

            if (!string.IsNullOrEmpty(example))
            {
                formattedExample = FormatToJsonString(example);
            }

            //linq query to get all selected items from listbox
            var items = from ListItem li in lstEditTags.Items
                        where li.Selected == true
                        select li;

            foreach (ListItem li in items)
            {
                tags.Add(db.Tags.Find(Convert.ToInt32(li.Value)));
            }


            idiom = db.Idioms.Find(Idiom.Id);
            idiom.Name = txtEditName.Text;
            idiom.Origin = txtEditOrigin.Text;
            idiom.Meaning = formattedMeaning;
            idiom.Example = formattedExample;
            idiom.Tags.Clear();
            idiom.Tags = tags;
            idiom.Pronunciation = profileImagePath ?? idiom.Pronunciation;
            db.SaveChanges();
            Response.Redirect(GetRouteUrl("AdminViewIdiomRoute", new { Id = idiom.Id }));
            return;
        }

        private string FormatToJsonString(string meaning)
        {
            return JsonConvert.SerializeObject(meaning.Split('\n').ToList());
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            AmazengContext db = new AmazengContext();
            Idiom idiom;
            List<Tag> tags = new List<Tag>();
            var uploadNewPronunciation = FormIdiomDetail.FindControl("uploadNewPronunciation") as FileUpload;
            var txtNewName = FormIdiomDetail.FindControl("txtNewName") as TextBox;
            var txtNewOrigin = FormIdiomDetail.FindControl("txtNewOrigin") as TextBox;
            var txtNewMeaning = FormIdiomDetail.FindControl("txtNewMeaning") as TextBox;
            var txtNewExample = FormIdiomDetail.FindControl("txtNewExample") as TextBox;
            var lstNewTags = FormIdiomDetail.FindControl("lstNewTags") as ListBox;
            string profileImagePath = null;
            string meaning = txtNewMeaning.Text;
            string example = txtNewExample.Text;
            string formattedMeaning = "";
            string formattedExample = "";


            if (uploadNewPronunciation.HasFile)
            {
                string str = uploadNewPronunciation.FileName;
                profileImagePath = $"/Public/Uploads/Pronunciation/{str}";
                uploadNewPronunciation.PostedFile.SaveAs(Server.MapPath("~" + profileImagePath));
            }

            if (!string.IsNullOrEmpty(meaning))
            {
                formattedMeaning = FormatToJsonString(meaning);
            }

            if (!string.IsNullOrEmpty(example))
            {
                formattedExample = FormatToJsonString(example);
            }

            //linq query to get all selected items from listbox
            var items = from ListItem li in lstNewTags.Items
                        where li.Selected == true
                        select li;

            foreach (ListItem li in items)
            {
                tags.Add(db.Tags.Find(Convert.ToInt32(li.Value)));
            }


            idiom = new Idiom();
            idiom.Name = txtNewName.Text;
            idiom.Origin = txtNewOrigin.Text;
            idiom.Meaning = formattedMeaning;
            idiom.Example = formattedExample;
            if (idiom.Tags is object)
            {
                idiom.Tags.Clear();
            }
            idiom.Tags = tags;
            idiom.Pronunciation = profileImagePath ?? idiom.Pronunciation;
            db.Idioms.Add(idiom);
            db.SaveChanges();
            idiom = db.Idioms.Where(i => i.Name == txtNewName.Text).First();
            Response.Redirect(GetRouteUrl("AdminViewIdiomRoute", new { Id = idiom.Id, Mode = string.Empty }));
            return;
        }
    }
}