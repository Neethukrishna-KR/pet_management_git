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
    public partial class productmanagement : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grid_bind();
            }
            
        }
        public void grid_bind()
       {
           string str = "select  product. * ,category.cat_name from category join product on category.category_id=product.category_id";
           DataSet ds = obj.fn_dataset(str);           
            GridView1.DataSource = ds;
           GridView1.DataBind();
        }

        protected void LinkButton3_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
                       string sel = "select pro_status from product where product_id=" + id + "";
                       string s = obj.fn_scalar(sel);
                        if (s == "available")
                        {
                           string upd = "update product set pro_status='unavailable' where product_id=" + id + "";
                           int i = obj.fn_nonquery(upd);
                if (i == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "blocked";
                }

            }
            else if (s == "unavailable")
            {
                string upd1 = "update product set pro_status='available' where product_id=" + id + "";
                int i = obj.fn_nonquery(upd1);
                if (i == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "unblocked";
                }


            }
            grid_bind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            grid_bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
                       grid_bind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int i = e.RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtpname = (TextBox)GridView1.Rows[i].Cells[1].Controls[0];
            TextBox txtprice = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            TextBox txtdes = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];

            TextBox textstock = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            string str = "update product set pro_name='" + txtpname.Text + "',pro_price=" + txtprice.Text + ",pro_description='" + txtdes.Text + "',pro_stock='" + textstock.Text + "'  where product_id=" + id + "";
            int j = obj.fn_nonquery(str);
            GridView1.EditIndex = -1;
            grid_bind();

        }

        //        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        //        {
        //            int id = Convert.ToInt32(e.CommandArgument);
        //            string sel = "select pro_status from product where product_id=" + id + "";
        //            string s = obj.fn_scalar(sel);
        //            if (s == "available")
        //            {
        //                string upd = "update product set pro_status='unavailable' where product_id=" + id + "";
        //                int i = obj.fn_nonquery(upd);
        //                if (i == 1)
        //                {
        //                    Label1.Visible = true;
        //                    Label1.Text = "blocked";
        //                }

        //            }
        //            else if (s == "unavailable")
        //            {
        //                string upd1 = "update product set pro_status='available' where product_id=" + id + "";
        //                int i = obj.fn_nonquery(upd1);
        //                if (i == 1)
        //                {
        //                    Label1.Visible = true;
        //                    Label1.Text = "unblocked";
        //                }


        //            }
        //            grid_bind();

        //        }

        //        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //        {
        //            GridView1.EditIndex = e.NewEditIndex;
        //            grid_bind();
        //        }

        //        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //        {
        //            GridView1.EditIndex = -1;
        //            grid_bind();
        //        }

        //        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //        {
        //            int i = e.RowIndex;
        //            int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
        //            TextBox txtpname = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
        //            TextBox txtprice = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
        //            TextBox txtdes = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];

        //            TextBox textstock = (TextBox)GridView1.Rows[i].Cells[7].Controls[0];
        //            string str = "update product set pro_name='" + txtpname.Text + "',pro_price="+txtprice.Text+",pro_description='" + txtdes.Text + "',pro_stock='"+textstock.Text+"'  where product_id=" + id + "";
        //            int j = obj.fn_nonquery(str);
        //            GridView1.EditIndex = -1;
        //            grid_bind();
        //        }
    }
}