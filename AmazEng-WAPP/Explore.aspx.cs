﻿using AmazEng_WAPP.Class.Utils;
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
    public partial class Explore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateAndDisplayRandomIdiom();
            }

            if (Request.IsAuthenticated)
            {
                AmazengContext db = new AmazengContext();
                Member member = db.GetMemberByUsername(User.Identity.Name);
                lblViewCount.Text = member.GetTodayBrowsedToday().ToString();
                lblViewCountStatement.Visible = true;
            }
            BindDataToRepeater();
        }

        private void GenerateAndDisplayRandomIdiom()
        {
            Idiom idiom = GetRandomIdiom();
            lblIdiomOfTheDay.Text = Util.CapitalizeFirstLetter(idiom.Name);
            lblIdiomMeaning.Text = idiom.GetMeanings().First();
        }

        private Idiom GetRandomIdiom()
        {
            AmazengContext db = new AmazengContext();
            Random rand = new Random();
            int toSkip = rand.Next(1, db.Idioms.Count());

            return db.Idioms.OrderBy(i => i.Id).Skip(toSkip).Take(1).First();
        }

        private void BindDataToRepeater()
        {
            AmazengContext db = new AmazengContext();
            repeaterIdioms.DataSource = db.Idioms.Take(4).ToList();
            repeaterIdioms.DataBind();
        }

        protected void btnRegenerateIdiom_Click(object sender, EventArgs e)
        {
            GenerateAndDisplayRandomIdiom();
        }
    }
}