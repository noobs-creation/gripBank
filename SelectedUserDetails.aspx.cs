using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace GRIP_bank
{
    public partial class SelectedUserDetails : System.Web.UI.Page
    {
        SqlDataAdapter da;
        static string sender, receiver;
        static int balance, tmp;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            //Response.Write(d);
            if (!Page.IsPostBack)
            {
                BindData(id);
                string strconn = ConfigurationManager.ConnectionStrings["sqltrialconnectionstring"].ConnectionString;
                SqlConnection conn = new SqlConnection(strconn);
                string com = "Select * from Users";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "fullname";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
            }
        }

        private void BindData(string id)
        {
            string strconn = ConfigurationManager.ConnectionStrings["sqltrialconnectionstring"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            string sqlCMD = "Select id, fullname, email, balance from Users where id=" + id;
            SqlCommand cmd = new SqlCommand(sqlCMD, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            SelectedUserDetails.sender = ds.Tables[0].Rows[0]["fullname"].ToString();
            htmlTable.Append("<table class=\"table table - hover table - sm table - striped table - condensed table - bordered\" style=\"border - color:black; \"");
            htmlTable.Append("<tr style='background-color:green; color: White;'><th scope=\"col\" class=\"text - center py - 2\">Customer ID.</th><th scope=\"col\" class=\"text - center py - 2\">Name</th><th scope=\"col\" class=\"text - center py - 2\">Email</th><th scope=\"col\" class=\"text - center py - 2\">Balance</th></tr>");

            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        htmlTable.Append("<tr style='color: White;'>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["id"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["fullname"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["email"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["balance"] + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
                else
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td align='center' colspan='4'>There is no Record.</td>");
                    htmlTable.Append("</tr>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //current user id
            string id = Request.QueryString["id"].ToString();
            //connection stuffs
            string strconn = ConfigurationManager.ConnectionStrings["sqltrialconnectionstring"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            /*string sqlCMD = "Select id, fullname, email, balance from Users where id=" + id;
            SqlCommand cmd = new SqlCommand(sqlCMD, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();*/

            //getting current user balance
            SqlCommand cmdBalance;
            conn.Open();
            string sqlBalance = "select balance from Users where id=" + id;
            cmdBalance = new SqlCommand(sqlBalance, conn);
            cmdBalance.CommandType = CommandType.Text;
            balance = Convert.ToInt32(cmdBalance.ExecuteScalar());
            conn.Close();

            //checking for sufficient balance
            int amount = Convert.ToInt32(TextBox1.Text.ToString());
            
            if(balance >= amount)
            {
                tmp = SelectedUserDetails.balance - amount;

                //deducting money from current user
                SqlCommand cmdTrans, cmdTransOld, cmdTransComplete;
                conn.Open();
                string sqlTrans = "update Users set balance="+tmp+"where id="+id;
                cmdTrans = new SqlCommand(sqlTrans, conn);
                cmdTrans.CommandType = CommandType.Text;
                cmdTrans.ExecuteNonQuery();
                conn.Close();

                //getting old amount of receiver
                conn.Open();
                int id2 = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
                string gettingOldBalance = "select balance from Users where id=" + id2;
                cmdTransOld = new SqlCommand(gettingOldBalance, conn);
                cmdTransOld.CommandType = CommandType.Text;
                int oldAmount = Convert.ToInt32(cmdTransOld.ExecuteScalar());
                conn.Close();

                //getting receiver's name
                conn.Open();
                string gettingReceiverName = "select fullname from Users where id=" + id2;
                SqlCommand grn = new SqlCommand(gettingReceiverName, conn);
                grn.CommandType = CommandType.Text;
                SelectedUserDetails.receiver = Convert.ToString(grn.ExecuteScalar());
                conn.Close();

                //updating amount of receiver
                conn.Open();
                oldAmount = oldAmount + amount;
                string sqlTransComplete = "update Users set balance="+ oldAmount +"where id="+id2;
                cmdTransComplete = new SqlCommand(sqlTransComplete, conn);
                cmdTransComplete.CommandType = CommandType.Text;
                cmdTransComplete.ExecuteNonQuery();
                conn.Close();

                //inserting transactions
                conn.Open();
                SqlCommand trans = new SqlCommand("prcInsertTransaction", conn);
                trans.CommandType = CommandType.StoredProcedure;
                trans.Parameters.AddWithValue("@sender", SelectedUserDetails.sender);
                trans.Parameters.AddWithValue("@receiver", SelectedUserDetails.receiver);
                trans.Parameters.AddWithValue("@balance", amount);
                trans.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("TransactionHistory.aspx");
            }
            else
            {
                string message = "Insufficient balance.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            
        }
    }
}