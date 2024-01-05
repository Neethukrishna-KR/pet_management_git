using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace pet_management
{
    public class connectionclass
    {
        SqlConnection con;
        SqlCommand cmd;
        public connectionclass()
        {
            con = new SqlConnection(@"server=DESKTOP-TPI4UB0\SQLEXPRESS;database=pro_gro;Integrated security=true");
        }
        public int fn_nonquery(string sqlQuery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string fn_scalar(string sqlQuery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }
        public SqlDataReader fn_reader(string sqlQuery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;


        }
        public DataSet fn_dataset(string sqlQuery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataTable fn_datatable(string sqlQuery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}