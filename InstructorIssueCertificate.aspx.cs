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
    public partial class InstructorIssueCertificate : System.Web.UI.Page
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
            courseData.Text = Session["cid"].ToString() + " " + Session["cname"].ToString();

            fname.Text = Session["fname"].ToString();
        }

        protected void issue(object sender, EventArgs e)
        {
            int cid = int.Parse(Session["cid"].ToString());
            int iid = int.Parse(Session["id"].ToString());

            if(student.Text.Length == 0)
            {
                Label lb = new Label();
                lb.Text = "Student ID can't be left empty!";
                msg.Controls.Add(lb);
                return;
            }
            int sid;
            try
            {
                sid = int.Parse(student.Text);
            }
            catch(FormatException ex)
            {
                Label lb = new Label();
                lb.Text = "Please enter the ID in the correct format.";
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

            //checking if this student is enrolled in this course
            //and if the logged-in instructor teaches this course
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            using(SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("select * from InstructorTeachCourse where insid=@iid and cid=@cid", con))
                {
                    cmd.Parameters.AddWithValue("@iid", iid);
                    cmd.Parameters.AddWithValue("@cid", cid);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read())
                        {
                            Label lb = new Label();
                            lb.Text = "You can't issue a certificate because you don't teach this course.";
                            msg.Controls.Add(lb);
                            return;
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("select * from StudentTakeCourse where sid = @sid and insid=@iid and cid=@cid", con))
                {
                    cmd.Parameters.AddWithValue("@iid", iid);
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@sid", sid);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.HasRows)
                        {
                            Label lb = new Label();
                            lb.Text = "This student is not enrolled in this course.";
                            msg.Controls.Add(lb);
                            return;
                        }
                        while (dr.Read())
                        {
                            double g = 0;
                            try
                            {
                                g = double.Parse(dr.GetValue(4).ToString());
                            }
                            catch(Exception ex)
                            {
                                
                                g = 0;
                            }
                            if (dr.GetValue(3).ToString().Equals(""))
                            {
                                Label lb = new Label();
                                lb.Text = "This student has not paid for this course yet.";
                                msg.Controls.Add(lb);
                                return;
                            }
                            else if( g <= 2.0)
                            {
                                Label lb = new Label();
                                lb.Text = "This student has not passed this course.";
                                msg.Controls.Add(lb);
                                return;
                            }
                        }
                    }
                }

                using (SqlCommand proc = new SqlCommand("InstructorIssueCertificateToStudent", con))
                {
                    proc.Parameters.Add(new SqlParameter("@insId", iid));
                    proc.Parameters.Add(new SqlParameter("@cid", cid));
                    proc.Parameters.Add(new SqlParameter("@sid", sid));
                    proc.Parameters.Add(new SqlParameter("@issueDate", DateTime.Now));
                    proc.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        proc.ExecuteNonQuery();
                        con.Close();
                        Label lb = new Label();
                        lb.Text = "Certificate issued successfully!";
                        msg.Controls.Add(lb);
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            Label lb = new Label();
                            lb.Text = "This certificate is already issued.";
                            msg.Controls.Add(lb);
                        }
                        else
                        {
                            Label lb = new Label();
                            lb.Text = "An error has occurred. Please consult the IT team.";
                            msg.Controls.Add(lb);
                            //TODO change the sentence before submitting
                        }
                    }
                    catch (Exception e1)
                    {
                        Label lb = new Label();
                        lb.Text = "An error has occurred. Please consult the IT team.";
                        msg.Controls.Add(lb);
                    }
                }
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHomePage.aspx");
        }
    }
}