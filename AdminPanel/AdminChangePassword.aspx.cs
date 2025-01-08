using CompaniesatyourDoorstpe;
using CompaniesatyourDoorstpe.BAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_AdminChangePassword : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            #region 11.2 Fill Labels

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls
            if (Session["UserID"] != null)
            {
                lblUserSession.Text = "Welcome, " + Session["UserName"].ToString();
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

    #endregion 14.0 FillControls By PK

    #region 15.0 Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                MasterUserBAL balMasterUser = new MasterUserBAL();
                MasterUserENT entMasterUser = new MasterUserENT();

                #region 15.1 Get Old Password By PK

                SqlString strPassword = SqlString.Null;

                entMasterUser = balMasterUser.SelectPK(Convert.ToInt32(Session["UserID"]));

                if (!entMasterUser.Password.IsNull)
                    strPassword = entMasterUser.Password.Value.ToString();

                #endregion 15.1 Get Old Password By PK

                #region 15.2 Local Variables
                SqlString strNewPassword = SqlString.Null;
                SqlString strRetypeNewPassword = SqlString.Null;
                #endregion 15.2 Local Variables

                #region 15.3 Read Data

                if (txtNewPassword.Text.Trim() != String.Empty)
                    strNewPassword = txtNewPassword.Text.Trim();
                if (txtRetypeNewPassword.Text.Trim() != String.Empty)
                    strRetypeNewPassword = txtRetypeNewPassword.Text.Trim();

                #endregion 15.3 Read Data

                #region 15.4 Validate Fields

                String strErrorMassege = String.Empty;

                if (txtPassword.Text.Trim() != String.Empty)
                {
                    if (strPassword != txtPassword.Text.Trim())
                    {
                        strErrorMassege += " Invalid Entered Password. <br/> Kindly Enter Your Valid Olds Password.<br> ";
                    }
                }

                if (txtNewPassword.Text.Trim() != String.Empty)
                {
                    if (txtPassword.Text.Trim() == strNewPassword)
                    {
                        strErrorMassege += " Same Password. <br/> Kindly Enter Other Password. <br>";
                    }
                }

                if (txtRetypeNewPassword.Text.Trim() != String.Empty)
                {
                    if (strNewPassword != strRetypeNewPassword)
                    {
                        strErrorMassege += " The Re-type New Password not match the New Password.<br/> Kindly Enter match Password. ";
                    }
                }
                if (strErrorMassege != String.Empty)
                {
                    lblMessage.Text = strErrorMassege.ToString();
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
                #endregion Validate Fields

                #region 15.5 Gather Data

                #endregion 15.5 Gather Data

                #region 15.6 Update Password By UserID
                if (Session["UserID"] != null)
                {
                    if (balMasterUser.UpdatePasswordByUserID(Convert.ToInt32(Session["UserID"]), txtNewPassword.Text.Trim()))
                    {
                        lblMessage.Text = "Password Updated Successfully....";
                        lblMessage.ForeColor = Color.Green;
                        Response.Redirect("~/Admin/Home");
                    }
                    else
                    {
                        lblMessage.Text = balMasterUser.Message;
                        lblMessage.ForeColor = Color.Red;
                    }
                }
                #endregion 15.6 Update Password By UserID
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
    #endregion Button : Save
}