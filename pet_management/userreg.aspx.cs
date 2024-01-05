using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pet_management
{
    public partial class userreg : System.Web.UI.Page
    {
        connectionclass obj = new connectionclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strn = "select max(Regid) from loginn";
            string regid = obj.fn_scalar(strn);
            int Regid = 0;
            if (regid == "")
            {
                Regid = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                Regid = newregid + 1;
            }
            string str = "insert into userr values(" + Regid + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox8.Text + "','" + TextBox7.Text + "')";
            int j = obj.fn_nonquery(str);
            if (j == 1)
            {
                Label8.Visible = true;
                Label8.Text = "Registered succesfully";

            }
            string inslg = "insert into loginn values(" + Regid + ",'" + TextBox9.Text + "','" + TextBox10.Text + "','user','active')";
            int i = obj.fn_nonquery(inslg);
        }
    }
}