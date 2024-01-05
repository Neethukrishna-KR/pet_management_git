using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace pet_management
{
    public partial class bill : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string str = "select userr.usname,userr.usaddress,bill.total_price,bill.billdate from bill join userr on userr.usid=bill.regid where regid='" + Session["userid"] + "'";
                SqlDataReader dr = obj.fn_reader(str);
                while (dr.Read())
                {
                    Label6.Text = dr["usname"].ToString();
                    Label7.Text = dr["usaddress"].ToString();
                    Label10.Text = dr["total_price"].ToString();
                    Label8.Text = dr["billdate"].ToString();
                    

                }
                string str1 = "select count(quantity) from tableorder where regid='" + Session["userid"] + "' and status='pending'";
                string quantity = obj.fn_scalar(str1);
                Label9.Text = quantity;


            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("payment.aspx");
        }
    }
}