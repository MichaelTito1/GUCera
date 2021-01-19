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
    public partial class addPhone : System.Web.UI.Page
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
            }
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT M.mobileNumber as mobile FROM Users U INNER JOIN UserMobileNumber M ON U.id = M.id WHERE U.id = @X";
            cmd.Parameters.AddWithValue("@X", Session["id"]);

            conn.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                Label lbl = new Label();
                lbl.Text = "your phone numbers are";
                icid.Controls.Add(lbl);
                while (reader.Read())
                {
                    string cname = reader.GetString(reader.GetOrdinal("mobile"));
                    TextBox l = new TextBox();
                    l.Text = cname;
                    l.ReadOnly = true;
                    
                    icid.Controls.Add(l);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number==8178)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Label l = new Label();
                    l.Text = ex.Number + " " + ex.Message;
                    msg.Controls.Add(l);
                    
                }
            }
            
        }

        protected void add_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String num = number.Text;
            if (num.Equals(""))
            {
                Label l = new Label();
                l.Text = "enter a value first";
                msg.Controls.Add(l);
                
                return;
            }
            for (int i=0;i<num.Length;i++)
            {
                if(!(num[i]>='0'&& num[i] <= '9'))
                {
                    Label l = new Label();
                    l.Text = "Input must be numbers only";
                    msg.Controls.Add(l);
                    
                    return;
                }
            }
            SqlCommand addMobProc = new SqlCommand("addMobile", conn);
            addMobProc.CommandType = System.Data.CommandType.StoredProcedure;
            addMobProc.Parameters.Add(new SqlParameter("@id", Session["id"]));
            addMobProc.Parameters.Add(new SqlParameter("@mobile_number", num));
            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            try
            {
                addMobProc.ExecuteNonQuery();
                Response.Redirect("addPhone.aspx");
            }
            catch(SqlException ex)
            {
                if (ex.Number== 2627)
                {
                    Label l = new Label();
                    l.Text = "This phone number is already entered";
                    msg.Controls.Add(l);
                    
                }
                else
                {
                    Label l = new Label();
                    l.Text = ex.Number + "    " + ex.Message;
                    msg.Controls.Add(l);
                    
                }
            }
            conn.Close();
            

        }

        protected void home_Click(object sender, EventArgs e)
        {
            if (Session["userType"].ToString().Equals("instructor"))
            {
                Response.Redirect("InstructorHomePage.aspx");
            }
            else if (Session["userType"].ToString().Equals("admin"))
            {
                Response.Redirect("AdminHomePage.aspx");
            }
            else if (Session["userType"].ToString().Equals("student"))
            {
                Response.Redirect("StudentHomePage.aspx");
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