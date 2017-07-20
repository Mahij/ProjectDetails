using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class admingallery : System.Web.UI.Page
{
    conection co = new conection();
    int x;
    protected void Page_Load(object sender, EventArgs e)
    {
        databind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        co.connect();
        string ph = "~/gallary/" + FileUpload1.FileName.ToString();
        string stt = "insert into gallery (image) values('" + ph + "')";
        SqlCommand cmd = new SqlCommand(stt, co.con);
        int r = cmd.ExecuteNonQuery();
        if (r > 0)
        {

            string ss = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/gallary/") + ss);

        }


    }
    protected void gvdel(object sender, GridViewDeleteEventArgs e)
    {
        co.connect();
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

        SqlCommand cmd = new SqlCommand("delete from gallery where id=" + id, co.con);
        int r = cmd.ExecuteNonQuery();
        if (r > 0)
        {


            databind();
        }


    }
    protected void gvup(object sender, GridViewUpdateEventArgs e)
    {

        co.connect();
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        SqlCommand cmd = new SqlCommand("select status from gallery where id=" + id, co.con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {

                Session["condition"] = dr[0].ToString();
               }
        
        }
        dr.Close();
            


        if (Session["condition"].ToString() == "1")
        {
            SqlCommand cmda = new SqlCommand("update gallery set status=0 where id=" + id, co.con);
            int r = cmda.ExecuteNonQuery();
            if (r > 0)
            {

                databind();
            }
        }
        else
        {

            SqlCommand cmds = new SqlCommand("update gallery set status=1 where id=" + id, co.con);
            int r = cmds.ExecuteNonQuery();
            if (r > 0)
            {

                databind();
            }
        
        }

    }
    protected void databind()
    {

        co.connect();
        string stt = "select * from gallery";
        SqlCommand cmd = new SqlCommand(stt, co.con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();


        }
        else
        {

            GridView1.Visible = false;
        
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}