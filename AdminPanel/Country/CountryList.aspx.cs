using CompaniesatyourDoorstpe;
using CompaniesatyourDoorstpe.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region 11.0 Variables
    #endregion 11.0 Variables

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        //if (Session["UserID"] == null)
        //    Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {
            #region 12.1 DropDown List Fill Section

            Search();

            #endregion 12.1 DropDown List Fill Section

            #region 12.2 Set Default Value

            this.Page.Title = "Country - Admin";

            #endregion 12.2 Set Default Value

            #region 12.3 Set Help Text
            //ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }
    }

    #endregion 12.0 Page Load Event

    #region 13.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion 13.0 FillLabels

    #region 14.0 DropDownList

    #endregion 14.0 DropDownList

    #region 15.0 Search
    private void Search()
    {

        CountryBAL balCountry = new CountryBAL();
        DataTable dt = balCountry.SelectAll();
        if (dt.Rows.Count > 0)
        {
            rpData.DataSource = dt;
            rpData.DataBind();
        }
        else
        {
            lblMessage.Text = "No Record Found";
            lblMessage.CssClass = CSSClass.alertdanger;
            rpData.Visible = false;
        }
    }
    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            try
            {
                CountryBAL balCountry = new CountryBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    if (balCountry.Delete(Convert.ToInt32(e.CommandArgument)))
                    {
                        lblMessage.Text = "Record Deleted Successfully...";
                        lblMessage.CssClass = CSSClass.alertsuccess;
                        Search();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }

    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events
}