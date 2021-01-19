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
    public partial class Certificates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Session["userType"].ToString().Equals("student"))
            {
                Response.Redirect("NotAccessiblePage.aspx");
            }
            if (Session["cid"] == null)
            {
                Response.Redirect("StudentHomePage.aspx"); 
            }



            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("viewCertificate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sid", Session["id"]);
            cmd.Parameters.Add("@cid", Session["cid"]);
            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.Open();
            
            SqlDataReader rdr = cmd.ExecuteReader();
            
            int c = rdr.FieldCount;
            while (rdr.Read())
            {
                
                Panel p = new Panel();

                for (int i = 0; i < c; i++)
                {
                    
                    string name = rdr.GetName(i);
                    Label l = new Label();
                    l.Text = name + " : " + rdr[name];

                    p.Controls.Add(l);
                    p.Controls.Add(new Literal() {  Text = "<br/>" });
                }
               
                form1.Controls.Add(p);
            }
            conn.Close();
        }
        protected void InfoMessageHandler(object mySender, SqlInfoMessageEventArgs myEvent)
        {
            
            Response.Write(myEvent.Message);
            

        }
    }
}