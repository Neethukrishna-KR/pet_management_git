//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data;
//using System.Data.SqlClient;

//namespace pet_management
//{
//    public partial class cartviewu : System.Web.UI.Page
//    {
//        connectionclass obj = new connectionclass();
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                gridbind();
//            }
//        }
//        public void gridbind()
//        {
//            string str = "select product.pro_name,product.pro_image,cart.* from cart join product on product.product_id=cart.product_id where Regid=" + Session["userid"] + "";
//            DataSet ds = obj.fn_dataset(str);
//            GridView1.DataSource = ds;
//            GridView1.DataBind();
//        }

//        protected void LinkButton1_Command(object sender, CommandEventArgs e)
//        {
//            int id = Convert.ToInt32(e.CommandArgument);
//            string del = "delete from cart where cart_id=" + id + "";
//            int j = obj.fn_nonquery(del);
//            gridbind();
//        }
//    }
//}