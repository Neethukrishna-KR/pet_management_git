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
    public partial class payment : System.Web.UI.Page
    {
        connectionclass OBJ = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string S="select max(billid) from bill where regid='"+Session["userid"]+"'";
                string bill = OBJ.fn_scalar(S);
                int b = Convert.ToInt32(bill);
                string str = "select total_price from bill  where regid='" + Session["userid"] + "' and billid=" + b + "";
                string amount = OBJ.fn_scalar(str);
                Session["amt"] = amount;
                Label3.Text = amount;
               

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            petservice.ServiceClient obj = new petservice.ServiceClient();
            string s = obj.balancecheck(Convert.ToInt32(TextBox1.Text));
            int m = Convert.ToInt32(s);
            if (m > Convert.ToInt32(Session["amt"]))
            {
                string newbal = (m - Convert.ToInt32(Session["amt"])).ToString();
                petservice.ServiceClient obj1 = new petservice.ServiceClient();
                int b = obj1.balaceupdate(TextBox1.Text, newbal);
                if (b != 0)
                {
                    string s1 = "update tableorder set status='paid' where regid=" + Session["userid"] + "";
                    int c = OBJ.fn_nonquery(s1);
                    string s12 = "update bill set status='paid' where regid=" + Session["userid"] + "";
                    int d = OBJ.fn_nonquery(s12);

                }
                Label4.Text = "successfully paid";
                string str = "select max(oid) from tableorder";
                string maxcartid = OBJ.fn_scalar(str);
                int mcatid = Convert.ToInt32(maxcartid);
                int prdt_id = 0, reg_id = 0, qnty = 0, nw_stk = 0;
                string status = "";
                for (int i = 1; i <= mcatid; i++)
                {
                    string sel1 = "select * from tableorder where oid=" + i + "";
                    SqlDataReader dr = OBJ.fn_reader(sel1);
                    while (dr.Read())
                    {
                        prdt_id = Convert.ToInt32(dr["product_id"]);
                        reg_id = Convert.ToInt32(dr["regid"]);
                        qnty = Convert.ToInt32(dr["quantity"]);
                        status = dr["status"].ToString();
                    }
                    string r = Session["userid"].ToString();
                    string u = reg_id.ToString();
                    if (u == r)
                    {
                        if (status == "paid")
                        {
                            string s2 = "select pro_stock from product where product_id=" + prdt_id + "";
                            string st = OBJ.fn_scalar(s2);
                            int k = Convert.ToInt32(st);
                            if (k > qnty)
                            {
                                nw_stk = k - qnty;

                            }
                            else
                            {
                                nw_stk = 0;
                            }
                            string s4 = "update product set pro_stock=" + nw_stk + " where product_id=" + prdt_id + "";
                            int j = OBJ.fn_nonquery(s4);
                            string s5 = "select pro_stock from product";
                            string t = OBJ.fn_scalar(s5);
                            int sta = Convert.ToInt32(t);

                            if (sta == 0)
                            {
                                string s6 = "update product set pro_status='unavailable' where product_id=" + prdt_id + "";
                                int x = OBJ.fn_nonquery(s6);

                            }

                        }
                    }
                }

            }
            else
            {
                Label4.Text = "insufficient balance";
            }




        }
    }
}

        