using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pet_management
{
    public partial class adminreg : System.Web.UI.Page
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


            string str = "insert into admin values ("+Regid+",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
            int i = obj.fn_nonquery(str);
            if (i == 1)
            {
                Label5.Visible = true;
                Label5.Text = "Registered succesfully";

            }
            string inslg = "insert into loginn values(" + Regid + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','admin','active')";
            int j = obj.fn_nonquery(inslg);
            


        }
    }
}