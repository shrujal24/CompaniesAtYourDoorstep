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

public partial class AdminPanel_Area_AreaAddEdit : System.Web.UI.Page
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

            txtAreaName.Focus();

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls

            if (Page.RouteData.Values["AreaID"] != null)
            {
                FillControls(Convert.ToInt32(Page.RouteData.Values["AreaID"]));
                lblPageHeader.Text = "Area Edit";
                this.Page.Title = "Area Edit - Admin";
            }
            else
            {
                this.Page.Title = "Area Add - Admin";
                lblPageHeader.Text = "Area Add";
            }
            FillControls(Convert.ToInt32(Page.RouteData.Values["AreaID"]));

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

        CommonFillMethods.FillDropDownListCategory(ddlCategory);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK

    private void FillControls(Int32 AreaID)
    {
        if (Page.RouteData.Values["AreaID"] != null)
        {
            AreaBAL balArea = new AreaBAL();
            AreaENT entArea = new AreaENT();
            entArea = balArea.SelectPK(AreaID);

            if (!entArea.AreaName.IsNull)
                txtAreaName.Text = entArea.AreaName.Value.ToString();

            if (!entArea.CategoryID.IsNull)
                ddlCategory.SelectedValue = entArea.CategoryID.Value.ToString();
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
                AreaBAL balArea = new AreaBAL();
                AreaENT entArea = new AreaENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;
                if (txtAreaName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Area Name");

                if (ddlCategory.SelectedIndex < 0 || ddlCategory.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Category Name");

                if (ErrorMsg != String.Empty)
                {
                    lblMessage.Text = ErrorMsg;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data


                if (txtAreaName.Text.Trim() != String.Empty)
                    entArea.AreaName = txtAreaName.Text.Trim();

                if (ddlCategory.SelectedIndex > 0)
                    entArea.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

                if (Page.RouteData.Values["AreaID"] != null)
                    entArea.AreaID = Convert.ToInt32(Page.RouteData.Values["AreaID"]);


                #endregion 15.2 Gather Data

                #region 15.3 Insert,Update,Copy
                if (Page.RouteData.Values["AreaID"] != null)
                {
                    entArea.AreaID = Convert.ToInt32(Page.RouteData.Values["AreaID"]);
                    if (balArea.Update(entArea))
                    {
                        Response.Redirect("~/Admin/Area");
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated .........";
                        lblMessage.CssClass = CSSClass.alertdanger;
                    }
                }
                else
                {
                    if (Page.RouteData.Values["AreaID"] == null)
                    {
                        if (balArea.Insert(entArea))
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
        txtAreaName.Text = String.Empty;
        ddlCategory.SelectedIndex = 0;
        txtAreaName.Focus();
    }

    #endregion 16.0 Clear Controls
}