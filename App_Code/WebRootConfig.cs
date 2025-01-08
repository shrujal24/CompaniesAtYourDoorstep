using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebRootConfig
/// </summary>
public class WebRootConfig
{
	public static object Request { get; private set; }

    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{resource}.axd/{*pathinfo}");

        #region Admin side Routes

        #region Login SignUp Home Routes
        routes.MapPageRoute(
           "CAYD_Login",
           "Admin/Login",
           "~/AdminPanel/AdminLogin.aspx");

        routes.MapPageRoute(
            "CAYD_SignUp",
            "Admin/SignUp",
            "~/AdminPanel/AdminSignUp.aspx");

        routes.MapPageRoute(
            "CAYD_ChangePassword",
            "Admin/ChangePassword",
            "~/AdminPanel/AdminChangePassword.aspx");

        routes.MapPageRoute(
           "CAYD_AdminHome",
           "Admin/Home",
           "~/AdminPanel/AdminHome.aspx");
        #endregion Login SignUp Home Routes

        #region Country Routes
        routes.MapPageRoute(
           "CAYD_CountryList",
           "Admin/Country",
           "~/AdminPanel/Country/CountryList.aspx");

        routes.MapPageRoute(
          "CAYD_CountryAdd",
           "Admin/Country/Add",
           "~/AdminPanel/Country/CountryAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_CountryEdit",
           "Admin/Country/Edit/{CountryID}",
           "~/AdminPanel/Country/CountryAddEdit.aspx");

        #endregion Country Routes

        #region State Routes
        routes.MapPageRoute(
           "CAYD_StateList",
           "Admin/State",
           "~/AdminPanel/State/StateList.aspx");

        routes.MapPageRoute(
          "CAYD_StateAdd",
           "Admin/State/Add",
           "~/AdminPanel/State/StateAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_StateEdit",
           "Admin/State/Edit/{StateID}",
           "~/AdminPanel/State/StateAddEdit.aspx");

        #endregion State Routes

        #region City Routes
        routes.MapPageRoute(
           "CAYD_CityList",
           "Admin/City",
           "~/AdminPanel/City/CityList.aspx");

        routes.MapPageRoute(
          "CAYD_CityAdd",
           "Admin/City/Add",
           "~/AdminPanel/City/CityAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_CityEdit",
           "Admin/City/Edit/{CityID}",
           "~/AdminPanel/City/CityAddEdit.aspx");

        #endregion City Routes

        #region Area Routes
        routes.MapPageRoute(
           "CAYD_AreaList",
           "Admin/Area",
           "~/AdminPanel/Area/AreaList.aspx");

        routes.MapPageRoute(
          "CAYD_AreaAdd",
           "Admin/Area/Add",
           "~/AdminPanel/Area/AreaAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_AreaEdit",
           "Admin/Area/Edit/{AreaID}",
           "~/AdminPanel/Area/AreaAddEdit.aspx");

        #endregion Area Routes

        #region CandidateBasicDetails Routes
        routes.MapPageRoute(
           "CAYD_CandidateBasicDetailsList",
           "Admin/CandidateBasicDetails",
           "~/AdminPanel/CandidateBasicDetails/CandidateBasicDetailsList.aspx");

        routes.MapPageRoute(
          "CAYD_CandidateBasicDetailsAdd",
           "Admin/CandidateBasicDetails/Add",
           "~/AdminPanel/CandidateBasicDetails/CandidateBasicDetailsAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_CandidateBasicDetailsEdit",
           "Admin/CandidateBasicDetails/Edit/{CandidateID}",
           "~/AdminPanel/CandidateBasicDetails/CandidateBasicDetailsAddEdit.aspx");

        #endregion CandidateBasicDetails Routes

        #region CandidateEducationDetails Routes
        routes.MapPageRoute(
           "CAYD_CandidateEducationDetailsList",
           "Admin/CandidateEducationDetails",
           "~/AdminPanel/CandidateEducationDetails/CandidateEducationDetailsList.aspx");

