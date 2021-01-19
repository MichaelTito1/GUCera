using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class StudentHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!Session["userType"].ToString().Equals("student"))
                {
                    Response.Redirect("NotAccessiblePage.aspx");
                }
                fname.Text = Session["fname"].ToString();
            }
        }

        protected void addPhone_Click(object sender, EventArgs e)
        {
            Response.Redirect("addPhone.aspx");
        }

        protected void profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentProfile.aspx");
        }

        protected void coursesToEnroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("availableCourses.aspx");
        }

        protected void creditCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreditCard.aspx");
        }

        protected void promo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPromoCode.aspx");
        }
        protected void enrolled_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnrolledCourses.aspx");
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