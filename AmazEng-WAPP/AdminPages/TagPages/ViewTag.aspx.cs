using AmazEng_WAPP.Class.Auth;
using AmazEng_WAPP.Class.Services;
using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages.TagPages
{
    public partial class ViewTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                FormTagDetail.ChangeMode(FormViewMode.Edit);
                return;
            }

            if (string.Equals(mode, "new", StringComparison.OrdinalIgnoreCase))
            {
                //is edit mode
                FormTagDetail.ChangeMode(FormViewMode.Insert);
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public AmazEng_WAPP.Models.Tag FormTagDetail_GetItem([RouteData] int? id)
        {
            if (id is null)
            {
                Response.Redirect(GetRouteUrl("AdminTagsRoute", new { }));
                return null;
            }

            AmazengContext db = new AmazengContext();
            var tag = db.Tags.Find(id);


            return tag;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            var tagIdData = RouteData.Values["Id"];

            if (tagIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Tag tag;
            int tagId = Convert.ToInt32((string)tagIdData);
            var txtEditName = FormTagDetail.FindControl("txtEditName") as TextBox;

            tag = db.Tags.Find(tagId);
            tag.Name = txtEditName.Text;

            db.SaveChanges();
            Util.ShowAlertAndRedirect(Page, "Edited Successfully!", GetRouteUrl("AdminViewTagRoute", new { Id = tagId }));
            //Response.Redirect(GetRouteUrl("AdminViewMemberRoute", new { Id = tagId }));
            return;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var tagIdData = RouteData.Values["Id"];

            if (tagIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Tag tag;
            int tagId = Convert.ToInt32((string)tagIdData);

            tag = db.Tags.Find(tagId);

            db.Tags.Remove(tag);
            db.SaveChanges();
            Util.ShowAlertAndRedirect(Page, "Deleted Successfully!", GetRouteUrl("AdminTagsRoute", new { }));
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
            {
                return;
            }
            AmazengContext db = new AmazengContext();
            Tag tag;
            var txtNewName = FormTagDetail.FindControl("txtNewName") as TextBox;

            db.Tags.Add(
                new Tag
                {
                    Name = txtNewName.Text,
                }
                );

            db.SaveChanges();
            tag = db.Tags.Where(t => t.Name == txtNewName.Text).First();
            Response.Redirect(GetRouteUrl("AdminViewTagRoute", new { Id = tag.Id, Mode = string.Empty }));
            return;
        }

        protected void validatorName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string name = args.Value;
            int tagId = Convert.ToInt32((string)RouteData.Values["Id"]);
            AmazengContext db = new AmazengContext();
            db.Tags.Where(t => t.Name == args.Value).Any();
            bool isNameRegistered = Tag.IsTagNameExisted(db, name, tagId);
            var validator = FormTagDetail.FindControl("validatorName") as CustomValidator;
            var controlToValidate = FormTagDetail.FindControl(validator.ControlToValidate) as TextBox;

            if (isNameRegistered)
            {  //name invalid
                Util.ShowAlert(this, "This name is used by other tag.");
                controlToValidate.Attributes.Add("class", "form-control error");
                validator.Attributes.Add("class", "invalid-feedback d-inline");
                args.IsValid = false;
                return;
            }
            controlToValidate.Attributes.Add("class", "form-control");
            validator.Attributes.Add("class", "invalid-feedback");
            args.IsValid = true;
        }

        protected void validatorNewName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string name = args.Value;
            AmazengContext db = new AmazengContext();
            bool isNameRegistered = Tag.IsTagNameExisted(db, name);
            var validator = FormTagDetail.FindControl("validatorNewTag") as CustomValidator;
            var controlToValidate = FormTagDetail.FindControl(validator.ControlToValidate) as TextBox;

            if (isNameRegistered)
            {  //name invalid
                Util.ShowAlert(this, "This name is used by other tag.");
                controlToValidate.Attributes.Add("class", "form-control error");
                validator.Attributes.Add("class", "invalid-feedback d-inline");
                args.IsValid = false;
                return;
            }
            controlToValidate.Attributes.Add("class", "form-control");
            validator.Attributes.Add("class", "invalid-feedback");
            args.IsValid = true;
        }

    }
}

