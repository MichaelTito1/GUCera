using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class InstructorViewFeedback : System.Web.UI.Page
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

            courseData.Text = Session["cid"].ToString() + " " + Session["cname"].ToString();

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewFeedProc = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);

            viewFeedProc.Parameters.AddWithValue("@instrId", Session["id"]);
            viewFeedProc.Parameters.AddWithValue("@cid", Session["cid"]);
            viewFeedProc.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = viewFeedProc.ExecuteReader();
            int c = rdr.FieldCount;
            int j = 0;
            while (rdr.Read())
            {
                TableRow tr = new TableRow();
                
                
                for(int i = 0; i < c; i++)
                {
                    string colName = rdr.GetName(i);
                    Label lb = new Label();
                    lb.ID = "row" + j + "_col" + i;
                    lb.Text = rdr[colName].ToString();
                    TableCell tc = new TableCell();
                    tc.Controls.Add(lb);
                    tr.Cells.Add(tc);
                }
                feedTable.Rows.Add(tr);
            }
            conn.Close();
        }
        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHomePage.aspx");
        }
    }
}
