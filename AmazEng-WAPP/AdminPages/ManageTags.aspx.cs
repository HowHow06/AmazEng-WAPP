using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages
{
    public partial class ManageTags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onkeyup",
                @"setTimeout('__doPostBack(\'"
                    + txtSearch.ClientID.Replace("_", "$") +
                @"\',\'\')', 0);"
                );
            if (!IsPostBack)
            {
                CheckSelectPageSize();
            }
        }

        protected void CheckSelectPageSize()
        {
            int pageSize = GridTags.PageSize;
            string pageSizeAnchorId = $"anchorShow{pageSize}";

            var control = pageSizePicker.FindControl(pageSizeAnchorId);
            CheckPageSizeButtonControl(control, pageSize);
        }

        protected void CheckPageSizeButtonControl(Control control, int pageSize)
        {
            HtmlGenericControl svg = Util.CreateCheckSvgControl();
            HtmlGenericControl pageSizeSpan = new HtmlGenericControl("span");
            pageSizeSpan.InnerText = pageSize.ToString();

            control.Controls.Add(pageSizeSpan);
            control.Controls.Add(svg);
        }

        public IQueryable<Tag> GridTags_GetData()
        {
            string searchKey = txtSearch.Text.ToLower();
            AmazengContext db = new AmazengContext();
            IQueryable<Tag> query;

            query = db.Tags.Where(
                 t => t.Name.ToLower().Contains(searchKey));


            return query;
        }

        protected void GridTags_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //handling gridview delete excetion
            e.ExceptionHandled = true;
        }

        protected void GridTags_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                AmazengContext db = new AmazengContext();
                int tagId = Convert.ToInt32(e.CommandArgument.ToString());
                System.Diagnostics.Debug.WriteLine($"Removing tag {tagId}");
                Tag toDeleteTag = db.Tags.Find(tagId);
                db.Tags.Remove(toDeleteTag);
                db.SaveChanges();

                ////refresh grid
                //GridTags.DataBind();

                // reload page
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridTags.DataBind();
        }

        protected void anchorShow_Click(object sender, EventArgs e)
        {
            var btn = sender as LinkButton;
            string pageSize = btn.CommandArgument;
            GridTags.PageSize = Convert.ToInt32(pageSize);
            CheckPageSizeButtonControl(btn, Convert.ToInt32(pageSize));
        }
    }
}