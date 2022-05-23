using AmazEng_WAPP.Class.Utils;
using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP.AdminPages.MessagePages
{
    public partial class ViewMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public AmazEng_WAPP.Models.Message FormMessageDetail_GetItem([RouteData] int? id)
        {
            if (id is null)
            {
                Response.Redirect(GetRouteUrl("AdminMessagesRoute", new { }));
                return null;
            }

            AmazengContext db = new AmazengContext();
            var message = db.Messages.Find(id);

            if (message is null || message.DeletedAt != null)
            {
                Response.Redirect(GetRouteUrl("AdminMessagesRoute", new { }));
                return null;
            }
            return message;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var messageIdData = RouteData.Values["Id"];

            if (messageIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Message message;
            int messageId = Convert.ToInt32((string)messageIdData);

            message = db.Messages.Find(messageId);

            db.Messages.Remove(message);
            db.SaveChanges();
            Util.ShowAlertAndRedirect(Page, "Deleted Successfully!", GetRouteUrl("AdminMessagesRoute", new { }));
        }


    }
}