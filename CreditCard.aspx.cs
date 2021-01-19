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
    public partial class CreditCard : System.Web.UI.Page
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
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(
                 "SELECT C.number, C.cardHolderName, C.expiryDate, C.cvv FROM Student S INNER JOIN StudentAddCreditCard SC ON S.id = SC.sid INNER JOIN CreditCard C ON C.number = SC.creditCardNumber WHERE S.id = @X"
                , conn);
            cmd.Parameters.Add("@X", Session["id"]);
           
            
            conn.Open();
            
            SqlDataReader rdr = cmd.ExecuteReader();

            int c = rdr.FieldCount;
            while (rdr.Read())
            {
                Panel cpanel = new Panel();
                Panel cpanel1 = new Panel();
                Panel cpanel2 = new Panel();
                cpanel.CssClass = "CreditContainer";
                cpanel1.CssClass = "subCreditContainer";
                cpanel2.CssClass = "subCreditContainer";
                for (int i = 0; i < c; i++)
                {
                    string name = rdr.GetName(i);
                    Label l = new Label
                    {
                        Text = name + " :  " + rdr[name].ToString()
                    };
                    if (i % 2 == 0)
                    {
                        cpanel1.Controls.Add(l);
                    }
                    else
                    {
                        cpanel2.Controls.Add(l);
                    }
                   
                }
                cpanel.Controls.Add(cpanel1);
                cpanel.Controls.Add(cpanel2);
                lowerDiv.Controls.Add(cpanel);


            }
            conn.Close();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("addCreditCard" , conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            string numberstr = numberTb.Text;
            Boolean err = false;
            for (int i = 0; i < numberstr.Length; i++)
            {
                if (!(numberstr[i] >= '0' && numberstr[i] <= '9'))
                {
                    err = true;
                }
            }
            string name = nameTb.Text;
            string expdate = yyyy.Text + mm.Text + dd.Text;
            for (int i = 0; i < expdate.Length; i++)
            {
                if (!(expdate[i] >= '0' && expdate[i] <= '9'))
                {
                    err = true;
                }
            }
            string cvvstr = cvvTb.Text;
            for (int i = 0; i < cvvstr.Length; i++)
            {
                if (!(cvvstr[i] >= '0' && cvvstr[i] <= '9'))
                {
                    err = true;
                }
            }
            if (err||name.Equals("") || numberstr.Equals("") || cvvstr.Equals("") || expdate.Equals("") )
            {
                Label l = new Label();
                l.Text = "You must enter a valid input";
                msg.Controls.Add(l);
                
                return;
            }
            Int64 number = Int64.Parse(numberstr);
            int cvv = int.Parse(cvvstr);
            string date= yyyy.Text+"/" + mm.Text+"/" + dd.Text;

            cmd.Parameters.Add("@sid", Session["id"]);
            cmd.Parameters.Add("@number",number);
            cmd.Parameters.Add("@cardHolderName", name);
            cmd.Parameters.Add("@expiryDate", date);
            cmd.Parameters.Add("@cvv", cvv);
            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(SqlException er)
            {
                if (er.Number == 8114)
                {
                    Label l = new Label();
                    l.Text = "Not a valid date";
                    msg.Controls.Add(l);
                    
                }
                else if (er.Number == 2627)
                {
                    Label l = new Label();
                    l.Text = "This card number is already registered";
                    msg.Controls.Add(l);
                }
                else
                {
                    Label l = new Label();
                    l.Text = "an error has occured"+ er.Number;
                    msg.Controls.Add(l);
                    
                }
                conn.Close();
                return;
            }
            
            conn.Close();
            Response.Redirect(Request.RawUrl);
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