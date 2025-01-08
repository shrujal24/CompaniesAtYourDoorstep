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

public partial class AdminPanel_Question_QuestionAddEdit : System.Web.UI.Page
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

            txtQuestion.Focus();

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls

            if (Page.RouteData.Values["QueID"] != null)
            {
                FillControls(Convert.ToInt32(Page.RouteData.Values["QueID"]));
                lblPageHeader.Text = "Question Edit";
                this.Page.Title = "Question Edit - Admin";

            }
            else
            {
                this.Page.Title = "Question Add - Admin";
                lblPageHeader.Text = "Question Add";
            }
            FillControls(Convert.ToInt32(Page.RouteData.Values["QueID"]));

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

    private void FillControls(Int32 QueID)
    {
        if (Page.RouteData.Values["QueID"] != null)
        {
            QuestionBAL balQuestion = new QuestionBAL();
            QuestionENT entQuestion = new QuestionENT();
            entQuestion = balQuestion.SelectPK(QueID);

            if (!entQuestion.Question.IsNull)
                txtQuestion.Text = entQuestion.Question.Value.ToString();

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
                QuestionBAL balQuestion = new QuestionBAL();
                QuestionENT entQuestion = new QuestionENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;
                if (txtQuestion.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Question Name");

                if (ErrorMsg != String.Empty)
                {
                    lblMessage.Text = ErrorMsg;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data


                if (txtQuestion.Text.Trim() != String.Empty)
                    entQuestion.Question = txtQuestion.Text.Trim();


                if (Page.RouteData.Values["QueID"] != null)
                    entQuestion.QueID = Convert.ToInt32(Page.RouteData.Values["QueID"]);


                #endregion 15.2 Gather Data

                #region 15.3 Insert,Update,Copy
                if (Page.RouteData.Values["QueID"] != null)
                {
                    entQuestion.QueID = Convert.ToInt32(Page.RouteData.Values["QueID"]);
                    if (balQuestion.Update(entQuestion))
                    {
                        Response.Redirect("~/Admin/Question");
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated .........";
                        lblMessage.CssClass = CSSClass.alertdanger;
                    }
                }
                else
                {
                    if (Page.RouteData.Values["QueID"] == null)
                    {
                        if (balQuestion.Insert(entQuestion))
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
        txtQuestion.Text = String.Empty;
        txtQuestion.Focus();
    }

    #endregion 16.0 Clear Controls
}