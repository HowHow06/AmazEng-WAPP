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
    public partial class ManageMessages : System.Web.UI.Page
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
            int pageSize = GridMessages.PageSize;
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
        public IQueryable<AmazEng_WAPP.Models.Message> GridMessages_GetData()
        {
            string searchKey = txtSearch.Text.ToLower();
            AmazengContext db = new AmazengContext();
            IQueryable<AmazEng_WAPP.Models.Message> query;

            if (string.IsNullOrEmpty(searchKey))
            {
                query = db.Messages.Where(m => m.DeletedAt == null);
            }
            else
            {
                query = db.Messages.Where(m => m.DeletedAt == null && (
                 m.IssuerName.ToLower().Contains(searchKey) ||
                 m.IssuerEmail.ToLower().Contains(searchKey) ||
                 m.Subject.ToLower().Contains(searchKey)
             ));
            }

            return query;
        }

        protected void GridMessages_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

            //handling gridview delete excetion
            e.ExceptionHandled = true;
        }

        protected void GridMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                AmazengContext db = new AmazengContext();
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                AmazEng_WAPP.Models.Message toDeleteMessage = db.Messages.Find(id);
                db.Messages.Remove(toDeleteMessage);
                db.SaveChanges();

                ////refresh grid
                //GridMembers.DataBind();

                // reload page
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridMessages.DataBind();
        }

        protected void anchorShow_Click(object sender, EventArgs e)
        {
            var btn = sender as LinkButton;
            string pageSize = btn.CommandArgument;
            GridMessages.PageSize = Convert.ToInt32(pageSize);
            CheckPageSizeButtonControl(btn, Convert.ToInt32(pageSize));
        }
    }
}