using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class InstructorViewAcceptedCourses : System.Web.UI.Page
    {
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
            
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewCourseProc = new SqlCommand("InstructorViewAcceptedCoursesByAdmin", conn);

            viewCourseProc.Parameters.Add(new SqlParameter("@instrID", Session["id"]));
            viewCourseProc.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = viewCourseProc.ExecuteReader();
            int c = rdr.FieldCount;
            if (!rdr.HasRows)
            {
                Label lb = new Label();
                lb.Text = "No courses to show";
                msg.Controls.Add(lb);
                return;
            }
            while (rdr.Read())
            {
                Panel p = new Panel();
                Button b = new Button();
                b.Text = "View Course";
                b.Click += viewCoursePage;
                b.CssClass = "button";
                p.Controls.Add(b);
                for (int i = 0; i < 2; i++)
                {
                    string name = rdr.GetName(i);
                    Label l = new Label();
                    l.Text = name + " : " + rdr[name].ToString() + "\n";
                    p.Controls.Add(l);
                    if (i == 0) { 
                        b.ID = rdr[name].ToString();
                    }else if (i == 1)
                    {
                        b.Attributes.Add("cname", rdr[name].ToString());
                    }
                    
                }
                dataDiv.Controls.Add(p);

            }
            conn.Close();
        }

        protected void viewCoursePage(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            int i = int.Parse((sender as Button).ID.ToString());

            // THIS METHOD SHOULD REDIRECT TO THE SELECTED COURSE PAGE

            string name = b.Attributes["cname"];

            Session["cid"] = i;
            Session["cname"] = name;

            Response.Redirect("InstructorCoursePage.aspx");
       
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHomePage.aspx");
        }
    }
}