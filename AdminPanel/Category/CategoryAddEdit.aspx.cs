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

public partial class AdminPanel_Category_CategoryAddEdit : System.Web.UI.Page
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

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            txtCategoryName.Focus();

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls

            if (Page.RouteData.Values["CategoryID"] != null)
            {
                FillControls(Convert.ToInt32(Page.RouteData.Values["CategoryID"]));
                lblPageHeader.Text = "Category Edit";
                this.Page.Title = "Category Edit - Admin";

            }
            else
            {
                this.Page.Title = "Category Add - Admin";
                lblPageHeader.Text = "Category Add";
            }
            FillControls(Convert.ToInt32(Page.RouteData.Values["CategoryID"]));

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

    private void FillControls(Int32 CategoryID)
    {
        if (Page.RouteData.Values["CategoryID"] != null)
        {
            CategoryBAL balCategory = new CategoryBAL();
            CategoryENT entCategory = new CategoryENT();
            entCategory = balCategory.SelectPK(CategoryID);

            if (!entCategory.CategoryName.IsNull)
                txtCategoryName.Text = entCategory.CategoryName.Value.ToString();

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
                CategoryBAL balCategory = new CategoryBAL();
                CategoryENT entCategory = new CategoryENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;
                if (txtCategoryName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Category Name");

                if (ErrorMsg != String.Empty)
                {
                    lblMessage.Text = ErrorMsg;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data


                if (txtCategoryName.Text.Trim() != String.Empty)
                    entCategory.CategoryName = txtCategoryName.Text.Trim();


                if (Page.RouteData.Values["CategoryID"] != null)
                    entCategory.CategoryID = Convert.ToInt32(Page.RouteData.Values["CategoryID"]);


                #endregion 15.2 Gather Data

                #region 15.3 Insert,Update,Copy
                if (Page.RouteData.Values["CategoryID"] != null)
                {
                    entCategory.CategoryID = Convert.ToInt32(Page.RouteData.Values["CategoryID"]);
                    if (balCategory.Update(entCategory))
                    {
                        Response.Redirect("~/Admin/Category");
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated .........";
                        lblMessage.CssClass = CSSClass.alertdanger;
                    }
                }
                else
                {
                    if (Page.RouteData.Values["CategoryID"] == null)
                    {
                        if (balCategory.Insert(entCategory))
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
        txtCategoryName.Text = String.Empty;
        txtCategoryName.Focus();
    }

    #endregion 16.0 Clear Controls
}