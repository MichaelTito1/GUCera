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
    public partial class ViewPromoCode : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("viewPromocode",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@sid", Session["id"]);

            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            int c = rdr.FieldCount;
            if (!rdr.HasRows)
            {
                Label l = new Label();
                l.Text="No Promocodes to show";
                msg.Controls.Add(l);
            }
            while (rdr.Read())
            {
                Panel cpanel = new Panel();
                Panel cpanel1 = new Panel();
                Panel cpanel2 = new Panel();
                cpanel.CssClass = "PromoContainer";
                cpanel1.CssClass = "subPromoContainer";
                cpanel2.CssClass = "subPromoContainer";
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
                containerDiv.Controls.Add(cpanel);


            }
            conn.Close();
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