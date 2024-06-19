using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Mail;

public partial class Registration : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_firstName.Text = "";
            txt_LastName.Text = "";
            txt_Email.Text = "";
            txt_Password.Text = "";
            txt_ConfirmPassword.Text = "";
        }
    }

    protected void btn_register_Click(object sender, EventArgs e)
    {
        string FirstName = txt_firstName.Text.Trim();
        string LastName = txt_LastName.Text.Trim();
        string Email = txt_Email.Text.Trim();
        string Password = txt_Password.Text.Trim();
        string Confirm_password = txt_ConfirmPassword.Text.Trim();
        string MobineNo = txt_mobile.Text.Trim();

        if (FirstName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter First Name', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (LastName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Last Name', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (Email == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Email Id', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (MobineNo == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Mobile No', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (Password == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Password', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (Confirm_password == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Confirm Password', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        if (MobineNo.All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else
        {
            if (Password == Confirm_password)
            {
                DataTable id_chk = cls.fillDataTable("select max(cast(substring(id,6,3) as int)) from eLogin");
                int id = Convert.ToInt32(id_chk.Rows[0][0]) + 1;

                DataTable account_chk = cls.fillDataTable("select max(cast(substring(AccountNo,11,4) as int)) from edetails");
                int account_no = Convert.ToInt32(account_chk.Rows[0][0]) + 1;

                string id_len = "";
                if (id < 10)
                {
                    id_len = "EBANK00" + id;
                }
                else if (id < 100)
                {
                    id_len = "EBANK0" + id;
                }
                else if (id < 1000)
                {
                    id_len = "EBANK" + id;
                }

                DataTable email_chk = cls.fillDataTable("select * from eLogin where (Email = '" + Email + "' or MobileNo = '" + MobineNo + "');");

                if (email_chk.Rows.Count <= 0)
                {
                    string encry_pass = cls.encrypt(Password);
                    string userip = Dns.GetHostAddresses(Environment.MachineName)[1].ToString();
                    string username = cls.GetCompCode();

                    string qry = "insert into eLogin values('" + id_len + "','" + FirstName + "','" + LastName + "','" + Email + "','" + encry_pass + "',GETDATE(),Null,0,'" + MobineNo + "'); insert into edetails values('" + id_len + "','3190010002" + account_no + "','','','',GetDate(),Null,0,''); insert into eaccount (ID,debited,credited,total_balance,loan_amount,EntryDate,DeleteDate,DelFlag) values('" + id_len + "','00','00','00','00',GETDATE(),Null,0); insert into einfo (ID,User_IP,User_PC,EntryDate) values ('" + id_len + "','" + userip + "','" + username + "',GETDATE())";

                    if (cls.DMLqueries(qry))
                    {
                        string fromMail = "";
                        string fromPassword = "";

                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(fromMail);
                        message.Subject = "Registered Successfully on [ " + DateTime.Now + " ]";
                        message.To.Add(new MailAddress(Email));
                        message.Body = "<html><body> Welcome to E-Banking!! You Registered Successfully...<br/> Your <b>User ID</b> is <span style='color: red'>" + id_len + "</span> <br/> <b>Account Number </b> is <span style='color: red'> 3190010002" + account_no + "</span> <br/> for E-Banking Application. </body></html>";
                        message.IsBodyHtml = true;

                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential(fromMail, fromPassword),
                            EnableSsl = true,
                        };

                        smtpClient.Send(message);

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Registred Successfully... Your User Id is " + id_len + " and other details Sent on Email.', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);

                        txt_firstName.Text = "";
                        txt_LastName.Text = "";
                        txt_Email.Text = "";
                        txt_Password.Text = "";
                        txt_ConfirmPassword.Text = "";
                        txt_mobile.Text = "";
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('User Already Exists', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                    txt_Email.Text = "";
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Password Not Matching', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }

    }
}