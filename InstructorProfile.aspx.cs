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
    public partial class InstructorProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!Session["userType"].ToString().Equals("instructor"))
                {
                    Response.Redirect("NotAccessiblePage.aspx");
                }
                fname.Text = Session["fname"].ToString();
            }

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = (int)Session["id"];
            SqlCommand com = new SqlCommand("ViewInstructorProfile", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@instrId", Session["id"]);

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
                        l.Text += (b[0].ToString().Equals("0")) ? "Male" : "Female";
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

        protected void InfoMessageHandler(object mySender, SqlInfoMessageEventArgs myEvent)
        {
            Label l = new Label();
            l.Text += "\n" + myEvent.Message;
            msg.Controls.Add(l);

        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHomePage.aspx");
        }
    }
}