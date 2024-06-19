using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class deposit : System.Web.UI.Page
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
                if (Session["depositAmount"] != null)
                {
                    if (Session["depositAmount"].ToString() != "")
                    {
                        txt_amt.Text = Session["depositAmount"].ToString().Trim();
                        Session["depositAmount"] = "";
                    }
                }
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
            txt_bal.Text = userdata.Rows[0]["total_balance"].ToString(); ;

            if (userdata.Rows[0]["Pin"].ToString() == "" || userdata.Rows[0]["Pin"].ToString() == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You have not generated Pin, Kindly generate the Pin for transaction.', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
    }


    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        string amount = txt_amt.Text.Trim();

        if (amount.All(char.IsDigit) == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Only Number', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }

        if (amount == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Amount', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (ddl_bank.SelectedValue.ToString() == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Bank', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else
        {
            if (Convert.ToInt32(amount) > 10000)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Amount Should be Less than 10000', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                txt_amt.Text = "";
                return;
            }
            else if (Convert.ToInt32(amount) < 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Amount Should be Greater than 00', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                txt_amt.Text = "";
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

                Session["depositAmount"] = amount;
                Response.Redirect("pin_authentication.aspx");
            }
        }
    }
}