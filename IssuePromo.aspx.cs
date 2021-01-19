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
    public partial class IssuePromo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"]==null)
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
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }
        protected void IssueP_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection con = new SqlConnection(connStr);
            string Pcode = Code.Text;
            string PstudentID = StudentID.Text;
            bool flag = false;

            SqlCommand IssuePromoProc = new SqlCommand("AdminIssuePromocodeToStudent", con);

            IssuePromoProc.Parameters.Add(new SqlParameter("pid", Pcode));
            IssuePromoProc.Parameters.Add(new SqlParameter("sid", PstudentID));
            IssuePromoProc.CommandType = System.Data.CommandType.StoredProcedure;

            if (Pcode.Equals("") || PstudentID.Equals(""))
            {
                Label l = new Label();
                l.Text = "You must fill in the boxes marked with *";
                msg.Controls.Add(l);
                    return;
            }

            con.Open();
            try
            {
                IssuePromoProc.ExecuteNonQuery();
                Label l = new Label();
                l.Text = "PromoCode Issued Successfuly!";
                msg.Controls.Add(l);
            }
            catch (SqlException)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * from StudentHasPromocode";
                cmd.Connection = con;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr[0].ToString().Equals(PstudentID) && rdr[1].Equals(Pcode))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    Label l = new Label();
                    l.Text = "This code is already issued to this student";
                    msg.Controls.Add(l);

                 }
                else
                {
                    Label l = new Label();
                    l.Text = "You should issue an existing code to an existing student id";
                    msg.Controls.Add(l);
                }
            }
            con.Close();


        }
    }
}