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
    public partial class InstructorDefineAssignment : System.Web.UI.Page
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
        }

        protected void addAssignment(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand proc = new SqlCommand("DefineAssignmentOfCourseOfCertianType", con);

            string sid = Session["cid"].ToString(),
                snum = number.Text,
                typ = type.Text,
                sfull = grade.Text,
                sw = weight.Text,
                dead = deadline.Text,
                content = cont.Text;
            int instID = int.Parse(Session["id"].ToString()); // logged-in instructor id

            if(sid.Length == 0 || snum.Length == 0 || typ.Length == 0 || sfull.Length == 0 ||
                sw.Length == 0 || dead.Length == 0 || content.Length == 0)
            {
                Label lb = new Label();
                lb.Text = "Please fill all assignment data!";
                msg.Controls.Add(lb);
                return;
            }
            if(!(checkNumerical(sid) && checkNumerical(snum) && checkNumerical(sfull) && checkNumerical(sw)))
            {
                Label lb = new Label();
                lb.Text = "Assignment number, full grade and weight have to be numerical.";
                msg.Controls.Add(lb);
                return;
            }

            int id = int.Parse(sid),
                num = int.Parse(snum),
                full = int.Parse(sfull),
                w = int.Parse(sw);
            DateTime deadLine;
            try
            {
                deadLine = DateTime.Parse(dead);
            }
            catch(FormatException fe)
            {
                Label lb = new Label();
                lb.Text = "Please enter the deadline in the specified format.";
                msg.Controls.Add(lb);
                return;
            }
            catch(Exception e1)
            {
                Label lb = new Label();
                lb.Text = "An error has occurred. Please consult the IT team.";
                msg.Controls.Add(lb);
                return;
            }
            //Checking if the logged-in instructor teaches this course
            SqlCommand findInst = con.CreateCommand();
            findInst.CommandText = "select * from InstructorTeachCourse where insid=@id and cid=@c";
            findInst.Parameters.AddWithValue("@id", instID);
            findInst.Parameters.AddWithValue("@c", id);
            con.Open();
            SqlDataReader r = findInst.ExecuteReader();
            if (!r.Read()){
                Label lb = new Label();
                lb.Text = "Please choose a course that you are teaching.";
                msg.Controls.Add(lb);
                return;
            }
            r.Close();
            r.Dispose();

            //inserting parameters
            proc.Parameters.Add(new SqlParameter("@instId", instID));
            proc.Parameters.Add(new SqlParameter("@cid", id));
            proc.Parameters.Add(new SqlParameter("@number", num));
            proc.Parameters.Add(new SqlParameter("@type", typ));
            proc.Parameters.Add(new SqlParameter("@fullGrade", full));
            proc.Parameters.Add(new SqlParameter("@weight", w));
            proc.Parameters.Add(new SqlParameter("@deadline", deadLine));
            proc.Parameters.Add(new SqlParameter("@content", content));
            proc.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                proc.ExecuteNonQuery();
                con.Close();
                Label lb = new Label();
                lb.Text = "Assignment added successfully.";
                msg.Controls.Add(lb);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Label lb = new Label();
                    lb.Text = "This assignment already exists.";
                    msg.Controls.Add(lb);
                }
                else if(ex.Number == 547)
                {
                    Label lb = new Label();
                    lb.Text = "Please check the format of the entered values.";
                    msg.Controls.Add(lb);
                }
                else
                {
                    //TODO change the sentence before submitting
                    Label lb = new Label();
                    lb.Text = "An error has occurred. Please consult the IT team.";
                    msg.Controls.Add(lb);
                }
            }
            catch(Exception e1)
            {
                Label lb = new Label();
                lb.Text = "An error has occurred. Please consult the IT team.";
                msg.Controls.Add(lb);
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHomePage.aspx");
        }

        protected bool checkNumerical(string s)
        {
            bool numerical = true;
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                if (!(s[i] >= '0' && s[i] <= '9'))
                {
                    numerical = false;
                    break;
                }
            }

            return numerical;
        }
    }
}