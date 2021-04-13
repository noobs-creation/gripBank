using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//for database
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GRIP_bank
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string hello = Application["name"].ToString();
            //Response.Write(hello);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strconn = ConfigurationManager.ConnectionStrings["sqltrialconnectionstring"].ConnectionString;
                SqlConnection conn = new SqlConnection(strconn);
                SqlCommand cmd, cmdID;
                conn.Open();
                cmdID = new SqlCommand("select max(id) from Users", conn);
                cmdID.CommandType = CommandType.Text;
                int id = Convert.ToInt32(cmdID.ExecuteScalar());
                id += 1;
                cmd = new SqlCommand("prcCreateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                string fullname = TextBox1.Text.ToString();
                cmd.Parameters.AddWithValue("@fullname", fullname);
                string email = TextBox2.Text.ToString();
                cmd.Parameters.AddWithValue("@email", email);
                int amount = Convert.ToInt32(TextBox3.Text.ToString());
                cmd.Parameters.AddWithValue("@balance", amount);
                string linkData = "<a href=\"SelectedUserDetails.aspx?id=" + id + " \" > Transfer Amount </a>";
                cmd.Parameters.AddWithValue("@linkData", linkData);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("TransferMoney.aspx");
            }
            catch(Exception x)
            {
                Response.Write("<script>alert(x)</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }
}