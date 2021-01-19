using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class CoursePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cname = Request.QueryString["course"];
            
            if (cname == null)
            {
                Response.Redirect("availableCourses.aspx");
                return;
            }
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!Session["userType"].ToString().Equals("student"))
                {
                    Response.Redirect("NotAccessiblePage.aspx");
                }
                fname.Text = Session["fname"].ToString();
            }
            int courseId = getIdByCourseName(cname);
            Enroll.Attributes.Add("courseID", courseId.ToString());

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand courseInfoProc = new SqlCommand("courseInformation", conn);
            courseInfoProc.CommandType = CommandType.StoredProcedure;
            courseInfoProc.Parameters.Add(new SqlParameter("@id", courseId));
           
            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            
            SqlDataReader rdr = courseInfoProc.ExecuteReader();
            int c = rdr.FieldCount;
            while (rdr.Read())
            {
               
                Panel left = new Panel();
                Panel right = new Panel();
                
                left.CssClass += "subDataContainer";
                right.CssClass += "subDataContainer";
                for (int i = 1; i < c; i++)
                {
                    string name = rdr.GetName(i);
                    Label l = new Label
                    {
                        Text = name+ " : "+ rdr[name].ToString()
                    };
                    if (!l.Text .Equals(""))
                    {
                        if (i % 2 == 0)
                        {
                            left.Controls.Add(l);
                        }
                        else
                        {
                            right.Controls.Add(l);
                        }
               
                    }
                   
                   
                }
                container.Controls.Add(left);
                container.Controls.Add(right);
                

            }
            conn.Close();
            //---------------------------
            SqlCommand chooseInst = new SqlCommand("select u.firstName,u.lastName,u.email,u.id from InstructorTeachCourse itc inner join Users u on u.id = itc.insid inner join Instructor i on i.id = u.id where cid = @x; ", conn);
            chooseInst.Parameters.Add("@x", courseId);
            conn.Open();
            SqlDataReader rdr2 = chooseInst.ExecuteReader();
            if (!rdr2.HasRows)
            {
                Label l = new Label();
                l.Text = "No instructors to Show...";
                msg.Controls.Add(l);
            }
            else
            {
                if (rbl.Items.Count == 0)
                {
                    while (rdr2.Read())
                    {

                        ListItem currentInst = new ListItem();
                        currentInst.Text = "First name : " + rdr2.GetString(0) + "|||"+"Last name : " + rdr2.GetString(1)
                                            + "||| Email : " + rdr2.GetString(2);
                        currentInst.Value = rdr2[rdr2.GetName(3)].ToString();
                        rbl.Items.Add(currentInst);
                    }
                }
                
                
            }
            conn.Close();
           
            //----------------------------
            //Enroll.Attributes.Add("insID", insID.ToString());


            
            if (enrolled(courseId))
            {
                Enroll.Enabled = false;
                Enroll.Text = "Enrolled";
                Enroll.BackColor = Color.Transparent;
                Enroll.ForeColor = Color.FromArgb(80,80,80);
                rbl.Enabled = false;
            }

        }

        private int getIdByCourseName(string cname)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand com = new SqlCommand(
                "SELECT @cid=id FROM Course WHERE name=@cname"
                , conn);
            com.Parameters.Add(new SqlParameter("@cname", cname));
            SqlParameter cid = com.Parameters.Add("@cid", SqlDbType.Int);

            cid.Direction = ParameterDirection.Output;
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            return int.Parse(cid.Value.ToString());
        }

        private bool enrolled(int id)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("EXEC @x=dbo.checkStudentEnrolledInCourse @sid,@cid ", conn);
            cmd.Parameters.Add(new SqlParameter("@sid", Session["id"]));
            cmd.Parameters.Add(new SqlParameter("@cid", id));
            SqlParameter x = cmd.Parameters.Add("@x", SqlDbType.Int);
            x.Direction = ParameterDirection.Output;
            conn.Open();
            conn.InfoMessage += delegate (object sender2, SqlInfoMessageEventArgs e2)
            {
                Label l = new Label();
                l.Text += "\n" + e2.Message;
                msg.Controls.Add(l);
            };
            cmd.ExecuteNonQuery();
            conn.Close();
            if (x.Value.ToString().Equals("0"))
                return false;
            else
                return true;
        }

        protected void Enroll_Click(object sender, EventArgs e)
        {
            int cid = int.Parse(Enroll.Attributes["courseID"]);
            
            if (rbl.SelectedItem==null)
            {
                Label l = new Label();
                l.Text = "No Instructor is chosen ";
                msg.Controls.Add(l);
                return;
            }
            

            int insID = int.Parse(rbl.SelectedValue);
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("enrollInCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@sid", Session["id"]));
            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            cmd.Parameters.Add(new SqlParameter("@instr", insID));
            
            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            cmd.ExecuteNonQuery();
            if (enrolled(getIdByCourseName(Request.QueryString["course"])))
            {
                Response.Redirect(Request.RawUrl);
            }
            conn.Close();
            
            //Response.Write("done  "+Session["id"]+" "+cid+" "+insID);

            
           
            

        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHomePage.aspx");
        }
        protected void InfoMessageHandler(object mySender, SqlInfoMessageEventArgs myEvent)
        {
            Label l = new Label();
            l.Text += "\n" + myEvent.Message;
            msg.Controls.Add(l);

        }
    }
}