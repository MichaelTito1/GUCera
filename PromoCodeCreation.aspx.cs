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
    public partial class PromoCodeCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
               
                    if (!Session["userType"].ToString().Equals("admin"))
                    {
                        Response.Redirect("NotAccessiblePage.aspx");
                    }
                    fname.Text = Session["fname"].ToString();
                
            }
        }
        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }

        protected void PromoCreate_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String Pcode = Code.Text;
            DateTime Pissue = IssueDate.SelectedDate; 
            DateTime Pexpiry = ExpiryDate.SelectedDate;
            String Pdiscount = Discount.Text;
            String Pid = AdminId.Text;
            SqlCommand PromoCreationproc = new SqlCommand("AdminCreatePromocode", conn);
            PromoCreationproc.Parameters.Add(new SqlParameter("code", Pcode));
            PromoCreationproc.Parameters.Add(new SqlParameter("isuueDate", Pissue));
            PromoCreationproc.Parameters.Add(new SqlParameter("expiryDate", Pexpiry));
            PromoCreationproc.Parameters.Add(new SqlParameter("discount", Pdiscount));
            PromoCreationproc.Parameters.Add(new SqlParameter("adminId", Pid));
            PromoCreationproc.CommandType = System.Data.CommandType.StoredProcedure;
            if(Pcode.Equals("") || Pissue.Equals("") || Pexpiry.Equals("") || Pdiscount.Equals("") || Pid.Equals(""))
            {
                Label l = new Label();
                l.Text = "You should fill in boxes with * sign";
                msg.Controls.Add(l);
                return;
            }
            if(Pissue.Year > Pexpiry.Year)
            {
                Label l = new Label();
                l.Text = "please enter a valid date";
                msg.Controls.Add(l);
                return;
            }
            else if(Pissue.Year == Pexpiry.Year && Pissue.Month > Pexpiry.Month)
            {
                Label l = new Label();
                l.Text = "please enter a valid date";
                msg.Controls.Add(l);
                return;
            }
            else if(Pissue.Year == Pexpiry.Year && Pissue.Month == Pexpiry.Month && Pissue.Day > Pexpiry.Day)
            {
                Label l = new Label();
                l.Text = "please enter a valid date";
                msg.Controls.Add(l);
                return;
            }
            if(!Pid.Equals((Session["id"]).ToString()))
            {
                Label l = new Label();
                l.Text = "You must issue promoCode with your ID";
                msg.Controls.Add(l);
                return;
            }
            for (int i = 0; i < Pdiscount.Length; i++)
            {
                if (i != 2)
                {
                    if (!(Pdiscount[i] >= '0' && Pdiscount[i] <= '9'))
                    {
                        Label l = new Label();
                        l.Text = "input must be in the form xx.xx or xx where x is a number";
                        msg.Controls.Add(l);
                        return;
                    }
                }
                else
                {
                    if (!(Pdiscount[i].Equals('.')))
                    {
                        Label l = new Label();
                        l.Text = "discount input must be in the form xx.xx where x is a number";
                        msg.Controls.Add(l);
                        return;
                    }
                }
            }

            conn.Open();
            try
            {
                PromoCreationproc.ExecuteNonQuery();
                conn.Close();
                Label l = new Label();
                l.Text = "PromoCode Added Succesfuly";
                msg.Controls.Add(l);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Label l = new Label();
                    l.Text = "this code is already created";
                    msg.Controls.Add(l);
                }
                else
                {
                    Label l = new Label();
                    l.Text = "an error occured";
                    msg.Controls.Add(l);
                }
            }

            }
        }
    }
