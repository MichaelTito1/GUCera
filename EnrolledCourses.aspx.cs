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
    public partial class EnrolledCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Session["userType"].ToString().Equals("student"))
            {
                Response.Redirect("NotAccessiblePage.aspx");
            }



            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("SELECT c.name,c.id FROM StudentTakeCourse sc inner join Course c on sc.cid=c.id where sc.sid=@x;", conn);
            cmd.Parameters.Add("@x", Session["id"]);

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Panel p = new Panel();
                Label l = new Label();
                l.Text = rdr.GetString(0);
                Button va = new Button();
                va.Click += viewAssignment;
                va.Attributes.Add("cid", rdr[rdr.GetName(1)].ToString());
                va.Text = "View Assignments";
                Button fb = new Button();
                fb.Attributes.Add("cid", rdr[rdr.GetName(1)].ToString());
                fb.Click += feedback;
                fb.Text = "FeedBack";
                Button cert = new Button();
                cert.Attributes.Add("cid", rdr[rdr.GetName(1)].ToString());
                cert.Click += certificate;
                cert.Text = "certificate";

                p.Controls.Add(l);
                p.Controls.Add(va);
                p.Controls.Add(fb);
                p.Controls.Add(cert);
                form1.Controls.Add(p);
            }
            conn.Close();
        }
        protected void viewAssignment(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int cid = int.Parse(b.Attributes["cid"]);
            Session["cid"] = cid;
            Response.Redirect("AssignmentPage.aspx");
        }
        protected void feedback(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int cid = int.Parse(b.Attributes["cid"]);
            Session["cid"] = cid;
            Response.Redirect("AddFeedBack.aspx");
        }
        protected void certificate(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int cid = int.Parse(b.Attributes["cid"]);
            Session["cid"] = cid;
            Response.Redirect("Certificates.aspx");
        }
    }
}