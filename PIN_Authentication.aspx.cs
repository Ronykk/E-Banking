using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PIN_Authentication : System.Web.UI.Page
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
                if (Session["withdrawAmount"] == null)
                {
                    Session["withdrawAmount"] = "";
                }
                if (Session["depositAmount"] == null)
                {
                    Session["depositAmount"] = "";
                }
                    checkpin();
            }
        }
    }

    public void checkpin()
    {
        DataTable userdata = cls.fillDataTable("select Pin,AccountNo from edetails where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0; ");

        if (userdata.Rows.Count > 0)
        {
            if (userdata.Rows[0]["Pin"].ToString() != "")
            {
                txt_accno.Text = userdata.Rows[0]["AccountNo"].ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You Need To Generate PIN', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
    }

    protected void chk_pin_Click(object sender, EventArgs e)
    {
        string acc_pin = txt_newpin.Text.Trim();

        if (acc_pin != "")
        {
            DataTable userdata = cls.fillDataTable("select Pin,AccountNo from edetails where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0; ");
            DataTable txn_id = cls.fillDataTable("select max(cast(substring(transaction_id,10,4) as int)) from etransaction where DelFlag = 0");

            int txngenerate_id = Convert.ToInt32(txn_id.Rows[0][0]) + 1;
            string newtxn_id = "";

            if (txngenerate_id < 10)
            {
                newtxn_id = "EBANK2038000" + txngenerate_id;
            }
            else if (txngenerate_id + 1 < 100)
            {
                newtxn_id = "EBANK203800" + txngenerate_id;
            }
            else if (txngenerate_id < 1000)
            {
                newtxn_id = "EBANK20380" + txngenerate_id;
            }
            else if (txngenerate_id < 10000)
            {
                newtxn_id = "EBANK2038" + txngenerate_id;
            }

            if (acc_pin == userdata.Rows[0]["Pin"].ToString().Trim())
            {
                if (Session["depositAmount"].ToString() != "")
                {
                    string qry = "update eaccount set credited = '" + Session["depositAmount"] + "', total_balance = cast((select total_balance from eaccount where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0) as int) + '" + Convert.ToInt32(Session["depositAmount"]) + "' where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0; insert into etransaction (transaction_id,ID,Amount,Reason,EntryDate,DeleteDate,DelFlag) values ('" + newtxn_id + "','" + Session["UserId"].ToString() + "','" + Session["depositAmount"] + "','Deposit',GETDATE(),Null,0)";

                    if (cls.DMLqueries(qry))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Rs. " + Session["depositAmount"] + " Deposited Successfully', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);
                        Session["depositAmount"] = "";

                        //await Task.Delay(5000);
                        //System.Threading.Thread.Sleep(2000);
                        //Response.Redirect("userdashboard.aspx");
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
                else if (Session["withdrawAmount"].ToString() != "")
                {
                    string qry = "update eaccount set debited = '" + Session["withdrawAmount"] + "', total_balance = cast((select total_balance from eaccount where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0) as int) - '" + Convert.ToInt32(Session["withdrawAmount"]) + "' where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0; insert into etransaction (transaction_id,ID,Amount,Reason,EntryDate,DeleteDate,DelFlag) values ('" + newtxn_id + "','" + Session["UserId"].ToString() + "','" + Session["withdrawAmount"] + "','Withdraw',GETDATE(),Null,0)";

                    if (cls.DMLqueries(qry))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Rs. " + Session["withdrawAmount"] + " Withdraw Successfully', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);
                        Session["withdrawAmount"] = "";
                        //System.Threading.Thread.Sleep(2000);
                        //Response.Redirect("userdashboard.aspx");
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
                else if (Session["TransferedAmount"].ToString() != "" && Session["TransferedAccount"].ToString() != "")
                {
                    if (Session["TransferedAccount"].ToString() != userdata.Rows[0]["AccountNo"].ToString())
                    {
                        DataTable recipient_data = cls.fillDataTable("select * from edetails where AccountNo = '" + Session["TransferedAccount"] + "' and DelFlag=0; ");
                        DataTable amount = cls.fillDataTable("select * from eaccount where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0");

                        if (amount.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(amount.Rows[0]["total_balance"]) > Convert.ToInt32(Session["TransferedAmount"]))
                            {
                                if (recipient_data.Rows.Count > 0)
                                {
                                    string debit_qry = "update eaccount set debited = '" + Session["TransferedAmount"] + "', total_balance = cast((select total_balance from eaccount where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0) as int) - '" + Convert.ToInt32(Session["TransferedAmount"]) + "' where ID = '" + Session["UserId"].ToString() + "' and DelFlag=0; insert into etransaction (transaction_id,ID,Amount,Reason,EntryDate,DeleteDate,DelFlag) values ('" + newtxn_id + "','" + Session["UserId"].ToString() + "','" + Session["TransferedAmount"] + "','Money Send To " + Session["TransferedAccount"] + "',GETDATE(),Null,0); ";

                                    if (cls.DMLqueries(debit_qry))
                                    {
                                        DataTable txn_id1 = cls.fillDataTable("select max(cast(substring(transaction_id,10,4) as int)) from etransaction where DelFlag = 0");

                                        int txngenerate_id1 = Convert.ToInt32(txn_id1.Rows[0][0]) + 1;
                                        string newtxn_id1 = "";

                                        if (txngenerate_id1 < 10)
                                        {
                                            newtxn_id1 = "EBANK2038000" + txngenerate_id1;
                                        }
                                        else if (txngenerate_id1 + 1 < 100)
                                        {
                                            newtxn_id1 = "EBANK203800" + txngenerate_id1;
                                        }
                                        else if (txngenerate_id1 < 1000)
                                        {
                                            newtxn_id1 = "EBANK20380" + txngenerate_id1;
                                        }
                                        else if (txngenerate_id1 < 10000)
                                        {
                                            newtxn_id1 = "EBANK2038" + txngenerate_id1;
                                        }

                                        string credit_qry = "update eaccount set credited = '" + Session["TransferedAmount"] + "', total_balance = cast((select total_balance from eaccount where ID = '" + recipient_data.Rows[0]["ID"] + "' and DelFlag=0) as int) + '" + Convert.ToInt32(Session["TransferedAmount"]) + "' where ID = '" + recipient_data.Rows[0]["ID"] + "' and DelFlag=0; insert into etransaction (transaction_id,ID,Amount,Reason,EntryDate,DeleteDate,DelFlag) values ('" + newtxn_id1 + "','" + recipient_data.Rows[0]["ID"] + "','" + Session["TransferedAmount"] + "','Credited From " + userdata.Rows[0]["AccountNo"].ToString() + "',GETDATE(),Null,0); ";

                                        if (cls.DMLqueries(credit_qry))
                                        {
                                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Rs. " + Session["TransferedAmount"] + " Transfered Successfully', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);

                                            Session["TransferedAmount"] = "";
                                            return;
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                                        return;
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Receiver Account Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You have Not Enough Money for this transaction.', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                                return;
                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('You Can Not Transfer Money To Yourself', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                    Response.Redirect("userdashboard.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Incorrect Pin', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Account Pin', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }
}