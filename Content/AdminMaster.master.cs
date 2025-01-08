using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_AdminMaster : System.Web.UI.MasterPage
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Admin/Login");
            }
            else
            {
                lblUserName.Text = " Hi, " + Session["UserName"].ToString();
            }
        }
    }
    #endregion Load Event

    #region Button : Logout
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            Session.Clear();
            Response.Redirect("~/Admin/Login");
        }
    }
    #endregion Button : Logout
}
