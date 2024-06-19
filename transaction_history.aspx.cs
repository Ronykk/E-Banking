using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class transaction_history : System.Web.UI.Page
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
        DataTable userdata = cls.fillDataTable("select transaction_id,Amount,Reason,EntryDate from etransaction where ID = '" + Session["UserId"] + "' order by transaction_id;");
        DataTable showdata = cls.fillDataTable("select AccountNo,total_balance,AccountType from edetails d, eaccount a where a.ID = '" + Session["UserId"] + "' and a.ID=d.ID and a.DelFlag=0 and a.DelFlag=d.DelFlag;");

        if (userdata.Rows.Count > 0)
        {
            txt_accno.Text = showdata.Rows[0]["AccountNo"].ToString();
            txt_bal.Text = showdata.Rows[0]["total_balance"].ToString();
            txt_acctype.Text = showdata.Rows[0]["AccountType"].ToString();

            grd_data.DataSource = userdata;
            grd_data.DataBind();
            grd_data.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }
}