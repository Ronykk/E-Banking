using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InvtMasterPage : System.Web.UI.MasterPage
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserId"]) == "" || Session["UserId"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Session["UserId"].ToString() == "EBANK007")
            {
                OnlyAdminVisible.Visible = true;
            }
            else
            {
                OnlyAdminVisible.Visible = false;
            }

            lbl_login_name.Text = Session["UserName"].ToString();
            lbl_empid.Text = Session["UserId"].ToString();
            cls.retrieve_image(img_login1, Session["UserId"].ToString());
        }
    }

}
