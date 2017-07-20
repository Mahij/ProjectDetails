using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class contactus : System.Web.UI.Page
{
    conection obj = new conection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void Button1_Click1(object sender, EventArgs e)
    {

        obj.connect();
        SqlCommand cmd = new SqlCommand("contactus", obj.con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@action", SqlDbType.Int).Value = 1;
      
        cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TextBox1.Text.ToString();
        cmd.Parameters.Add("@phone", SqlDbType.VarChar, 50).Value = TextBox2.Text.ToString();
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = TextBox3.Text.ToString();
        cmd.Parameters.Add("@message", SqlDbType.VarChar, 50).Value = TextBox4.Text.ToString();
        int rm=cmd.ExecuteNonQuery();
        if (rm > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Thanku,Your Message Has Been Sent');", true);
            rm = 0;
            obj.con.Close();
            cmd.Dispose();
 

        }
        
        

    }
}