using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_profile : System.Web.UI.Page
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
                ShowDetails(Session["UserId"].ToString());
                cls.retrieve_image(Image1, Session["UserId"].ToString());
            }
        }
    }

    protected void btn_modify_Click(object sender, EventArgs e)
    {
        ShowDetails(Session["UserId"].ToString());
        txt_fstname.ReadOnly = false;
        txt_lstname.ReadOnly = false;
        ddl_acctype.Enabled = true;
    }


    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txt_fstname.Text = "";
        txt_lstname.Text = "";
        ddl_acctype.SelectedValue = "";
    }

    public void ShowDetails(string user_id)
    {
        DataTable userdetails = cls.fillDataTable("select l.id,l.FirstName,l.LastName,l.Email,l.MobileNo,d.AccountNo,d.AccountType from eLogin as l,edetails as d where l.ID = '" + user_id + "' and l.DelFlag = 0 and l.ID=d.ID and l.DelFlag=d.DelFlag");

        if (userdetails.Rows.Count > 0)
        {
            txt_accno.Text = userdetails.Rows[0]["AccountNo"].ToString();
            txt_fstname.Text = userdetails.Rows[0]["FirstName"].ToString();
            txt_lstname.Text = userdetails.Rows[0]["LastName"].ToString();
            txt_email.Text = userdetails.Rows[0]["Email"].ToString();
            txt_mobile.Text = userdetails.Rows[0]["MobileNo"].ToString();
            ddl_acctype.SelectedValue = userdetails.Rows[0]["AccountType"].ToString();

            if (userdetails.Rows[0]["AccountType"].ToString() == "")
            {
                ddl_acctype.Enabled = true;
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Account Type', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                return;
            }
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        string FirstName = txt_fstname.Text.Trim();
        string LastName = txt_lstname.Text.Trim();

        if (FirstName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter First Name', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (LastName == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Last Name', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else if (ddl_acctype.SelectedValue.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Account Type', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
            return;
        }
        else
        {
            if (!FileUpload1.HasFile)
            {
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Image', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                //return;
            }
            else
            {
                int size = (FileUpload1.PostedFile.ContentLength);
                if (size > 500000)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Image Size Less Than 100 Kb. ', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                    return;
                }
                else
                {
                    byte[] theImage_pic = new byte[FileUpload1.PostedFile.ContentLength];
                    HttpPostedFile Image = FileUpload1.PostedFile;

                    Image.InputStream.Read(theImage_pic, 0, (int)FileUpload1.PostedFile.ContentLength);
                    int length = theImage_pic.Length;
                    string fileName = FileUpload1.FileName.ToString();

                    try
                    {
                        string sql1;
                        sql1 = "update edetails set UserImg=@img where ID='" + Session["UserId"].ToString() + "'";

                        cls.Conn();
                        SqlCommand cmd = new SqlCommand(sql1, cls.con);
                        SqlParameter[] param = new SqlParameter[2];

                        param[0] = new SqlParameter("@img", SqlDbType.Image, length);
                        param[0].Value = theImage_pic;

                        cmd.Parameters.Add(param[0]);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#802019', background: '#ffb3b3', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
            }

            cls.DMLqueries("update eLogin set FirstName = '" + FirstName + "', LastName = '" + LastName + "' where ID = '" + Session["UserId"].ToString() + "'; update edetails set AccountType = '" + ddl_acctype.SelectedValue + "' where ID = '" + Session["UserId"].ToString() + "';");

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updated Successfully', { color: '#006600', background: '#ccffcc', blur: 0.2, delay: 0 });", true);
            ShowDetails(Session["UserId"].ToString());
            cls.retrieve_image(Image1, Session["UserId"].ToString());
            //Response.Redirect("User_profile.aspx");

            txt_fstname.ReadOnly = true;
            txt_lstname.ReadOnly = true;
            ddl_acctype.Enabled = false;
        }
    }
}
