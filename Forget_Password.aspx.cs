using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class Forget_Password : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_Email.Text = "";
            System.Threading.Thread.Sleep(2000);
        }
        loader.Visible = false;
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        string Email = txt_Email.Text.Trim();

        if (Email == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Email Id', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else
        {
            DataTable user_details = cls.fillDataTable("select * from eLogin where Email = '" + Email + "';");
            if (user_details.Rows.Count > 0)
            {
                string decrypt_pass = cls.Decrypt(user_details.Rows[0]["Password"].ToString().Trim());

                string fromMail = "";
                string fromPassword = "";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "Reset Password on [ " + DateTime.Now + " ]";
                message.To.Add(new MailAddress(Email));
                message.Body = "<html><body> Password Sent Successfull...<br/> Your <b>User ID</b> is <span style='color: red'>" + user_details.Rows[0]["ID"].ToString() + "</span> <br/> <b>Password </b> is <span style='color: red'>" + decrypt_pass + "</span> <br/> for E-Banking Application. </body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                loader.Visible = true;
                smtpClient.Send(message);
                loader.Visible = false;


                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Password Sent On Email Id', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);
                txt_Email.Text = "";
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Email Id', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
    }
}