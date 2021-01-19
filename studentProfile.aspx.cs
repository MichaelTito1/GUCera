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
    public partial class studentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = (int)Session["id"];
            SqlCommand com = new SqlCommand("viewMyProfile", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter("@id", Session["id"]));
            //Response.Write(Session["id"] + "\n");

            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            SqlDataReader rdr = com.ExecuteReader();
            ArrangeData(rdr);
            conn.Close();
        }

        private void ArrangeData(SqlDataReader rdr)
        {
            //throw new NotImplementedException();
            int c = rdr.FieldCount;
            while (rdr.Read())
            {
                //Response.Write(rdr.GetSqlBinary (rdr.GetOrdinal("gender")));

                Panel left = new Panel();
                Panel right = new Panel();
                left.CssClass += "subDataContainer";
                right.CssClass += "subDataContainer";
                for (int i = 1; i < c; i++)
                {
                    string name = rdr.GetName(i);
                    Label l = new Label
                    {
                        Text = name + " :  "
                    };
                    
                    if (name.Equals("gender"))
                    {
                        byte[] b = (byte[])rdr[name];
                        l.Text += (b[0].ToString().Equals("0"))?"Male":"Female";
                    }
                    else
                    {
                        l.Text += rdr[name].ToString();
                    }

                    if (i % 2 == 0)
                    {
                        left.Controls.Add(l);
                    }
                    else
                    {
                        right.Controls.Add(l);
                    }
                   
                   
                   
                }
                dataContainer.Controls.Add(right);
                dataContainer.Controls.Add(left);

            }
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHomePage.aspx");
        }
        protected void editclick(object sender, EventArgs e)
        {
            Edit.Visible = false;
            inpContainer.Style.Add("visibility", "visible");
            Save.Style.Add("visibility", "visible");

        }
        protected void update(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String fname = firstname.Text;
            String lname = lastname.Text;
            String pass = password.Text;
            int isMale = (genderList.SelectedValue.Equals("Male")) ? 0 : 1;
            String user_email = email.Text;
            String user_address = address.Text;
            SqlCommand editProc=new SqlCommand("editMyProfile",conn);
            editProc.CommandType = CommandType.StoredProcedure;
            if (fname.Equals("") || lname.Equals("") || pass.Equals("") || user_email.Equals(""))
            {
                Label l = new Label();
                l.Text = "Please Complete All data marked with *";
                msg.Controls.Add(l);
                return;
            }

            editProc.Parameters.Add(new SqlParameter("@id", Session["id"]));
            editProc.Parameters.Add(new SqlParameter("@firstname", fname));
            editProc.Parameters.Add(new SqlParameter("@lastname", lname));
            editProc.Parameters.Add(new SqlParameter("@password", pass));
            editProc.Parameters.Add(new SqlParameter("@email", user_email));
            editProc.Parameters.Add(new SqlParameter("@gender", isMale));
            editProc.Parameters.Add(new SqlParameter("@address", user_address));

           

            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            try
            {
                editProc.ExecuteNonQuery();
                Session["fname"] = fname;
                Response.Redirect(Request.RawUrl);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Label l = new Label();
                    l.Text = "Your email is registered before";
                    msg.Controls.Add(l);

                }
                else
                {
                    //TODO change the sentence before submitting
                    Label l = new Label();
                    l.Text = "error number :" + ex.Number + "\n error message :" + ex.Message;
                    msg.Controls.Add(l);

                }
            }
            finally
            {
                conn.Close();
            }
            
        }
        protected void InfoMessageHandler(object mySender, SqlInfoMessageEventArgs myEvent)
        {
            Label l = new Label();
            l.Text += "\n" + myEvent.Message;
            msg.Controls.Add(l);

        }
    }
}