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
    public partial class cartview : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridbind();
            }

        }
        public void gridbind()
        {
            string str = "select product.pro_name,product.pro_image,cart.* from cart join product on product.product_id=cart.product_id where Regid=" + Session["userid"] + "";
            DataSet ds = obj.fn_dataset(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string del = "delete from cart where cart_id=" + id + "";
            int j = obj.fn_nonquery(del);
            gridbind();


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridbind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox textqnty = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            string str="update cart set quantity="+textqnty.Text+" where cart_id="+id+"";
            int j = obj.fn_nonquery(str);
            int q = 0, p = 0;
            string se = "select cart.quantity,product.pro_price from product join cart on cart.product_id=product.product_id where cart_id="+id+"";

            SqlDataReader ds = obj.fn_reader(se);
            while (ds.Read())
            {
                q = Convert.ToInt32(ds["quantity"]);
                p = Convert.ToInt32(ds["pro_price"]);
            }
            string ns = "update cart set total_price=" + q * p + " where cart_id=" + id + "";
            int s = obj.fn_nonquery(ns);
            GridView1.EditIndex = -1;
            gridbind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select max(cart_id) from cart";
            string cartid = obj.fn_scalar(str);
            int maxcartid = Convert.ToInt32(cartid);
            int cartt_id = 0, pro_id = 0, reg_id = 0, quantity = 0, total_price = 0, price = 0;
            for(int i = 1; i <= maxcartid; i++)
            {
                string sel = "select * from cart where cart_id=" + i + "";
                SqlDataReader dr = obj.fn_reader(sel);
                while (dr.Read())
                {
                    cartt_id = Convert.ToInt32(dr["cart_id"].ToString());
                    pro_id = Convert.ToInt32(dr["product_id"].ToString());

                    reg_id = Convert.ToInt32(dr["Regid"].ToString());

                    quantity = Convert.ToInt32(dr["quantity"].ToString());


                    total_price = Convert.ToInt32(dr["total_price"].ToString());
                }

                string r = Session["userid"].ToString();
                string u = reg_id.ToString();
                if (u == r)
                {
                    string s = "select max(oid) from tableorder";
                    string orid = obj.fn_scalar(s);
                    int order_id = 0;
                    if (orid == "")
                    {
                        order_id = 1;
                    }
                    else
                    {
                        int nweorder_id = Convert.ToInt32(orid);
                        order_id = nweorder_id + 1;
                    }

                    string ordinsert = "insert into tableorder values(" + order_id + "," + cartt_id + "," + pro_id + "," + reg_id + "," + quantity + "," + total_price + ",'pending')";
                    int j = obj.fn_nonquery(ordinsert);
                    if (j != 0)
                    {
                        string del = "delete from cart where cart_id=" + cartt_id + "";
                        int d = obj.fn_nonquery(del);
                    }


                }
            }


            string str1 = "select sum(total_price) from tableorder where Regid=" + Session["userid"] + " and status='pending'";

            string g_total = obj.fn_scalar(str1);
            Session["gtotal"] = g_total;
            
            string s3 = "select max(billid) from bill ";
            string bid = obj.fn_scalar(s3);
            int bill_id = 0;
            if (bid == "")
            {
                bill_id = 1;
            }
            else
            {
                int newbillid = Convert.ToInt32(bid);
                bill_id = newbillid + 1;
            }
            var billdate = DateTime.Now.ToShortDateString();
            string newdate = Convert.ToDateTime(billdate).ToString("yyyy-MM-dd");
            string insbill = "insert into bill values(" + bill_id + ",'" + newdate + "'," + Session["userid"] + "," + Session["gtotal"] + ",'pending')";
            int b = obj.fn_nonquery(insbill);
            Response.Redirect("ordersummary.aspx");

        }
    }
}