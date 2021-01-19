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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void confirmRegistration(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            Boolean isStudent = (UserType.SelectedValue.Equals("Student")) ? true : false;
            String fname = firstname.Text;
            String lname = lastname.Text;
            String pass = password.Text;
            int isMale = (genderList.SelectedValue.Equals("Male")) ? 0 : 1;
            String user_email = email.Text;
            String user_address = address.Text;
            SqlCommand registrationProc;
            if (fname.Equals("") || lname.Equals("") || pass.Equals("") || user_email.Equals(""))
            {
                Label l = new Label();
                l.Text = "Please Complete All data marked with *";
                msg.Controls.Add(l);
                return;
            }
            if (isStudent)
            {
                registrationProc = new SqlCommand("studentRegister", conn);
            }
            else
            {
                registrationProc = new SqlCommand("InstructorRegister", conn);
            }
            registrationProc.Parameters.Add(new SqlParameter("@first_name", fname));
            registrationProc.Parameters.Add(new SqlParameter("@last_name", lname));
            registrationProc.Parameters.Add(new SqlParameter("@password", pass));
            registrationProc.Parameters.Add(new SqlParameter("@email", user_email));
            registrationProc.Parameters.Add(new SqlParameter("@gender", isMale));
            registrationProc.Parameters.Add(new SqlParameter("@address", user_address));
           
            registrationProc.CommandType = System.Data.CommandType.StoredProcedure;

            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            try
            {
                registrationProc.ExecuteNonQuery();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from users where email=@x";
                cmd.Parameters.AddWithValue("@x", user_email);
                //cmd.CommandText = "SELECT SCOPE_IDENTITY()";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    Label l = new Label();
                    l.Text = "Your id is " + id;
                    msg.Controls.Add(l);
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number==2627)
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
            


           




        }

        protected void loginPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void InfoMessageHandler(object mySender, SqlInfoMessageEventArgs myEvent)
        {
            Label l = new Label();
            l.Text += "\n" + myEvent.Message;
            msg.Controls.Add(l);

        }
    }
}
/*things to consider
 *   email :    @ sign====unique
 *   id    :    identity
 *    
 * 
 * 
 * */