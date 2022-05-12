using AmazEng_WAPP.DataAccess;
using AmazEng_WAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmazEng_WAPP
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AmazengContext db = new AmazengContext();
            db.Messages.Add(new Message
            {
                IssuerName = txtName.Text,
                IssuerEmail = txtEmail.Text,
                Subject = txtSubject.Text,
                Content = txtMessage.Text,
                SentAt = DateTime.UtcNow
        });
            db.SaveChanges();
        }
    }
}