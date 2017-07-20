using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;

public partial class User_ForgotPass : System.Web.UI.Page
{
    Connection co = new Connection();
    DataSet ds;
    SqlCommand cmd;
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btnforget_Click(object sender, EventArgs e)
    {
        co.connect();
        string stt="select emailid,password,name from user_regis where emailid='"+Txtemail.Text+"'";
        SqlCommand cmd=new SqlCommand(stt,co.con);
        SqlDataReader dr;
        dr=cmd.ExecuteReader();
        if(dr.HasRows)
        {
        
            while(dr.Read())
            {
             try
            {
                MailMessage mailmessage = new MailMessage();
                mailmessage.To.Add(Txtemail.Text.Trim());
                mailmessage.From = new MailAddress("jaiswalmahima29@gmail.com", "Appstore");
                mailmessage.Subject = "Reset your Password";
                mailmessage.Body = "Dear" + dr[2].ToString() + "Your Email is" + Txtemail.Text + "Your password is" +dr[1].ToString();
                SmtpClient smtpclient = new SmtpClient();
                smtpclient.Host = "smtp.gmail.com";
                smtpclient.EnableSsl = true;
                smtpclient.Port = 587;
                smtpclient.UseDefaultCredentials = true;
                smtpclient.Credentials = new System.Net.NetworkCredential("jaiswalmahima29@gmail.com", "hdjg");
                smtpclient.Send(mailmessage);
                //smtpclient.Port = 587;
                //smtpclient.Send(mailmessage);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Message Send Successfully');", true);
                //lbl_sendmail.Text = "Message Send Successfully";
                //lbl_sendmail.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Message sending failed');", true);
                //lbl_sendmail.Text = "Message sending failed";
                //lbl_sendmail.Visible = true;
            }
            }

        }

       else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Mail does'nt match');", true);
            //lbl_sendmail.Text = "Mail doesn't match with the records";
        }
    }
}