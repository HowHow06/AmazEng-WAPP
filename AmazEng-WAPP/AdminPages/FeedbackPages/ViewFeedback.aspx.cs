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

namespace AmazEng_WAPP.AdminPages.FeedbackPages
{
    public partial class ViewFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public AmazEng_WAPP.Models.Feedback FormFeedbackDetail_GetItem([RouteData] int? id)
        {
            if (id is null)
            {
                Response.Redirect(GetRouteUrl("AdminFeedbacksRoute", new { }));
                return null;
            }

            AmazengContext db = new AmazengContext();
            var feedback = db.Feedbacks.Find(id);

            if (feedback is null || feedback.DeletedAt != null)
            {
                Response.Redirect(GetRouteUrl("AdminFeedbacksRoute", new { }));
                return null;
            }
            return feedback;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var feedbackIdData = RouteData.Values["Id"];

            if (feedbackIdData is null)
            {
                return;
            }

            AmazengContext db = new AmazengContext();
            Feedback feedback;
            int feedbackId = Convert.ToInt32((string)feedbackIdData);

            feedback = db.Feedbacks.Find(feedbackId);

            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            Util.ShowAlertAndRedirect(Page, "Deleted Successfully!", GetRouteUrl("AdminFeedbacksRoute", new { }));
        }
    }
}