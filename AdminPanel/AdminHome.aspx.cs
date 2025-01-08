using CompaniesatyourDoorstpe;
using CompaniesatyourDoorstpe.BAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_AdminHome : System.Web.UI.Page
{
    #region 10.0 Local Variables

    #endregion 10.0 Local Variables

    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login
        //if (Session["UserID"] == null)
        //    Response.Redirect(CV.LoginPageURL);
        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {
            #region 11.2 Fill Labels

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls
            this.Page.Title = "Home - Admin";

            if (Session["UserID"] != null)
            {
                lblUserSession.Text = "Welcome, " + Session["UserName"].ToString();
                FillControls(Convert.ToInt32(Session["UserID"]));
            }
            #endregion 11.5 Fill Controls

            #region 11.6 Set Help Text

            #endregion 11.6 Set Help Text
        }
    }
    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK

    private void FillControls(Int32 UserID)
    {
        MasterUserBAL balMasterUser = new MasterUserBAL();
        MasterUserENT entMasterUser = new MasterUserENT();
        entMasterUser = balMasterUser.SelectPK(UserID);

        if (!entMasterUser.Username.IsNull)
            txtUserName.Text = entMasterUser.Username.Value.ToString();

        //if (!entMasterUser.Password.IsNull)
        //    txtPassword.Text = entMasterUser.Password.Value.ToString();

        if (!entMasterUser.Birthdate.IsNull)
            txtBirthdate.Text = entMasterUser.Birthdate.Value.ToString("yyyy/MM/dd");

       
        if (!entMasterUser.MobileNo.IsNull)
            txtMobileNo.Text = entMasterUser.MobileNo.Value.ToString();

        if (!entMasterUser.EmailAddress.IsNull)
            txtEmailAddress.Text = entMasterUser.EmailAddress.Value.ToString();

    }
    #endregion 14.0 FillControls By PK

    #region 15.0 Edit Button Event
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        #region Enable for Edit
        if (Session["UserID"] != null)
        {
            lblUserSession.Text = "Welcome, " + Session["UserName"].ToString();
            lblMsg.Text = "Edit Profile";
            btnEdit.Visible = false;
            //btnChangePassword.Visible = true;
            txtUserName.Enabled = true;
            txtBirthdate.Enabled = true;
            txtMobileNo.Enabled = true;
            txtEmailAddress.Enabled = true;

            btnSave.Visible = true;
            hlCancel.Visible = true;
            hlChangePassword.Visible = true;
        }
        #endregion Enable for Edit
    }
    #endregion 15.0 Edit Button Event

    #region 16.0 Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                MasterUserBAL balMasterUser = new MasterUserBAL();
                MasterUserENT entMasterUser = new MasterUserENT();

                #region 16.1 Validate Fields

                String ErrorMsg = String.Empty;

                if (txtUserName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Username");

                if (ErrorMsg != String.Empty)
                {
                    lblMessage.Text = ErrorMsg;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
                #endregion 16.1 Validate Fields

                
                #region 16.3 Gather Data

                if (txtUserName.Text.Trim() != String.Empty)
                    entMasterUser.Username = txtUserName.Text.Trim();
                if (txtBirthdate.Text.Trim() != String.Empty)
                    entMasterUser.Birthdate = DateTime.Parse(txtBirthdate.Text.Trim());
                if (txtMobileNo.Text.Trim() != String.Empty)
                    entMasterUser.MobileNo = txtMobileNo.Text.Trim();
                if (txtEmailAddress.Text.Trim() != String.Empty)
                    entMasterUser.EmailAddress = txtEmailAddress.Text.Trim();

                #endregion 16.3 Gather Data

                #region 16.4 Update
                if (Session["UserID"] != null)
                {
                    entMasterUser.UserID = Convert.ToInt32(Session["UserID"]);

                    if (balMasterUser.Update(entMasterUser))
                    {
                        lblMessage.Text = "Data Updated Successfully....";
                        lblMessage.ForeColor = Color.Green;
                        Response.Redirect("~/Admin/Home");
                    }
                    else
                    {
                        lblMessage.Text = balMasterUser.Message;
                        lblMessage.ForeColor = Color.Red;
                    }
                }
                #endregion 16.4 Update

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
    #endregion 16.0 Save Button Event
}