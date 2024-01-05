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
    public partial class WebForm3 : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                string str = "select product.pro_name,product.pro_image,tableorder.quantity,tableorder.total_price,tableorder.status from product join tableorder on product.product_id=tableorder.product_id where Regid=" + Session["userid"] + " and status='pending'";
                DataSet ds = obj.fn_dataset(str);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                string s = "select max(billid) from bill where regid='" + Session["userid"] + "'";
                string bill = obj.fn_scalar(s);
                int b = Convert.ToInt32(bill);

                string str2 = "select total_price from bill where regid='" + Session["userid"] + "' and status='pending' and billid=" + b + "";
                string amount = obj.fn_scalar(str2);
                int am = Convert.ToInt32(amount);
                Label1.Text = am.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("bill.aspx");
        }

    }
}