﻿using AmazEng_WAPP.DataAccess;
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
            txtSearch.Attributes.Add("onkeyup",
                @"setTimeout('__doPostBack(\'"
                    + txtSearch.ClientID.Replace("_", "$") +
                @"\',\'\')', 0);"
                );
        }

        public IQueryable<Member> GridMembers_GetData()
        {
            string searchKey = txtSearch.Text.ToLower();
            AmazengContext db = new AmazengContext();
            IQueryable<Member> query;

            if (string.IsNullOrEmpty(searchKey))
            {
                query = db.Members.Where(m => m.DeletedAt == null);
            }
            else
            {
                query = db.Members.Where(m => m.DeletedAt == null && (
                 m.Name.ToLower().Contains(searchKey) ||
                 m.Username.ToLower().Contains(searchKey) ||
                 m.Email.ToLower().Contains(searchKey)
             ));
            }

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

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridMembers.DataBind();
        }
    }
}