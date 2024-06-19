using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Metadata;
using System.IO;

public partial class generate_report : System.Web.UI.Page
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

    public void showdata()
    {
        DataTable showdata = cls.fillDataTable("select AccountNo,total_balance,AccountType from edetails d, eaccount a where a.ID = '" + Session["UserId"] + "' and a.ID=d.ID and a.DelFlag=0 and a.DelFlag=d.DelFlag;");

        if (showdata.Rows.Count > 0)
        {
            txt_accno.Text = showdata.Rows[0]["AccountNo"].ToString();
            txt_acctype.Text = showdata.Rows[0]["AccountType"].ToString(); ;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txt_to_date.Text = "";
        txt_from_date.Text = "";
        rd_full_type.Checked = false;
        rd_cred_type.Checked = false;
        rd_deb_type.Checked = false;
    }

    protected void btn_gen_rep_Click(object sender, EventArgs e)
    {
        string fromdate = txt_from_date.Text.Trim();
        string todate = txt_to_date.Text.Trim();

        if (fromdate == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter From Date', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (todate == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter To Date', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (rd_full_type.Checked == false && rd_cred_type.Checked == false && rd_deb_type.Checked == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Report Type', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else
        {
            string transactions_report = "select transaction_id [Transaction Number],Amount,Reason [Transaction Details],EntryDate [Transaction Date] from etransaction where ID = '" + Session["UserId"] + "' and DelFlag=0 ";

            if (rd_cred_type.Checked == true)
            {
                transactions_report = transactions_report + "and (Reason like '%Deposit%' or Reason like '%credited%'); ";
            }
            else if (rd_deb_type.Checked == true)
            {
                transactions_report = transactions_report + "and (Reason like '%Withdraw%' or Reason like '%send%'); ";
            }

            DataTable report = cls.fillDataTable(transactions_report);

            if (report.Rows.Count > 0)
            {
                grd_data.DataSource = report;
                grd_data.DataBind();
                grd_data.HeaderRow.TableSection = TableRowSection.TableHeader;

                GeneratePDF();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
    }

    private void GeneratePDF()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=AccountDetails.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_data.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.End();
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void btn_history_Click(object sender, EventArgs e)
    {
        Response.Redirect("transaction_history.aspx");
    }
}