        routes.MapPageRoute(
          "CAYD_CandidateEducationDetailsAdd",
           "Admin/CandidateEducationDetails/Add",
           "~/AdminPanel/CandidateEducationDetails/CandidateEducationDetailsAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_CandidateEducationDetailsEdit",
           "Admin/CandidateEducationDetails/Edit/{CandidateEduID}",
           "~/AdminPanel/CandidateEducationDetails/CandidateEducationDetailsAddEdit.aspx");

        #endregion CandidateEducationDetails Routes

        #region CandidateProfessionalDetails Routes
        routes.MapPageRoute(
           "CAYD_CandidateProfessionalDetailsList",
           "Admin/CandidateProfessionalDetails",
           "~/AdminPanel/CandidateProfessionalDetails/CandidateProfessionalDetailsList.aspx");

        routes.MapPageRoute(
          "CAYD_CandidateProfessionalDetailsAdd",
           "Admin/CandidateProfessionalDetails/Add",
           "~/AdminPanel/CandidateProfessionalDetails/CandidateProfessionalDetailsAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_CandidateProfessionalDetailsEdit",
           "Admin/CandidateProfessionalDetails/Edit/{CandidateProfID}",
           "~/AdminPanel/CandidateProfessionalDetails/CandidateProfessionalDetailsAddEdit.aspx");

        #endregion CandidateProfessionalDetails Routes

        #region Category Routes
        routes.MapPageRoute(
           "CAYD_CategoryList",
           "Admin/Category",
           "~/AdminPanel/Category/CategoryList.aspx");

        routes.MapPageRoute(
          "CAYD_CategoryAdd",
           "Admin/Category/Add",
           "~/AdminPanel/Category/CategoryAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_CategoryEdit",
           "Admin/Category/Edit/{CategoryID}",
           "~/AdminPanel/Category/CategoryAddEdit.aspx");

        #endregion Category Routes

        #region Company Routes
        routes.MapPageRoute(
           "CAYD_CompanyList",
           "Admin/Company",
           "~/AdminPanel/Company/CompanyList.aspx");

        routes.MapPageRoute(
          "CAYD_CompanyAdd",
           "Admin/Company/Add",
           "~/AdminPanel/Company/CompanyAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_CompanyEdit",
           "Admin/Company/Edit/{CompanyID}",
           "~/AdminPanel/Company/CompanyAddEdit.aspx");

        #endregion Company Routes

        #region CompanyPackage Routes
        routes.MapPageRoute(
           "CAYD_CompanyPackageList",
           "Admin/CompanyPackage",
           "~/AdminPanel/CompanyPackage/CompanyPackageList.aspx");

        routes.MapPageRoute(
          "CAYD_CompanyPackageAdd",
           "Admin/CompanyPackage/Add",
           "~/AdminPanel/CompanyPackage/CompanyPackageAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_CompanyPackageEdit",
           "Admin/CompanyPackage/Edit/{CompPackageID}",
           "~/AdminPanel/CompanyPackage/CompanyPackageAddEdit.aspx");

        #endregion CompanyPackage Routes

        #region JobApplied Routes
        routes.MapPageRoute(
           "CAYD_JobAppliedList",
           "Admin/JobApplied",
           "~/AdminPanel/JobApplied/JobAppliedList.aspx");

        routes.MapPageRoute(
          "CAYD_JobAppliedAdd",
           "Admin/JobApplied/Add",
           "~/AdminPanel/JobApplied/JobAppliedAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_JobAppliedEdit",
           "Admin/JobApplied/Edit/{AppliedID}",
           "~/AdminPanel/JobApplied/JobAppliedAddEdit.aspx");

        #endregion JobApplied Routes

        #region JobPost Routes
        routes.MapPageRoute(
           "CAYD_JobPostList",
           "Admin/JobPost",
           "~/AdminPanel/JobPost/JobPostList.aspx");

        routes.MapPageRoute(
          "CAYD_JobPostAdd",
           "Admin/JobPost/Add",
           "~/AdminPanel/JobPost/JobPostAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_JobPostEdit",
           "Admin/JobPost/Edit/{JobpostID}",
           "~/AdminPanel/JobPost/JobPostAddEdit.aspx");

        #endregion JobPost Routes

