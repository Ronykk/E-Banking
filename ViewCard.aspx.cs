using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ViewCard : System.Web.UI.Page
    
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
        DataTable showdata = cls.fillDataTable("select AccountNo,total_balance,AccountType,FirstName + ' ' + LastName [Name] from edetails d, eaccount a, eLogin l where a.ID = '"+ Session["UserId"] + "' and a.ID=d.ID and l.ID=a.ID and a.DelFlag=0 and a.DelFlag=d.DelFlag and a.DelFlag=l.DelFlag; ");

        if (showdata.Rows.Count > 0)

        {
            lbl_cardno.Text = showdata.Rows[0]["AccountNo"].ToString();
            icard.InnerText = showdata.Rows[0]["AccountNo"].ToString();
            iname.InnerText = showdata.Rows[0]["Name"].ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }
}