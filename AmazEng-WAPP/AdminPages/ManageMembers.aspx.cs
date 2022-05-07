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
            var query = db.Members;
            return query;
        }
    }
}