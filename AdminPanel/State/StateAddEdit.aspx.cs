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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region 10.0 Local Variables

    #endregion 10.0 Variables

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

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            txtStateName.Focus();

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls

            if (Page.RouteData.Values["StateID"] != null)
            {
                FillControls(Convert.ToInt32(Page.RouteData.Values["StateID"]));
                lblPageHeader.Text = "State Edit";
                this.Page.Title = "State Edit - Admin";
            }
            else
            {
                this.Page.Title = "State Add - Admin";
                lblPageHeader.Text = "State Add";
            }
            FillControls(Convert.ToInt32(Page.RouteData.Values["StateID"]));

            #endregion 11.5 Fill Controls

            #region 11.6 Set Help Text

            #endregion 11.6 Set Help Text

        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList

    private void FillDropDownList()
    {

        CommonFillMethods.FillDropDownListCountry(ddlCountry);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK

    private void FillControls(Int32 StateID)
    {
        if (Page.RouteData.Values["StateID"] != null)
        {
            StateBAL balState = new StateBAL();
            StateENT entState = new StateENT();
            entState = balState.SelectPK(StateID);

            if (!entState.StateName.IsNull)
                txtStateName.Text = entState.StateName.Value.ToString();

            if (!entState.CountryID.IsNull)
                ddlCountry.SelectedValue = entState.CountryID.Value.ToString();
        }
    }

    #endregion 14.0 FillControls By PK

    #region 15.0 Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                StateBAL balState = new StateBAL();
                StateENT entState = new StateENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;
                if (txtStateName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("State Name");

                if (ddlCountry.SelectedIndex < 0 || ddlCountry.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Country Name");

                if (ErrorMsg != String.Empty)
                {
                    lblMessage.Text = ErrorMsg;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data


                if (txtStateName.Text.Trim() != String.Empty)
                    entState.StateName = txtStateName.Text.Trim();

                if (ddlCountry.SelectedIndex > 0)
                    entState.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

                if (Page.RouteData.Values["StateID"] != null)
                    entState.StateID = Convert.ToInt32(Page.RouteData.Values["StateID"]);


                #endregion 15.2 Gather Data

                #region 15.3 Insert,Update,Copy
                if (Page.RouteData.Values["StateID"] != null)
                {
                    entState.StateID = Convert.ToInt32(Page.RouteData.Values["StateID"]);
                    if (balState.Update(entState))
                    {
                        Response.Redirect("~/Admin/State");
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated .........";
                        lblMessage.CssClass = CSSClass.alertdanger;
                    }
                }
                else
                {
                    if (Page.RouteData.Values["StateID"] == null)
                    {
                        if (balState.Insert(entState))
                        {
                            lblMessage.Text = "Data Inserted Successfully........";
                            lblMessage.CssClass = CSSClass.alertsuccess;
                            ClearControls();
                        }
                    }
                }
                #endregion 15.3 Insert,Update,Copy

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
        txtStateName.Text = String.Empty;
        ddlCountry.SelectedIndex = 0;
        txtStateName.Focus();
    }

    #endregion 16.0 Clear Controls
}