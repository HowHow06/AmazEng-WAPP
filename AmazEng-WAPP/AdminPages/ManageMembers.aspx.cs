using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages
{
    public partial class ManageMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Member> GridMembers_GetData()
        {
            AmazengContext db = new AmazengContext();
            var query = db.Members.Where(m => m.DeletedAt == null);
            return query;
        }

        protected void GridMembers_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //handling gridview delete excetion
            e.ExceptionHandled = true;
        }

        protected void GridMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                AmazengContext db = new AmazengContext();
                int memberId = Convert.ToInt32(e.CommandArgument.ToString());
                System.Diagnostics.Debug.WriteLine($"Removing member {memberId}");
                Member toDeleteMember = db.Members.Find(memberId);
                db.Members.Remove(toDeleteMember);
                db.SaveChanges();

                ////refresh grid
                //GridMembers.DataBind();

                // reload page
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}