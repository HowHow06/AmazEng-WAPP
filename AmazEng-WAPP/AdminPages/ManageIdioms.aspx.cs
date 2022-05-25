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

namespace AmazEng_WAPP.AdminPages
{
    public partial class ManageIdioms : System.Web.UI.Page
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
            int pageSize = GridIdioms.PageSize;
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
        public IQueryable<AmazEng_WAPP.Models.Idiom> GridIdioms_GetData()
        {
            string searchKey = txtSearch.Text.ToLower();
            AmazengContext db = new AmazengContext();
            IQueryable<Idiom> query;

            if (string.IsNullOrEmpty(searchKey))
            {
                query = db.Idioms.Where(m => m.DeletedAt == null);
            }
            else
            {
                query = db.Idioms.Where(m => m.DeletedAt == null && (
                 m.Name.ToLower().Contains(searchKey) ||
                 m.Meaning.ToLower().Contains(searchKey)
             ));
            }

            return query;
        }

        protected void GridIdioms_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //handling gridview delete excetion
            e.ExceptionHandled = true;

        }

        protected void GridIdioms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                AmazengContext db = new AmazengContext();
                int idiomId = Convert.ToInt32(e.CommandArgument.ToString());
                Idiom toDeleteIdiom = db.Idioms.Find(idiomId);
                db.Idioms.Remove(toDeleteIdiom);
                db.SaveChanges();

                ////refresh grid
                //GridMembers.DataBind();

                // reload page

                Util.ShowAlertAndRedirect(Page, "Deleted Successfully!", Request.RawUrl);
                //Response.Redirect(Request.RawUrl);
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridIdioms.DataBind();
        }

        protected void anchorShow_Click(object sender, EventArgs e)
        {
            var btn = sender as LinkButton;
            string pageSize = btn.CommandArgument;
            GridIdioms.PageSize = Convert.ToInt32(pageSize);
            CheckPageSizeButtonControl(btn, Convert.ToInt32(pageSize));
        }
    }
}