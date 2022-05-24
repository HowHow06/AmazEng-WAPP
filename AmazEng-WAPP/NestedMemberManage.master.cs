using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class NestedMemberManage : System.Web.UI.MasterPage
    {
        public Member Member { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect(GetRouteUrl("LoginRoute", new { }));
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            SetCurrentMember();
            RenderBadgeColor();
            RenderProfilePicture();
        }

        private void RenderProfilePicture()
        {
            if (!string.IsNullOrEmpty(Member.ProfilePicture))
            {
                imgProfilePicture.ImageUrl = Member.ProfilePicture;
            }
        }

        private void RenderBadgeColor()
        {
            string badge = Member.BrowsedIdiomCount > 50 ? "Gold" : Member.BrowsedIdiomCount > 20 ? "Silver" : "Bronze";

            string color = badge;
            string badgeName = $"{badge} Badge";
            if (badge == "Bronze")
            {
                color = "rgb(255, 87, 51)";
            }

            spnBadge.Attributes.Add("style", $"color: {color}");
            spnBadge.Attributes.Add("title", badgeName);
        }

        private void SetCurrentMember()
        {
            AmazengContext db = new AmazengContext();
            Member = db.GetMemberByUsername(HttpContext.Current.User.Identity.Name);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //sign out from form authentication
            FormsAuthentication.SignOut();
            //refresh
            Response.Redirect(Request.RawUrl);
        }
    }
}