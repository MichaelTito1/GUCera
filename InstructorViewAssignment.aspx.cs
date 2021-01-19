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
    public partial class InstructorViewAssignment : System.Web.UI.Page
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
            SqlCommand viewAssignProc = new SqlCommand("InstructorViewAssignmentsStudents", conn);

            viewAssignProc.Parameters.AddWithValue("@instrId", Session["id"]);
            viewAssignProc.Parameters.AddWithValue("@cid", Session["cid"]);
            viewAssignProc.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = viewAssignProc.ExecuteReader();
            int c = rdr.FieldCount;
            int j = 0;
            while (rdr.Read())
            {
                TableRow tr = new TableRow();


                for (int i = 0; i < c; i++)
                {
                    string colName = rdr.GetName(i);
                    TableCell tc = new TableCell();

                    if (i < c - 1)
                    {
                        Label lb = new Label();
                        lb.ID = "row" + j + "_col" + i;
                        lb.Text = rdr[colName].ToString();
                        tc.Text = lb.ID;
                        tc.Controls.Add(lb);
                        
                    }
                    else
                    {
                        TextBox tb = new TextBox();
                        tb.ID = "txtbox"+rdr["sid"].ToString();
                        tb.Text = rdr[rdr.GetName(c-1)].ToString();
                        tc.Controls.Add(tb);
                        Button btn = new Button();
                        btn.Text = "Enter";
                        btn.Click += btnClick;
                        btn.Attributes.Add("sid", rdr["sid"].ToString());
                        btn.Attributes.Add("assNum", rdr["assignmentNumber"].ToString());
                        btn.Attributes.Add("assType", rdr["assignmenttype"].ToString());
                        tc.Controls.Add(btn);
                    }
                    tr.Cells.Add(tc);
                }
                feedTable.Rows.Add(tr);
            }
            conn.Close();
        }

        protected void btnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int sid = int.Parse(btn.Attributes["sid"]);
            int assNum = int.Parse(btn.Attributes["assNum"]);
            string assType = btn.Attributes["assType"];
            TextBox tb = (this.feedTable.FindControl("txtbox" + sid.ToString())) as TextBox;
            
            
            
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand gradeAssign = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
            gradeAssign.CommandType = CommandType.StoredProcedure;

            string gr = tb.Text;
            if(gr.Length == 0)
            {
                Label lb = new Label();
                lb.Text = "Student grade can't be left empty.";
                msg.Controls.Add(lb);
                return;
            }

            gradeAssign.Parameters.AddWithValue("@instrId", Session["id"]);
            gradeAssign.Parameters.AddWithValue("@cid", Session["cid"]);
            gradeAssign.Parameters.AddWithValue("@sid",sid);
            gradeAssign.Parameters.AddWithValue("@assignmentNumber",assNum );
            gradeAssign.Parameters.AddWithValue("@type",assType);
            try
            {
                gradeAssign.Parameters.AddWithValue("@grade",double.Parse(gr));
            }catch(FormatException ex)
            {
                Label lb = new Label();
                lb.Text = "Please enter the grade in the correct format.";
                msg.Controls.Add(lb);
                return;
            }
            catch(Exception ex)
            {
                Label lb = new Label();
                lb.Text = "An error has occurred. Please consult the IT team.";
                msg.Controls.Add(lb);
                return;
            }

            conn.Open();
            try
            {
                gradeAssign.ExecuteNonQuery();
                Label lb = new Label();
                lb.Text = "Grade Added Succesfully.";
                msg.Controls.Add(lb);
                return;
            }catch(SqlException ex)
            {
                Label lb = new Label();
                lb.Text = "An error has occurred. Please consult the IT team.";
                msg.Controls.Add(lb);
                return;
            }
            

        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHomePage.aspx");
        }
    }
}