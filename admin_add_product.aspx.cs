using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_add_product : System.Web.UI.Page
{
    conection obj = new conection();
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obj.connect();
        
      string pp=FileUpload1.FileName.ToString();
        string pf=FileUpload2.FileName.ToString();
        FileUpload1.SaveAs(Server.MapPath("~/productimage/" + pp));
        FileUpload2.SaveAs(Server.MapPath("~/productfile/" + pf));
          
            cmd = new SqlCommand("addproduct", obj.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pro_image", SqlDbType.VarChar, 200).Value ="~/productimage/" + FileUpload1.FileName.ToString();
            cmd.Parameters.Add("@pro_name", SqlDbType.VarChar, 100).Value = txt_name.Text.ToString();
            cmd.Parameters.Add("@pro_category", SqlDbType.VarChar, 100).Value = DropDownList1.SelectedItem.Text.ToString();
            cmd.Parameters.Add("@pro_technology", SqlDbType.VarChar, 100).Value = txt_tech.Text.ToString();
            cmd.Parameters.Add("@operating", SqlDbType.VarChar, 100).Value = TextBoxoperating.Text.ToString();
            cmd.Parameters.Add("@about", SqlDbType.VarChar, 500).Value = txt_about.Text.ToString();
           
            cmd.Parameters.Add("@price", SqlDbType.Int).Value = txt_price.Text.ToString();

            cmd.Parameters.Add("@pro_file", SqlDbType.VarChar, 500).Value ="~/productfile/" + FileUpload2.FileName.ToString();
            cmd.Parameters.Add("@action", SqlDbType.Int).Value = 1;
            cmd.ExecuteNonQuery();
       

        


    }
}