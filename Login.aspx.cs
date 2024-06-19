using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_userid.Text = "";
            txt_Password.Text = "";
            Session["UserId"] = "";
            Session["UserName"] = "";
            Session["Email"] = "";
        }
    }

    public void validate()
    {
        string userId = txt_userid.Text.Trim();
        string password = txt_Password.Text.Trim();

        if (userId == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter User Id', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (password == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Password', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else
        {
            string decrypt_pass = "";
            DataTable id_chk = cls.fillDataTable("select * from eLogin where ID = '" + userId + "';");

            if (id_chk.Rows.Count > 0)
            {
                decrypt_pass = cls.Decrypt(id_chk.Rows[0]["Password"].ToString().Trim());

                if (decrypt_pass == password)
                {
                    if (Convert.ToBoolean(id_chk.Rows[0]["DelFlag"]) == false)
                    {
                        Session["UserId"] = userId.ToUpper();
                        Session["Email"] = id_chk.Rows[0]["Email"].ToString();
                        Session["UserName"] = id_chk.Rows[0]["FirstName"].ToString().Trim() + " " + id_chk.Rows[0]["LastName"].ToString().Trim();

                        string userip = Dns.GetHostAddresses(Environment.MachineName)[1].ToString();
                        string username = cls.GetCompCode();

                        if (cls.DMLqueries("insert into einfo (ID,User_IP,User_PC,EntryDate) values ('" + Session["UserId"] + "','" + userip + "','" + username + "',GETDATE())"))
                        {
                            Response.Redirect("User_profile.aspx");

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Your Account is deactivated, Kindly contact to Admin', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Credentials', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                    txt_userid.Text = "";
                    txt_Password.Text = "";
                    return;
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Credentials', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                txt_userid.Text = "";
                txt_Password.Text = "";
                return;
            }
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        validate();
    }
}