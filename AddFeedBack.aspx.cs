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
    public partial class AddFeedBack : System.Web.UI.Page
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection con = new SqlConnection(connStr);
            string Fcomment = Comment.Text;
            SqlCommand Feedbackproc = new SqlCommand("addFeedback", con);
            Feedbackproc.Parameters.Add(new SqlParameter("comment", Fcomment));
            Feedbackproc.Parameters.Add(new SqlParameter("cid", Session["cid"]));
            Feedbackproc.Parameters.Add(new SqlParameter("sid", Session["id"]));
            Feedbackproc.CommandType = System.Data.CommandType.StoredProcedure;

            if (Fcomment.Equals(""))
            {
                Label lb = new Label();
                lb.Text = "please write your comment first";
                msg.Controls.Add(lb);
                return;
            }
            try
            {
                con.Open();
                Feedbackproc.ExecuteNonQuery();
                Label lb = new Label();
                lb.Text = "Feedback Added Successfully";
                msg.Controls.Add(lb);
            }
            catch(SqlException)
            {
                Label lb = new Label();
                lb.Text = "An error has occurred. Please consult the IT team.";
                msg.Controls.Add(lb);
            }
            con.Close();
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHomePage.aspx");
        }
    }
}