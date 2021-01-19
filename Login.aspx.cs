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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string idstring = username.Text;
            string pass = password.Text;
            Boolean numbers = true; 
            for (int i = 0; i < idstring.Length; i++)
            {
                if (!(idstring[i] >= '0' && idstring[i] <= '9'))
                {
                    numbers = false;
                }
            }
            if (idstring.Equals("")||pass.Equals("")||!numbers)
            {
                Label l = new Label();
                l.Text = "You must enter a valid id number and password";
                msg.Controls.Add(l);
               
                return;
            }
            int id = int.Parse(idstring);
            SqlCommand loginProc = new SqlCommand("userLogin", conn);
            loginProc.Parameters.Add(new SqlParameter("@id",id));
            loginProc.Parameters.Add(new SqlParameter("@password", pass));
            loginProc.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter success = loginProc.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter type = loginProc.Parameters.Add("@type", SqlDbType.Int);

            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;

            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            loginProc.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() .Equals("1"))
            {
                Session["id"] = id;
                SqlCommand cmd2 = new SqlCommand("select firstName from Users where id=@x", conn);
                cmd2.Parameters.Add("@x", id);
                conn.Open();
                SqlDataReader rdr = cmd2.ExecuteReader();
                string name="";
                while (rdr.Read())
                {
                    name = rdr.GetString(0);
                }
                Session["fname"] = name;
                if (type.Value.ToString() .Equals("0"))
                {
                    Session["userType"] = "instructor";
                    Response.Redirect("InstructorHomePage.aspx");
                }
                else if(type.Value.ToString() == "1")
                {
                    Session["userType"] = "admin";
                    Response.Redirect("AdminHomePage.aspx");
                }
                else
                {
                    Session["userType"] = "student";
                    Response.Redirect("StudentHomePage.aspx");
                }
            }
            else
            {
                Label l = new Label();
                l.Text = "Wrong id or password";
                msg.Controls.Add(l);
                
            }
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
        protected void InfoMessageHandler(object mySender, SqlInfoMessageEventArgs myEvent)
        {
            Label l = new Label();
            l.Text += "\n" + myEvent.Message;
            msg.Controls.Add(l);

        }
    }
}