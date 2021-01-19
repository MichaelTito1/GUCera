using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!Session["userType"].ToString().Equals("admin"))
                {
                    Response.Redirect("NotAccessiblePage.aspx");
                }
                fname.Text = Session["fname"].ToString();
            }
        }

        protected void ViewCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllCourses.aspx");
        }

        protected void NotAcceptedCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllNonAcceptedCourses.aspx");
        }

        protected void Promo_Click(object sender, EventArgs e)
        {
            Response.Redirect("PromoCodeCreation.aspx");
        }

        protected void Issue_Click(object sender, EventArgs e)
        {
            Response.Redirect("IssuePromo.aspx");
        }

       

        protected void Addmob_Click(object sender, EventArgs e)
        {
            Response.Redirect("addPhone.aspx");
        }
        protected void logoutClick(object sender, EventArgs e)
        {
            Session["id"] = null;
            Session["userType"] = null;
            Session["fname"] = "";
            Response.Redirect("login.aspx");
        }
    }
}