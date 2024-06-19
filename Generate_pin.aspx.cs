using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

public partial class Generate_pin : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["UserId"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                showdata();
            }
        }
    }

    protected void btn_genpin_Click(object sender, EventArgs e)
    {
        string pin = txt_newpin.Text.ToString();
        string repin = txt_confpin.Text.Trim();

        if (pin == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter New Pin', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (repin == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Pin', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (pin.All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (repin.All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else
        {
            if (pin.Length == 4 && repin.Length == 4)
            {
                if (pin == repin)
                {
                    cls.DMLqueries("update edetails set pin = '" + pin + "' where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0;");

                    string fromMail = "vivekupadaya@gmail.com";
                    string fromPassword = "ooidgzctgiuepsnr";

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(fromMail);
                    message.Subject = "PIN Generated Successfully on [ " + DateTime.Now + " ]";
                    message.To.Add(new MailAddress("ronishkhan1997@gmail.com"));
                    message.Body = "<html><body> Welcome to E-Banking!! Your PIN Generated Successfully...<br/> Your <b>User ID</b> is <span style='color: red'>" + Session["UserId"].ToString() + "</span> <br/> <b>PIN No </b> is <span style='color: red'>" + pin + "</span> <br/> for E-Banking Application. </body></html>";
                    message.IsBodyHtml = true;

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromMail, fromPassword),
                        EnableSsl = true,
                    };

                    smtpClient.Send(message);

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('PIN Generated Successfully... Details Sent on Email', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);

                    showdata();
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('PIN Are Not Matching', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('PIN Length Must be 4 Digit.', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
    }


    public void showdata()
    {
        DataTable userdata = cls.fillDataTable("select AccountNo,AccountType,Pin from edetails where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0 ");

        if (userdata.Rows.Count > 0)
        {
            txt_accno.Text = userdata.Rows[0]["AccountNo"].ToString();
            txt_acctype.Text = userdata.Rows[0]["AccountType"].ToString();

            if (txt_acctype.Text == "")
            {
                Response.Redirect("User_profile.aspx");
            }

            if (userdata.Rows[0]["Pin"].ToString() != "")
            {
                txt_newpin.Enabled = false;
                txt_confpin.Enabled = false;
                btn_genpin.Enabled = false;

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You have already generated Pin, If you forget Pin Click on Resend Pin Button', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
            else
            {
                btn_updatepin.Enabled = false;
            }
        }
        
    }

    protected void btn_updatepin_Click(object sender, EventArgs e)
    {
        DataTable userdata = cls.fillDataTable("select AccountNo,AccountType,Pin from edetails where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0 ");

        if (userdata.Rows.Count > 0)
        {
            if (userdata.Rows[0]["Pin"].ToString() != "")
            {
                string fromMail = "vivekupadaya@gmail.com";
                string fromPassword = "ooidgzctgiuepsnr";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = "Resend PIN on [ " + DateTime.Now + " ]";
                message.To.Add(new MailAddress("ronishkhan1997@gmail.com"));
                message.Body = "<html><body> Welcome to E-Banking!! Your PIN Sent Successfully...<br/> Your <b>User ID</b> is <span style='color: red'>" + Session["UserId"].ToString() + "</span> <br/> <b>PIN No </b> is <span style='color: red'>" + userdata.Rows[0]["Pin"].ToString() + "</span> <br/> for E-Banking Application. </body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('PIN Sent on Email', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Kindly Generate PIN', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }
}