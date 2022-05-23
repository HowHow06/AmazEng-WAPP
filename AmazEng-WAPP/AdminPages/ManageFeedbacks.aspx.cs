using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages
{
    public partial class ManageFeedbacks : System.Web.UI.Page
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
            int pageSize = GridFeedbacks.PageSize;
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

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AmazEng_WAPP.Models.Feedback> GridFeedbacks_GetData()
        {
            string searchKey = txtSearch.Text.ToLower();
            AmazengContext db = new AmazengContext();
            IQueryable<AmazEng_WAPP.Models.Feedback> query;

            if (string.IsNullOrEmpty(searchKey))
            {
                query = db.Feedbacks.Where(m => m.DeletedAt == null);
            }
            else
            {
                query = db.Feedbacks.Where(m => m.DeletedAt == null && (
                 m.IssuerName.ToLower().Contains(searchKey) ||
                 m.IssuerEmail.ToLower().Contains(searchKey) ||
                 m.Idiom.Name.ToLower().Contains(searchKey)
             ));
            }

            return query;
        }

        protected void GridFeedbacks_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //handling gridview delete excetion
            e.ExceptionHandled = true;
        }

        protected void GridFeedbacks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                AmazengContext db = new AmazengContext();
                int feedbackId = Convert.ToInt32(e.CommandArgument.ToString());
                AmazEng_WAPP.Models.Feedback toDeleteFeedback = db.Feedbacks.Find(feedbackId);
                db.Feedbacks.Remove(toDeleteFeedback);
                db.SaveChanges();

                ////refresh grid
                //GridMembers.DataBind();

                // reload page
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridFeedbacks.DataBind();
        }

        protected void anchorShow_Click(object sender, EventArgs e)
        {
            var btn = sender as LinkButton;
            string pageSize = btn.CommandArgument;
            GridFeedbacks.PageSize = Convert.ToInt32(pageSize);
            CheckPageSizeButtonControl(btn, Convert.ToInt32(pageSize));
        }
    }
}