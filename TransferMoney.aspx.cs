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
    public partial class TransferMoney : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
                BindData();
        }

        private void BindData()
        {
            string strconn = ConfigurationManager.ConnectionStrings["sqltrialconnectionstring"].ConnectionString;
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            htmlTable.Append("<table class=\"table table - hover table - sm table - striped table - condensed table - bordered\" style=\"border - color:black; \"");
            htmlTable.Append("<tr style='background-color:green; color: White;'><th scope=\"col\" class=\"text - center py - 2\">User ID</th><th scope=\"col\" class=\"text - center py - 2\">Name</th><th scope=\"col\" class=\"text - center py - 2\">Email</th><th scope=\"col\" class=\"text - center py - 2\">Balance</th><th scope=\"col\" class=\"text - center py - 2\">Transfer Amount</th></tr>");

            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        
                        htmlTable.Append("<tr style='color: White;'>");
                        htmlTable.Append("<td id=\"userID\">" + ds.Tables[0].Rows[i]["id"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["fullname"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["email"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["balance"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["linkData"] + "</td>");
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

    }
}