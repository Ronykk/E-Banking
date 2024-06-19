using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ManageUsers : System.Web.UI.Page
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
        DataTable showdata = cls.fillDataTable("select ID [User_Id],FirstName + ' ' + LastName [User_Name],Email [User_Email],MobileNo [User_Mobile],case when DelFlag=1 then 'Deactivated' else 'Activated' end as DelFlag from eLogin where ID <> 'Admin' order by ID; ");

        if (showdata.Rows.Count > 0)
        {
            grd_data.DataSource = showdata;
            grd_data.DataBind();
            grd_data.HeaderRow.TableSection = TableRowSection.TableHeader;
            for (int i = 0; i < grd_data.Rows.Count; i++)
            {
                Label lbl_active = (Label)grd_data.Rows[i].FindControl("DelFlag");
                LinkButton btn_active = (LinkButton)grd_data.Rows[i].FindControl("btn_test");
                if(lbl_active.Text == "Deactivated")
                {
                    btn_active.CssClass = "btn btn-success btn-block";
                    btn_active.Text = "Unblock";
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Details Not Found', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
    }



    protected void btn_test_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        Label lbl_id = (Label)row.FindControl("User_Id") as Label;

        if (lbl_id.Text.Trim() != "")
        {
            DataTable del_chk = cls.fillDataTable("select * from eLogin where ID = '" + lbl_id.Text + "'; ");


            if (del_chk.Rows.Count > 0)
            {
                if (Convert.ToBoolean(del_chk.Rows[0]["DelFlag"]) == false)
                {
                    string del_user = "update eLogin set DelFlag=1, DeleteDate = GETDATE() where ID = '" + lbl_id.Text + "'; update eaccount set DelFlag=1, DeleteDate = GETDATE() where ID = '" + lbl_id.Text + "'; update edetails set DelFlag=1, DeleteDate = GETDATE() where ID = '" + lbl_id.Text + "'; update etransaction set DelFlag=1, DeleteDate = GETDATE() where ID = '" + lbl_id.Text + "'; ";

                    if (cls.DMLqueries(del_user) == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('User Deleted Successfully', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);
                        showdata();
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
                else if (Convert.ToBoolean(del_chk.Rows[0]["DelFlag"]) == true)
                {
                    string rec_user = "update eLogin set DelFlag=0, DeleteDate = GETDATE() where ID = '" + lbl_id.Text + "'; update eaccount set DelFlag=0, DeleteDate = GETDATE() where ID = '" + lbl_id.Text + "'; update edetails set DelFlag=0, DeleteDate = GETDATE() where ID = '" + lbl_id.Text + "'; update etransaction set DelFlag=0, DeleteDate = GETDATE() where ID = '" + lbl_id.Text + "'; ";

                    if (cls.DMLqueries(rec_user) == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('User Recover Successfully', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);
                        showdata();
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
    }
}