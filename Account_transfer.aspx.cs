using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class transaction_page : System.Web.UI.Page
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
                Session["TransferedAmount"] = "";
                Session["TransferedAccount"] = "";
                showdata();
            }
        }
    }

    public void showdata()
    {
        DataTable userdata = cls.fillDataTable("select AccountNo,total_balance,Pin from edetails d, eaccount a where a.ID = '" + Session["UserId"].ToString() + "' and a.ID=d.ID and a.DelFlag=0 and a.DelFlag=d.DelFlag; ");

        if (userdata.Rows.Count > 0)
        {
            txt_accno.Text = userdata.Rows[0]["AccountNo"].ToString();

            if (userdata.Rows[0]["Pin"].ToString() == "" || userdata.Rows[0]["Pin"].ToString() == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You have not generated Pin, Kindly generate the Pin for transaction.', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
    }

    protected void btn_transfer_Click(object sender, EventArgs e)
    {
        string Recipient_account = txt_recipent_acc.Text.Trim();
        string Conf_Recipient_account = txt_conf_recipent_acc.Text.Trim();
        string Recipient_Name = txt_recipent_name.Text.Trim();
        string Amount = txt_amt.Text.Trim();

        if (Recipient_account.All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        if (Conf_Recipient_account.All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        if (Amount.All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }

        if (Recipient_account == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Recipient Account No', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (Conf_Recipient_account == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Confirm Account No', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (Recipient_Name == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Recipient Name', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (Amount == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Amount', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else
        {
            if (Recipient_account != Conf_Recipient_account)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Account Number Not Matching', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
            else
            {
                if (Convert.ToInt32(Amount) > 50000)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Amount Should be Less Than 50,000', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                    return;
                }
                else
                {
                    DataTable pin_chk = cls.fillDataTable("select * from edetails where ID = '" + Session["UserId"].ToString() + "'; ");

                    if (pin_chk.Rows.Count > 0)
                    {
                        if (pin_chk.Rows[0]["Pin"].ToString() == "" || pin_chk.Rows[0]["Pin"].ToString() == null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You have not generated Pin, Kindly generate the Pin for transaction.', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                            return;
                        }
                    }

                    Session["TransferedAmount"] = Amount;
                    Session["TransferedAccount"] = Recipient_account;
                    Response.Redirect("pin_authentication.aspx");
                }
            }
        }
    }
}