        #region Package Routes
        routes.MapPageRoute(
           "CAYD_PackageList",
           "Admin/Package",
           "~/AdminPanel/Package/PackageList.aspx");

        routes.MapPageRoute(
          "CAYD_PackageAdd",
           "Admin/Package/Add",
           "~/AdminPanel/Package/PackageAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_PackageEdit",
           "Admin/Package/Edit/{PackageID}",
           "~/AdminPanel/Package/PackageAddEdit.aspx");

        #endregion Package Routes

        #region Post Routes
        routes.MapPageRoute(
           "CAYD_PostList",
           "Admin/Post",
           "~/AdminPanel/Post/PostList.aspx");

        routes.MapPageRoute(
          "CAYD_PostAdd",
           "Admin/Post/Add",
           "~/AdminPanel/Post/PostAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_PostEdit",
           "Admin/Post/Edit/{PostID}",
           "~/AdminPanel/Post/PostAddEdit.aspx");

        #endregion Post Routes

        #region Question Routes
        routes.MapPageRoute(
           "CAYD_QuestionList",
           "Admin/Question",
           "~/AdminPanel/Question/QuestionList.aspx");

        routes.MapPageRoute(
          "CAYD_QuestionAdd",
           "Admin/Question/Add",
           "~/AdminPanel/Question/QuestionAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_QuestionEdit",
           "Admin/Question/Edit/{QueID}",
           "~/AdminPanel/Question/QuestionAddEdit.aspx");

        #endregion Question Routes

        #region Resume Routes
        routes.MapPageRoute(
           "CAYD_ResumeList",
           "Admin/Resume",
           "~/AdminPanel/Resume/ResumeList.aspx");

        routes.MapPageRoute(
          "CAYD_ResumeAdd",
           "Admin/Resume/Add",
           "~/AdminPanel/Resume/ResumeAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_ResumeEdit",
           "Admin/Resume/Edit/{ResumeID}",
           "~/AdminPanel/Resume/ResumeAddEdit.aspx");

        #endregion Resume Routes

        #region SavedCandidates Routes
        routes.MapPageRoute(
           "CAYD_SavedCandidatesList",
           "Admin/SavedCandidates",
           "~/AdminPanel/SavedCandidates/SavedCandidatesList.aspx");

        routes.MapPageRoute(
          "CAYD_SavedCandidatesAdd",
           "Admin/SavedCandidates/Add",
           "~/AdminPanel/SavedCandidates/SavedCandidatesAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_SavedCandidatesEdit",
           "Admin/SavedCandidates/Edit/{SavedID}",
           "~/AdminPanel/SavedCandidates/SavedCandidatesAddEdit.aspx");

        #endregion SavedCandidates Routes

        #region SavedJob Routes
        routes.MapPageRoute(
           "CAYD_SavedJobList",
           "Admin/SavedJob",
           "~/AdminPanel/SavedJob/SavedJobList.aspx");

        routes.MapPageRoute(
          "CAYD_SavedJobAdd",
           "Admin/SavedJob/Add",
           "~/AdminPanel/SavedJob/SavedJobAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_SavedJobEdit",
           "Admin/SavedJob/Edit/{SavedJobID}",
           "~/AdminPanel/SavedJob/SavedJobAddEdit.aspx");

        #endregion SavedJob Routes

        #region SelectedCandidates Routes
        routes.MapPageRoute(
           "CAYD_SelectedCandidatesList",
           "Admin/SelectedCandidates",
           "~/AdminPanel/SelectedCandidates/SelectedCandidatesList.aspx");

        routes.MapPageRoute(
          "CAYD_SelectedCandidatesAdd",
           "Admin/SelectedCandidates/Add",
           "~/AdminPanel/SelectedCandidates/SelectedCandidatesAddEdit.aspx");

        routes.MapPageRoute(
          "CAYD_SelectedCandidatesEdit",
           "Admin/SelectedCandidates/Edit/{SelectedID}",
           "~/AdminPanel/SelectedCandidates/SelectedCandidatesAddEdit.aspx");

        #endregion SelectedCandidates Routes

        #endregion Admin side Routes
    }
}