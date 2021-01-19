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
    public partial class WebForm1 : System.Web.UI.Page
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

        protected void addCourse(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand proc = new SqlCommand("InstAddCourse", con);

            string sname = courseName.Text;
            string sprice = courseprice.Text;
            string scredit = creditHours.Text;
            

            if (sname.Length == 0 || scredit.Length == 0 || sprice.Length == 0 )
            {
                Label lb = new Label();
                lb.Text = "Please enter all course data";
                msg.Controls.Add(lb);
                return;
            }

            double price = 0;
            int id = 0, credit= 0;
            try
            {
                price = double.Parse(sprice);
            }catch(FormatException ex){
                Label lb = new Label();
                lb.Text = "Please write the course price in the correct form.";
                msg.Controls.Add(lb);
                return;
            }
            catch(Exception e1)
            {
                Label lb = new Label();
                lb.Text = "Error: " + e1.Message;
                msg.Controls.Add(lb); 
                return;
            }

            try
            {
                credit = int.Parse(scredit);
            }
            catch (FormatException ex)
            {
                Label lb = new Label();
                lb.Text = "Please write the credit hours in the correct form.";
                msg.Controls.Add(lb);
                
                return;
            }
            catch (Exception e1)
            {
                Label lb = new Label();
                lb.Text = "Error: " + e1.Message;
                msg.Controls.Add(lb);
                return;
            }

           

            proc.Parameters.Add(new SqlParameter("@name", sname));
            proc.Parameters.Add(new SqlParameter("@price", price));
            proc.Parameters.Add(new SqlParameter("@creditHours", credit));
            proc.Parameters.Add(new SqlParameter("@instructorId", Session["id"]));
            proc.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                con.Open();
                proc.ExecuteNonQuery();
                con.Close();
                Label lb = new Label();
                lb.Text = "Course added successfully!";
                msg.Controls.Add(lb);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Label lb = new Label();
                    lb.Text = "This course already exists!";
                    msg.Controls.Add(lb);
                }
                else
                {
                    if (ex.Number == 515)
                    {
                        Label lb = new Label();
                        lb.Text = "Check the correct id";
                        msg.Controls.Add(lb);
                    }
                    else
                    {
                        //TODO change the sentence before submitting
                        Label lb = new Label();
                        lb.Text = "error number :" + ex.Number + "\n error message :" + ex.Message;
                        msg.Controls.Add(lb);
                    }
                }
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHomePage.aspx");
        }

        protected bool checkNumerical(string s, bool price)
        {
            bool numerical = true;
            int n = s.Length;
            if (price)
            {
                for (int i = 0; i < n; i++)
                {
                    if (!(s[i] >= '0' && s[i] <= '9') && s[i] != '.')
                    {
                        numerical = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!(s[i] >= '0' && s[i] <= '9'))
                    {
                        numerical = false;
                        break;
                    }
                }
            }

            return numerical;
        }
    }
}