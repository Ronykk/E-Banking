using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UserDashford : System.Web.UI.Page
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

                DataTable acc_type = cls.fillDataTable("select AccountType,total_balance from edetails d, eaccount a where d.ID = '" + Session["UserId"] + "' and d.DelFlag=0 and d.ID=a.ID and d.DelFlag=a.DelFlag; ");

                if (acc_type.Rows.Count > 0)
                {
                    if (acc_type.Rows[0]["AccountType"].ToString() == "Saving" && Convert.ToInt32(acc_type.Rows[0]["total_balance"]) < 2000)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You have Low Balance!!', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                    }
                    else if (acc_type.Rows[0]["AccountType"].ToString() == "Current" && Convert.ToInt32(acc_type.Rows[0]["total_balance"]) < 10000)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You have Low Balance!!', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                    }
                }
            }

            Session["depositAmount"] = "";
            Session["withdrawAmount"] = "";
            txt_deposit.Text = "";
            txt_withdraw.Text = "";
        }
    }


    public void showdata()
    {
        DataTable account_details = cls.fillDataTable("select * from eaccount where ID = '" + Session["UserId"] + "' and DelFlag = 0");

        if (account_details.Rows.Count > 0)
        {
            lbl_cred.Text = account_details.Rows[0]["credited"].ToString();
            lbl_debit.Text = account_details.Rows[0]["debited"].ToString();
            lbl_balance.Text = account_details.Rows[0]["total_balance"].ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }

    protected void btn_withd_Click(object sender, EventArgs e)
    {
        if (txt_withdraw.Text.Trim().All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        if (txt_withdraw.Text.Trim() != "")
        {
            Session["withdrawAmount"] = txt_withdraw.Text.Trim();
        }
        else
        {
            Session["withdrawAmount"] = "";
        }

        Response.Redirect("withdraw.aspx");
    }

    protected void btn_dep_Click(object sender, EventArgs e)
    {
        if (txt_deposit.Text.Trim().All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        if (txt_deposit.Text.Trim() != "")
        {
            Session["depositAmount"] = txt_deposit.Text.Trim();
        }
        else
        {
            Session["depositAmount"] = "";
        }

        Response.Redirect("deposit.aspx");
    }
}