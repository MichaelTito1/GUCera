using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class InstructorCoursePage : System.Web.UI.Page
    {
        int cid;
        string cname;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Session["userType"].ToString().Equals("instructor"))
            {
                Response.Redirect("NotAccessiblePage.aspx");
            }
            if (Session["cid"] == null)
            {
                Response.Redirect("InstructorHomePage.aspx");
            }
            cid = int.Parse(Session["cid"].ToString());
            cname = Session["cname"].ToString();
            
            courseData.Text = cid.ToString() + " " + cname;

            fname.Text = Session["fname"].ToString();
        }

        protected void viewFeedback(object sender, EventArgs e)
        {
            Response.Redirect("InstructorViewFeedback.aspx");
        }

        protected void viewAssignments(object sender, EventArgs e)
        {
            Response.Redirect("InstructorViewAssignment.aspx");
        }

        protected void defineAssignments(object sender, EventArgs e)
        {
            Response.Redirect("InstructorDefineAssignment.aspx");
        }

        protected void issueCertificate(object sender, EventArgs e)
        {
            Response.Redirect("InstructorIssueCertificate.aspx");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHomePage.aspx");
        }

        protected void backClick(object sender, EventArgs e)
        {
            Session.Remove("cid");
            Session.Remove("cname");
            Response.Redirect("InstructorViewAcceptedCourses.aspx");
        }
    }
}