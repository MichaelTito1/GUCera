using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Media.Imaging;

namespace GUCera
{
    public partial class availableCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
           
            else
            {
                fname.Text = Session["fname"].ToString();
                if (!Session["userType"].ToString().Equals("student"))
                {
                    Response.Redirect("NotAccessiblePage.aspx");
                }
            }

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand availableCoursesProc = new SqlCommand("availableCourses", conn);
            availableCoursesProc.Parameters.Add("@sid", Session["id"]);
            availableCoursesProc.CommandType = CommandType.StoredProcedure;
            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            SqlDataReader rdr = availableCoursesProc.ExecuteReader();
            if (rdr.HasRows)
            {
                int c = 0;
                while (rdr.Read())
                {
                    Panel coursePanel = new Panel();
                    Panel left= new Panel();
                    Panel right = new Panel();

                    coursePanel.CssClass += "CourseContainer";
                    left.CssClass += "subCourseContainer";
                    right.CssClass += "subCourseContainer";
                    
                    
                    String cname = rdr.GetString(0);
                    Label courseName = new Label();
                    courseName.Text = cname;
                    Button gotoCourse = new Button();
                    gotoCourse.Text = "View This Course";
                    gotoCourse.Click += view;
                    gotoCourse.Attributes.Add("name", cname);
                    left.Controls.Add(courseName);
                    right.Controls.Add(gotoCourse);
                    coursePanel.Controls.Add(left);

                    HtmlImage image = new HtmlImage();

                    int x = (c % 6) + 1;
                    image.Src = "images//course"+(x)+".png";
                    c++;
                    coursePanel.Controls.Add(image);
                    coursePanel.Controls.Add(right);
                    courses.Controls.Add(coursePanel);
                }
                
                
            }
            else {
                Label l = new Label();
                l.Text = "no courses available";
                msg.Controls.Add(l);
                
            }
        }
        protected void view(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Response.Redirect("CoursePage.aspx?course="+ button.Attributes["name"]);
            //Response.Write(button.Attributes["name"]);
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