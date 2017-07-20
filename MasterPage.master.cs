using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class MasterPage : System.Web.UI.MasterPage
{
    conection co = new conection();
    protected void Page_Load(object sender, EventArgs e)
    {
        gallery();
    }
   
    protected void gallery()
    {co.connect();

       
    SqlCommand cmd = new SqlCommand("gallary", co.con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@action", SqlDbType.Int).Value = 1;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds);
         if (ds.Tables[0].Rows.Count > 0)
        
       
        {
            DataList1.DataSource = ds.Tables[0];
            DataList1.DataBind();

        
        }


    
    }
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    co.connect();
    //    SqlCommand cmd = new SqlCommand("contactus", co.con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TextBox1.Text.ToString();
    //    cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = TextBox2.Text.ToString();
    //    //cmd.Parameters.Add("@phone", SqlDbType.VarChar, 50).Value = TextBox3.Text.ToString();
    //    cmd.Parameters.Add("@message", SqlDbType.VarChar, 50).Value = TextBox3.Text.ToString();
    //    cmd.Parameters.Add("@action", SqlDbType.Int).Value = 3;
    //    cmd.ExecuteNonQuery();

    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        co.connect();
        SqlCommand cmd = new SqlCommand("contactus", co.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TextBox1.Text.ToString();
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = TextBox2.Text.ToString();
        //cmd.Parameters.Add("@phone", SqlDbType.VarChar, 50).Value = TextBox3.Text.ToString();
        cmd.Parameters.Add("@message", SqlDbType.VarChar, 50).Value = TextBox3.Text.ToString();
        cmd.Parameters.Add("@action", SqlDbType.Int).Value = 3;
        cmd.ExecuteNonQuery();
    }
}
