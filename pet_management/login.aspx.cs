using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pet_management
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();
            
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Regid) from loginn where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string uid = obj.fn_scalar(str);
            int uid1 = Convert.ToInt32(uid);
            if (uid == "1")
            {
                string str1= "select Regid from loginn where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string regid = obj.fn_scalar(str1);
                Session["userid"] = regid;
                string str2 = "select logtype from loginn where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string logtype = obj.fn_scalar(str2);
                if (logtype == "admin")
                {
                    Response.Redirect("adminhome.aspx");
                }
                else if (logtype == "user")
                {
                    Response.Redirect("userhome.aspx");
                }
                else
                {
                    Label5.Visible = true;
                    Label5.Text = "invalid username or password";
                }
            }
        }
    }
}