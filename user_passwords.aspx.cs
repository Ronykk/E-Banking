using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class user_passwords : System.Web.UI.Page
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
        DataTable showdata = cls.fillDataTable("select ID [User_Id],FirstName + ' ' + LastName [User_Name],Email [User_Email],MobileNo [User_Mobile] from eLogin where ID <> 'Admin' order by ID; ");
        DataTable userip = cls.fillDataTables("select * from einfo");

        if (showdata.Rows.Count > 0)
        {
            grd_data.DataSource = showdata;
            grd_data.DataBind();
            grd_data.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }

    protected void btn_view_pass_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        Label lbl_id = (Label)row.FindControl("User_Id") as Label;

        if (lbl_id.Text.Trim() != "")
        {
            DataTable user_details = cls.fillDataTable("select l.ID,l.Password,d.AccountNo from eLogin l, edetails d where l.ID = '" + lbl_id.Text.Trim() + "' and l.ID=d.ID; ");

            if (user_details.Rows.Count > 0)
            {
                string decrypt_pass = cls.Decrypt(user_details.Rows[0]["Password"].ToString().Trim());

                txt_usraccno.Text = user_details.Rows[0]["AccountNo"].ToString();
                txt_usrid.Text = user_details.Rows[0]["ID"].ToString();
                txt_usrpasss.Text = decrypt_pass;
                showdata();

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('User Details Found', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);

                txt_usraccno.Text = "";
                txt_usrid.Text = "";
                txt_usrpasss.Text = "";
                showdata();
                return;
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }
}