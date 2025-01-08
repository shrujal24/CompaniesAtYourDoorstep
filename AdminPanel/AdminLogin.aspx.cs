using CompaniesatyourDoorstpe.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_AdminLogin : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserName.Focus();
        if (!Page.IsPostBack)
        {
            Session.Clear();
            this.Page.Title = "Login - Admin";
        }
    }
    #endregion Page Load Event


    #region Login Button Click Event
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String ErrorMsg = String.Empty;

        #region Validate Controls
        if (txtUserName.Text.Trim() == String.Empty)
            ErrorMsg += "Username is required<br>";

        if (txtPassword.Text.Trim() == String.Empty)
            ErrorMsg += "Password is required";

        if (ErrorMsg != String.Empty)
        {
            lblMessage.Text = ErrorMsg;
            lblMessage.ForeColor = Color.Red;
            return;
        }
        #endregion Validate Controls

        #region Store Data in Session


        MasterUserBAL balMasterUserBAL = new MasterUserBAL();
        DataTable dtMasterUserBAL = balMasterUserBAL.SelectByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.ToString());
        if (dtMasterUserBAL != null && dtMasterUserBAL.Rows.Count > 0)
        {
            foreach (DataRow drow in dtMasterUserBAL.Rows)
            {
                if (!drow["UserID"].Equals(System.DBNull.Value))
                    Session["UserID"] = drow["UserID"].ToString();

                if (!drow["Username"].Equals(System.DBNull.Value))
                    Session["Username"] = drow["Username"].ToString();
            }
            Response.Redirect("~/Admin/Home");
        }
        else
        {
            lblMessage.Text = "Invalid Username or Password";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            txtPassword.Focus();
        }

        #endregion Store Data in Session
    }
    #endregion Login Button Click Event
}