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
    public partial class AssignmentPage : System.Web.UI.Page
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
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand assignmentsProc = new SqlCommand("viewAssign", con);
            assignmentsProc.Parameters.Add(new SqlParameter("@courseId", Session["cid"]));
            assignmentsProc.Parameters.Add(new SqlParameter("@Sid", Session["id"]));
            assignmentsProc.CommandType = CommandType.StoredProcedure;

            TextBox a = new TextBox();
            a.Text = "Number";
            TextBox b = new TextBox();
            b.Text = "Type";
            TextBox c = new TextBox();
            c.Text = "fullGrade";
            TextBox d = new TextBox();
            d.Text = "Weight";
            TextBox f = new TextBox();
            f.Text = "Deadline";
            TextBox g = new TextBox();
            g.Text = "Content";
            TextBox h = new TextBox();
            h.Text = "Grade";
            form1.Controls.Add(a);
            form1.Controls.Add(b);
            form1.Controls.Add(c);
            form1.Controls.Add(d);
            form1.Controls.Add(f);
            form1.Controls.Add(g);
            form1.Controls.Add(h);
            form1.Controls.Add(new Literal() { Text = "<br>" });

            

            con.Open();
            SqlDataReader rdr = assignmentsProc.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    int number = (int) rdr.GetValue(1);
                    TextBox l = new TextBox();
                    l.Text = number.ToString();
                    l.ReadOnly = true;
                    TextBox k = new TextBox();
                    try
                    {
                        string type = (string)rdr.GetValue(2);
                        k.Text = type+"";
                    }
                    catch
                    {
                        k.Text = null;
                    }
                    k.ReadOnly = true;
                    TextBox m = new TextBox();
                    try
                    {
                        int fullgrade = (int)rdr.GetValue(3);
                        m.Text = fullgrade + "";
                    }
                    catch
                    {
                        m.Text = null;
                    }
                    m.ReadOnly = true;
                    TextBox n = new TextBox();
                    try
                    {
                        Decimal weight = (Decimal)rdr.GetValue(4);
                        n.Text = weight.ToString();
                    }
                    catch
                    {
                        n.Text = "NULL";
                    }
                    n.ReadOnly = true;
                    TextBox s = new TextBox();
                    try
                    {
                        DateTime deadline = DateTime.Parse((string)rdr.GetValue(5));
                        s.Text = deadline + "";
                    }
                    catch
                    {
                        s.Text = "NULL";
                    }
                    s.ReadOnly = true;
                    TextBox z = new TextBox();
                    try
                    {
                        String content = (string)rdr.GetValue(6);
                        z.Text = content + "";
                    }
                    catch
                    {
                        z.Text = "NULL";
                    }
                    z.ReadOnly = true;

                    TextBox grade = new TextBox();
                    int myGrade = getGrade(Int32.Parse(rdr.GetValue(1).ToString()),rdr.GetValue(2).ToString(),Session["cid"], Session["id"]);
                    grade.Text = (myGrade==-1)?"Not yet graded":myGrade.ToString();
                    grade.ReadOnly = true;


                    Button j = new Button();
                    j.Text = "submit";
                    j.Click += submitAssign;
                    j.Attributes.Add("number", rdr.GetValue(1).ToString());
                    j.Attributes.Add("type", rdr.GetValue(2).ToString());
                    form1.Controls.Add(l);
                    form1.Controls.Add(k);
                    form1.Controls.Add(m);
                    form1.Controls.Add(n);
                    form1.Controls.Add(s);
                    form1.Controls.Add(z);
                    form1.Controls.Add(grade);
                    if(myGrade==-1)
                        form1.Controls.Add(j);
                    form1.Controls.Add(new Literal() { Text = "<br>" });
                }
                


            }
            else
            {
                Response.Write("no assignments available");

            }
            con.Close();
        }

        private int getGrade(int v1, string v2, object v3, object v4)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand getGradeProc = new SqlCommand("viewAssignGrades", con);
            getGradeProc.Parameters.Add(new SqlParameter("@assignnumber", v1));
            getGradeProc.Parameters.Add(new SqlParameter("@assignType", v2));
            getGradeProc.Parameters.Add(new SqlParameter("@cid", v3.ToString()));
            getGradeProc.Parameters.Add(new SqlParameter("@sid", v4.ToString()));
            SqlParameter grade=getGradeProc.Parameters.Add("@assignGrade",SqlDbType.Int);
            grade.Direction = ParameterDirection.Output;
            getGradeProc.CommandType = CommandType.StoredProcedure;
            con.Open();
            getGradeProc.ExecuteNonQuery();
            con.Close();
            try
            {
                return int.Parse(grade.Value.ToString());
            }catch(Exception ex)
            {
                return -1;
            }
        }

        private void submitAssign(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string num = b.Attributes["number"];
            string typ = b.Attributes["type"];
            int n = int.Parse(num);
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand submitProc = new SqlCommand("submitAssign", conn);
            submitProc.Parameters.AddWithValue("@assignType", typ);
            submitProc.Parameters.AddWithValue("@assignnumber", n);
            submitProc.Parameters.AddWithValue("@sid", Session["id"]);
            submitProc.Parameters.AddWithValue("@cid", Session["cid"]);
            submitProc.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                submitProc.ExecuteNonQuery();
                Response.Write("Submitted successfully");
                Response.Redirect(Request.RawUrl);
            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Response.Write("you already submitted this assignment once!");
                }
                else
                Response.Write("an error occured");
            }
            conn.Close();
        }
    }
}