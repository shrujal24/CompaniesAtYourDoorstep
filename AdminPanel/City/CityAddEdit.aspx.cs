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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
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

            txtCityName.Focus();

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls

            if (Page.RouteData.Values["CityID"] != null)
            {
                FillControls(Convert.ToInt32(Page.RouteData.Values["CityID"]));
                lblPageHeader.Text = "City Edit";
                this.Page.Title = "City Edit - Admin";
            }
            else
            {
                this.Page.Title = "City Add - Admin";
                lblPageHeader.Text = "City Add";
            }
            FillControls(Convert.ToInt32(Page.RouteData.Values["CityID"]));

            #endregion 11.5 Fill Controls

            #region 11.6 Set Help Text

            #endregion 11.6 Set Help Text

        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFillMethods.FillDropDownListStateByCountryID(ddlState, Convert.ToInt32(ddlCountry.SelectedValue));
    }

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountry);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK

    private void FillControls(Int32 CityID)
    {
        if (Page.RouteData.Values["CityID"] != null)
        {
            CityBAL balCity = new CityBAL();
            CityENT entCity = new CityENT();
            entCity = balCity.SelectPK(CityID);

            if (!entCity.CityName.IsNull)
                txtCityName.Text = entCity.CityName.Value.ToString();

            if (!entCity.CountryID.IsNull)
                ddlCountry.SelectedValue = entCity.CountryID.Value.ToString();

            if (!entCity.StateID.IsNull)
                ddlState.SelectedValue = entCity.StateID.Value.ToString();

            CommonFillMethods.FillDropDownListStateByCountryID(ddlState, Convert.ToInt32(ddlCountry.SelectedValue));

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
                CityBAL balCity = new CityBAL();
                CityENT entCity = new CityENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;
                if (txtCityName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("City Name");

                if (ddlCountry.SelectedIndex <= 0 || ddlCountry.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Country Name");

                if (ddlState.SelectedIndex <= 0 || ddlState.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("State Name");

                if (ErrorMsg != String.Empty)
                {
                    lblMessage.Text = ErrorMsg;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data


                if (txtCityName.Text.Trim() != String.Empty)
                    entCity.CityName = txtCityName.Text.Trim();

                if (ddlCountry.SelectedIndex > 0)
                    entCity.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

                if (ddlState.SelectedIndex > 0)
                    entCity.StateID = Convert.ToInt32(ddlState.SelectedValue);

                if (Page.RouteData.Values["CityID"] != null)
                    entCity.CityID = Convert.ToInt32(Page.RouteData.Values["CityID"]);


                #endregion 15.2 Gather Data

                #region 15.3 Insert,Update,Copy
                if (Page.RouteData.Values["CityID"] != null)
                {
                    entCity.CityID = Convert.ToInt32(Page.RouteData.Values["CityID"]);
                    if (balCity.Update(entCity))
                    {
                        Response.Redirect("~/Admin/City");
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated .........";
                        lblMessage.CssClass = CSSClass.alertdanger;
                    }
                }
                else
                {
                    if (Page.RouteData.Values["CityID"] == null)
                    {
                        if (balCity.Insert(entCity))
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
        txtCityName.Text = String.Empty;
        ddlCountry.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        txtCityName.Focus();
    }

    #endregion 16.0 Clear Controls
}