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
    public partial class p_fullview : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string s = "select * from product where product_id=" + Session["proid"] + "";
                SqlDataReader dr = obj.fn_reader(s);
                while (dr.Read())
                {
                    Label1.Text = dr["pro_name"].ToString();
                    Label2.Text = dr["pro_price"].ToString();
                    Session["proprice"] = dr["pro_price"];
                    Label3.Text = dr["pro_description"].ToString();
                    Label4.Text = dr["pro_status"].ToString();
                    Image1.ImageUrl = dr["pro_image"].ToString();
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userhome.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(Session["proprice"]);
            int q = Convert.ToInt32(TextBox1.Text);
            string s = "insert into cart values(" + Session["proid"] + "," + Session["userid"] + "," + TextBox1.Text + "," + p * q + ")";
            int j = obj.fn_nonquery(s);
            if (j == 1)
            {
                Label6.Visible = true;
                Label6.Text = "inserted";
            }
        }
    }
}