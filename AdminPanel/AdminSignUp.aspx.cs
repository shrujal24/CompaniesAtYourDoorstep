using CompaniesatyourDoorstpe;
using CompaniesatyourDoorstpe.BAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_AdminSignUp : System.Web.UI.Page
{
    #region 10.0 Local Variables
    #endregion 10.0 Variables

    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.2 Fill Labels
        #endregion 11.2 Fill Labels

        #region 11.3 DropDown List Fill Section
        #endregion 11.3 DropDown List Fill Section

        #region 11.4 Set Control Default Value

        txtUsername.Focus();
        this.Page.Title = "SignUp - Admin";

        #endregion 11.4 Set Control Default Value

        #region 11.5 Fill Controls
        #endregion 11.5 Fill Controls

        #region 11.6 Set Help Text
        #endregion 11.6 Set Help Text

    }
    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels
    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList
    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK
    #endregion 14.0 FillControls By PK

    #region 15.0 Save Button Event
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                MasterUserBAL balMasterUser = new MasterUserBAL();
                MasterUserENT entMasterUser = new MasterUserENT();

                LoginBAL balLogin = new LoginBAL();
                LoginENT entLogin = new LoginENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;

                if (txtUsername.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Username");

                if (txtPassword.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Password");

                if (txtMobileNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Mobile Number");
                
                if (txtBirthDate.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Birthdate");

                if (txtEmailAddress.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Email Address");


                if (ErrorMsg != String.Empty)
                {
                    lblMessage.Text = ErrorMsg;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
                #endregion 15.1 Validate Fields

                #region 15.2 to Check Availability of Username
                if (balMasterUser.CheckByUsername(txtUsername.Text.Trim()) != null && balMasterUser.CheckByUsername(txtUsername.Text.Trim()).Rows.Count > 0)
                {
                    lblMessage.Text = "User Name " + txtUsername.Text.Trim() + " Is Already Exsist";
                    lblMessage.ForeColor = Color.Red;
                    ClearControls();
                }
                #endregion 15.2 to Check Availability of Username

                else
                {
                    #region 15.3 Gather Data

                    if (txtUsername.Text.Trim() != String.Empty)
                        entMasterUser.Username = txtUsername.Text.Trim();
                   
                    if (txtPassword.Text.Trim() != String.Empty)
                        entMasterUser.Password = txtPassword.Text.Trim();
                    
                    if (txtMobileNo.Text.Trim() != String.Empty)
                        entMasterUser.MobileNo = txtMobileNo.Text.Trim();
                    
                    if (txtBirthDate.Text.Trim() != String.Empty)
                        entMasterUser.Birthdate = DateTime.Parse(txtBirthDate.Text.Trim());
                   
                    if (txtEmailAddress.Text.Trim() != String.Empty)
                        entMasterUser.EmailAddress = txtEmailAddress.Text.Trim();

                    if (txtUsername.Text.Trim() != String.Empty)
                        entLogin.Username = txtUsername.Text.Trim();

                    if (txtPassword.Text.Trim() != String.Empty)
                        entLogin.Password = txtPassword.Text.Trim();

                    entLogin.Role = "Admin";


                    #endregion 15.3 Gather Data

                    #region 15.4 Insert and Login

                    if (balMasterUser.Insert(entMasterUser))
                    {
                        if (balLogin.Insert(entLogin))
                        {
                            lblMessage.Text = "Data Inserted Successfully........";
                            lblMessage.ForeColor = Color.Green;
                            LoginUser();
                            ClearControls();
                        }
                    }
                    else
                    {
                        lblMessage.Text = balMasterUser.Message;
                        lblMessage.ForeColor = Color.Red;
                    }
                    #endregion 15.4 Insert and Login

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
    #endregion 15.0 Save Button Event

    #region 16.0 Clear Controls

    private void ClearControls()
    {
        txtUsername.Text = String.Empty;
        txtPassword.Text = String.Empty;
        txtMobileNo.Text = String.Empty;
        txtBirthDate.Text = String.Empty;
        txtEmailAddress.Text = String.Empty;
        txtUsername.Focus();
    }

    #endregion 16.0 Clear Controls

    #region 17.0 login User
    private void LoginUser()
    {

        #region Store Data in Session


        MasterUserBAL balMasterUserBAL = new MasterUserBAL();
        DataTable dtMasterUserBAL = balMasterUserBAL.SelectByUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.ToString());
        if (dtMasterUserBAL != null && dtMasterUserBAL.Rows.Count > 0)
        {
            foreach (DataRow drow in dtMasterUserBAL.Rows)
            {
                if (!drow["UserID"].Equals(System.DBNull.Value))
                    Session["UserID"] = drow["UserID"].ToString();

                if (!drow["Username"].Equals(System.DBNull.Value))
                    Session["Username"] = drow["Username"].ToString();

                break;
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
    #endregion 17.0 Login User
}