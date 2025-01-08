using CompaniesatyourDoorstpe;
using CompaniesatyourDoorstpe.BAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AdminPanel_CandidateBasicDetails_CandidateBasicDetailsAddEdit : System.Web.UI.Page
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

            txtUsername.Focus();

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls

            if (Page.RouteData.Values["CandidateID"] != null)
            {
                FillControls(Convert.ToInt32(Page.RouteData.Values["CandidateID"]));
                lblPageHeader.Text = "CandidateBasicDetails Edit";
                this.Page.Title = "Candidate Basic Details Edit - Admin";
            }
            else
            {
                this.Page.Title = "CandidateBasicDetails Add - Admin";
                lblPageHeader.Text = "Candidate Basic Details Add";
                txtPassword.TextMode = TextBoxMode.Password;
            }
            FillControls(Convert.ToInt32(Page.RouteData.Values["CandidateID"]));

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

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFillMethods.FillDropDownListCityByStateID(ddlCity, Convert.ToInt32(ddlState.SelectedValue));
    }

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountry);
        CommonFillMethods.FillDropDownListQuestion(ddlQuestion);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK

    private void FillControls(Int32 CandidateID)
    {
        if (Page.RouteData.Values["CandidateID"] != null)
        {
            CandidateBasicDetailsBAL balCandidateBasicDetails = new CandidateBasicDetailsBAL();
            CandidateBasicDetailsENT entCandidateBasicDetails = new CandidateBasicDetailsENT();
            entCandidateBasicDetails = balCandidateBasicDetails.SelectPK(CandidateID);

           

            if (!entCandidateBasicDetails.Username.IsNull)
                txtUsername.Text = entCandidateBasicDetails.Username.Value.ToString();
            
            if (!entCandidateBasicDetails.FirstName.IsNull)
                txtFirstName.Text = entCandidateBasicDetails.FirstName.Value.ToString();

            if (!entCandidateBasicDetails.MiddleName.IsNull)
                txtMiddleName.Text = entCandidateBasicDetails.MiddleName.Value.ToString();

            if (!entCandidateBasicDetails.LastName.IsNull)
                txtLastName.Text = entCandidateBasicDetails.LastName.Value.ToString();
            
            if (!entCandidateBasicDetails.ContactNo.IsNull)
                txtContactNo.Text = entCandidateBasicDetails.ContactNo.Value.ToString();
            
            if (!entCandidateBasicDetails.DOB.IsNull)
                txtDOB.Text = entCandidateBasicDetails.DOB.Value.ToString("yyyy/MM/dd");

            if (!entCandidateBasicDetails.EmailAddress.IsNull)
                txtEmailAddress.Text = entCandidateBasicDetails.EmailAddress.Value.ToString();

            if (!entCandidateBasicDetails.Gender.IsNull)
            {
                if (entCandidateBasicDetails.Gender.Value.ToString() == "Male")
                    ddlGender.SelectedValue = "1";
                else if (entCandidateBasicDetails.Gender.Value.ToString() == "Female")
                    ddlGender.SelectedValue = "2";
            }

            if (!entCandidateBasicDetails.CandidateAddress.IsNull)
                txtCandidateAddress.Text = entCandidateBasicDetails.CandidateAddress.Value.ToString();

            if (!entCandidateBasicDetails.QueID.IsNull)
                ddlQuestion.SelectedValue = entCandidateBasicDetails.QueID.Value.ToString();

            if (!entCandidateBasicDetails.Ans.IsNull)
                txtAnswer.Text = entCandidateBasicDetails.Ans.Value.ToString();

            if (!entCandidateBasicDetails.CountryID.IsNull)
                ddlCountry.SelectedValue = entCandidateBasicDetails.CountryID.Value.ToString();


            CommonFillMethods.FillDropDownListStateByCountryID(ddlState, Convert.ToInt32(ddlCountry.SelectedValue));
            ddlState.SelectedValue = entCandidateBasicDetails.StateID.Value.ToString();
            
            CommonFillMethods.FillDropDownListCityByStateID(ddlCity, Convert.ToInt32(ddlState.SelectedValue));
            ddlCity.SelectedValue = entCandidateBasicDetails.CityID.Value.ToString();

            if (!entCandidateBasicDetails.Password.IsNull)
                txtPassword.Text = entCandidateBasicDetails.Password.Value.ToString();

            if (!entCandidateBasicDetails.ImageUrl.IsNull)
            {
                imgUser.ImageUrl = entCandidateBasicDetails.ImageUrl.Value.ToString();
                imgUser.Visible = true;
            }
            //LoginBAL balLogin = new LoginBAL();
            //LoginENT entLogin = new LoginENT();
            //entLogin = balLogin.SelectPK(entCandidateBasicDetails.Username.Value.ToString());

            //if (!entLogin.Password.IsNull)
            //    txtPassword.Text = entLogin.Password.Value.ToString();
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
                CandidateBasicDetailsBAL balCandidateBasicDetails = new CandidateBasicDetailsBAL();
                CandidateBasicDetailsENT entCandidateBasicDetails = new CandidateBasicDetailsENT();

                LoginBAL balLogin = new LoginBAL();
                LoginENT entLogin = new LoginENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;
                if (txtUsername.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("User Name");

                if (txtPassword.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Password");

                if (txtFirstName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("First Name");

                if (txtMiddleName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Middle Name");

                if (txtLastName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Last Name");

                if (txtContactNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Contact Number");
               
                if (txtDOB.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Birthdate");
                
                if (txtEmailAddress.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Email Address");

                if (ddlGender.SelectedIndex < 0 || ddlGender.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Gender");

                if (txtCandidateAddress.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Address");

                if (ddlCountry.SelectedIndex < 0 || ddlCountry.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Country");

                if (ddlState.SelectedIndex < 0 || ddlState.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("State");

                if (ddlCity.SelectedIndex < 0 || ddlCity.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("City");
               
                if (ddlQuestion.SelectedIndex < 0 || ddlQuestion.SelectedValue == "-99")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Question");
               
                if (txtAnswer.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Answer");

                if (!fuImage.HasFile)
                    ErrorMsg += " - " + CommonMessage.ErrorInvalidFile("Image");

                if (ErrorMsg != String.Empty)
                {
                    lblMessage.Text = ErrorMsg;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data


                if (txtUsername.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.Username = txtUsername.Text.Trim();

                if (txtFirstName.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.FirstName = txtFirstName.Text.Trim();

                if (txtMiddleName.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.MiddleName = txtMiddleName.Text.Trim();

                if (txtLastName.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.LastName = txtLastName.Text.Trim();

                if (txtContactNo.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.ContactNo = txtContactNo.Text.Trim();
                
                if (txtDOB.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.DOB = DateTime.Parse(txtDOB.Text.Trim());
                
                if (txtEmailAddress.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.EmailAddress = txtEmailAddress.Text.Trim();
               
                if (ddlGender.SelectedIndex > 0)
                {
                    if (ddlGender.SelectedValue == "1")
                        entCandidateBasicDetails.Gender = "Male";
                    else if (ddlGender.SelectedValue == "2")
                        entCandidateBasicDetails.Gender = "Female";
                }

                if (txtCandidateAddress.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.CandidateAddress = txtCandidateAddress.Text.Trim();

                if (ddlCity.SelectedIndex > 0)
                    entCandidateBasicDetails.CityID = Convert.ToInt32(ddlCity.SelectedValue);


                if (ddlQuestion.SelectedIndex > 0)
                    entCandidateBasicDetails.QueID = Convert.ToInt32(ddlQuestion.SelectedValue);

                if (txtAnswer.Text.Trim() != String.Empty)
                    entCandidateBasicDetails.Ans = txtAnswer.Text.Trim();

                if (Page.RouteData.Values["CandidateID"] != null)
                    entCandidateBasicDetails.CandidateID = Convert.ToInt32(Page.RouteData.Values["CandidateID"]);

                entCandidateBasicDetails.ProfileDate = DateTime.Now;

                if (txtUsername.Text.Trim() != String.Empty)
                    entLogin.Username = txtUsername.Text.Trim();

                if (txtPassword.Text.Trim() != String.Empty)
                    entLogin.Password = txtPassword.Text.Trim();


                entLogin.Role = "Jobseeker";

                string strImagePath = "~/Content/image/CandidateProfile/";
                if (fuImage.HasFile)
                {
                    entCandidateBasicDetails.ImageUrl = strImagePath + fuImage.FileName;
                }
                else
                {
                    entCandidateBasicDetails.ImageUrl = (SqlString)imgUser.ImageUrl;
                }
                #endregion 15.2 Gather Data

                #region Upload Image
                if (fuImage.HasFile)
                {
                    string ImageExt = System.IO.Path.GetExtension(fuImage.FileName);

                    if (ImageExt.ToLower() == ".jpeg" || ImageExt == ".jpg" || ImageExt == ".png")
                    {
                    }
                    else
                    {
                        lblMessage.Text = "Only .jpeg files allowd!";
                        lblMessage.ForeColor = Color.Red;
                        return;
                    }
                    HttpPostedFile file = fuImage.PostedFile;
                    int iFileSize = file.ContentLength;
                    if (iFileSize > 1048576) // 1 MB
                    {
                        lblMessage.Text += "File Size Should be Less than 1 MB";
                        lblMessage.ForeColor = Color.Red;
                        return;
                    }

                    if (!Directory.Exists(Server.MapPath(strImagePath)))
                    {
                        Directory.CreateDirectory(Server.MapPath(strImagePath));
                    }
                    fuImage.SaveAs(Server.MapPath(strImagePath + fuImage.FileName));

                }
                else
                {
                    lblMessage.Text += "Kindly Select a Image to Upload";
                    lblMessage.ForeColor = Color.Red;
                    //return;
                }
                #endregion Upload Image


                #region 15.3 Insert,Update,Copy
                if (Page.RouteData.Values["CandidateID"] != null)
                {
                    entCandidateBasicDetails.CandidateID = Convert.ToInt32(Page.RouteData.Values["CandidateID"]);
                    if (balCandidateBasicDetails.Update(entCandidateBasicDetails))
                    {
                        if (balLogin.Update(entLogin))
                        {
                            Response.Redirect("~/Admin/CandidateBasicDetails");
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated .........";
                        lblMessage.CssClass = CSSClass.alertdanger;
                    }
                }
                else
                {
                    if (Page.RouteData.Values["CandidateID"] == null)
                    {
                        if (balCandidateBasicDetails.Insert(entCandidateBasicDetails))
                        {
                            if (balLogin.Insert(entLogin))
                            {
                                lblMessage.Text = "Data Inserted Successfully........";
                                lblMessage.CssClass = CSSClass.alertsuccess;
                                ClearControls();
                            }
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
        txtUsername.Text = String.Empty;
        ddlQuestion.SelectedIndex = 0;
        txtUsername.Focus();
    }

    #endregion 16.0 Clear Controls
}