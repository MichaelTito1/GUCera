using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace GUCera
{
    public partial class InstructorHomePage : System.Web.UI.Page
    {
        DataTable dt;
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
            fname.Text = Session["fname"].ToString();
        }

        protected void addCourse(object sender, EventArgs e)
        {            
            Response.Redirect("AddCoursePage.aspx");

        }

        protected void viewAcceptedCourses(object sender, EventArgs e)
        {
            Response.Redirect("InstructorViewAcceptedCourses.aspx");
        }

        // NOT WORKING!!!!!!!
        protected void viewCoursePage(object sender, EventArgs e)
        {
            // THIS METHOD SHOULD REDIRECT TO THE SELECTED COURSE PAGE
            int i = int.Parse((sender as Button).Text[1].ToString());
            int cid = int.Parse(dt.Rows[i].Field<int>("id").ToString());
            string name = dt.Rows[i].Field<string>("name").ToString();
            //MessageBox.Show(cid.ToString()); // SHOWS NOTHING?!!!

            Session["cid"] = cid;
            Session["cname"] = name;

            Response.Write("dajssnd;jabs");
            //Response.Redirect("InstructorCoursePage.aspx");
            //Response.Redirect("InstructorCoursePage.aspx?cid= " + cid + "name= "+name);
        }

        protected void defineAssignments(object sender, EventArgs e)
        {
            Response.Redirect("InstructorDefineAssignment.aspx");
        }

        protected void myProfile(object sender, EventArgs e)
        {
            Response.Redirect("InstructorProfile.aspx");
        }

        protected void addPhone_Click(object sender, EventArgs e)
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