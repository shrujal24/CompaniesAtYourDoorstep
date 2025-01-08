using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe
{
    public class CV
    {
        public CV()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region Default Values
        public static string DefaultCompanyName = "Demo Developers";
        public static string DefaultCompanyLogoPath = "~/Default/Images/divyashree.png";
        public static string DefaultCompanyLogoPathForReport = "~/Default/Images/DivyasreeLogo.jpg";

        public static string DefaultCulture = "en-US";

        public static string AppendForMenu = "/www-dfr";


        public static Decimal DefaultTCSPCT = 1;

        public static Int32 AutoComplete_MinimumPrefixLength = 3;

        #endregion Default Values

        #region System Configuration

        public static Boolean IsShowHelp = false;
        public static DateTime MonthStartingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public static DateTime CurrentDate = DateTime.Now;

        #endregion System Configuration

        #region Control Configuration
        public static System.Web.UI.WebControls.ValidatorDisplay ValidationDisplay = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
        public static string DropDownZeroIndexValue = "-99";

        #endregion Control Configuration

        #region Page Header in AddEdit cs Code
        public static string PageHeaderAdd = "Add";
        public static string PageHeaderEdit = "Edit";
        #endregion Page Header in AddEdit cs Code

        #region Pagination

        public static int PageRecordSize = 50;
        public static int PageDisplaySize = 10; //Pages Displayed in Pagination
        public static int DisplayIndex = 5;
        public static int SmallestPageSize = 20;

        #endregion Pagination

        #region General

        public static string MaxAllowedFileSizeInkb = "5000 kb";
        public static string MaxAllowedFileSizeInmb = "5 Mb";
        public static Int32 MaxAllowedFileSize = 5242880;
        public static string FileTypeUnit = "bit";
        public static string[] validFileTypes = { "pdf", "doc", "docx", "xls", "xlsx", "xlsm", "jpg", "jpeg", "png", "gif" };
        public static string[] validFileTypesWithOutImageFileType = { "pdf", "doc", "docx", "xls", "xlsx", "xlsm" };
        public static string[] validImageFileTypes = { "jpg", "jpeg", "png", "gif" };
        public static string[] validOnlyExcelFileTypes = { "xls", "xlsx", "xlsm" };
        public static string[] ValidQuestionPaperFormat = { "pdf", "doc" };

        public static Int32 MaxPhotoHeightInPX = 500;
        public static Int32 MaxPhotoWidthInPX = 500;
        public static Int32 MaxPhotoSizeInKB = 100;

        #endregion General

        #region Default Display Formats

        public static string DefaultDateFormat = "dd-MM-yyyy";
        public static string DefaultTimeFormat = "hh:mm tt";
        public static string DefaultDateFormatForGrid = "{0:dd-MM-yyyy}";
        public static string DataFormatWithSortMonthandYear = "{0:MMM - yyyy}";
        public static string DefaultDayFromDateFormatForGrid = "{0:dddd}";
        public static string DefaultDateFormatForGridWithDayName = "{0:dd-MM-yyyy dddd}";
        public static string DefaultTimeFormatForGrid = "{0:hh:mm tt}";
        public static string DefaultDateTimeFormatForGrid = "{0:dd-MM-yyyy hh:mm:ss tt}";
        public static string DefaultDateTimeFormatForGridWithoutSecond = "{0:dd-MM-yyyy hh:mm tt}";
        public static string DefaultDayMonthNameForGrid = "{0:dd-MMM}";
        public static string DefaultHTMLDateFormat = "dd-mm-yyyy";
        public static string DefaultHTMLDateFormatWithDayName = "dd-mm-yyyy DD";
        public static string DefaultDateTimeFormat = "dd-MM-yyyy hh:mm:ss tt";

        public static string DefaultCurrencyFormat = "{0:#,0}";
        public static string DefaultCurrencyFormatWithRupeeSymbol = "₹ " + "{0:#,0}";
        public static string DefaultCurrencyFormatWithOutDecimalPoint = "{0:#,0}";
        public static string DefaultCurrencyFormatWithDecimalPoint = "{0:#,0.00}";
        public static string DefaultDecimalFormat = "{0:0.00}";
        public static string DefaultDecimalFormat2DecimalPoints = "F";
        public static string DefaultDecimalFormatWithOutDecimalPoint = "{0:0.##}";
        public static string DefaultDecimalFormatWith3DecimalPoint = "{0:0.###}";
        public static string DefaultNumberFormat = "{0:00}";

        public static string DefaultCurrencyFormatForGrid = "##,##,##,##,##0";
        public static string DefaultCurrencyFormatForGridWithRupeeSymbol = "₹ " + "##,##,##,##,##0";
        public static string DefaultAmountFormatForRDLC = "##,##,##,##,##0";
        public static string DefaultAmountFormatWithDecimalForRDLC = "##,##,##,##,##0.00";

        public static string DefaultCurrencyFormatForGridWithDecimalAndRupeeSymbol = "₹ " + "##,##,##,##,##0.00";
        public static string DefaultCurrencyFormatForGridWithDecimal = "##,##,##,##,##0.00";

        public static string DefaultWeightFormat = "##,##,##,##,##0.000";

        public static string SqlDateFormat = "yyyy-MM-dd";

        #endregion Default Display Formats

        #region List Page
        public static string SearchHeaderText = "SEARCH";
        public static string SearchResultHeaderText = "SEARCH RESULT";
        public static int UpdateProgressDisplayAfter = 10;
        public static char ListPageSearchParamSeperator = '$';

        #endregion List Page

        #region Default URL

        public static string DefaultHomeURL = "~/AddressBook/Home";
        public static string DefaultLoginPageURL = "~/AddressBook/Login";
        public static string LoginPageURL = "~/AddressBook/Login";

        public static string ChangePasswordPageURL = "~/AdminPanel/Security/SEC_User/SEC_User_ChangePassword.aspx";
        public static string PasswordChanged = "Password Changed Successfully";
        public static string PasswordWrong = "Old Password is Wrong!";

        public static string UploadPath = "~/U111";
        public static string DefaultIconImageUrl = "";
        public static string ErrorAccessDeniedPageURL = "~/Default/Error401.aspx";

        #endregion Default URL

        #region Default Images
        public static string CommonImagePath = "~/Default/Images/Default-User.png";
        public static string NoImagePath = "~/Default/Images/noimage.png";
        #endregion Default Images

        #region Report Variable

        public class ReportConfig
        {
            public static string HeaderLine1 = "Demo Company";
            public static string LogoPath = "";
            public static string HeaderLine1FontName = "Times New Roman";
            public static string HeaderLine1FontSize = "12pt";
            public static string HeaderLine1FontWeight = "Bold";
            public static string HeaderLine1Color = "Black";
            public static string HeaderLine2FontName = "Times New Roman";
            public static string HeaderLine2FontSize = "8pt";
            public static string HeaderLine2FontWeight = "Default";
            public static string HeaderLine2Color = "Black";
            public static string ReportTitleFontName = "Times New Roman";
            public static string ReportTitleFontSize = "10pt";
            public static string ReportTitleFontWeight = "Bold";
            public static string ReportTitleColor = "Black";
            public static string BodyFontName = "Viner Hand ITC";
            public static string BodyFontSize = "9pt";
            public static string BodyFontWeight = "Default";
            public static string BodyFontColor = "Black";
            public static string TableHeaderFontName = "Viner Hand ITC";
            public static string TableHeaderFontSize = "9pt";
            public static string TableHeaderFontWeight = "Bold";
            public static string TableHeaderFontColor = "Black";
            public static string TableBodyFontName = "Verdana";
            public static string TableBodyFontSize = "9pt";
            public static string TableBodyFontWeight = "Default";
            public static string TableBodyFontColor = "Black";
            public static string TableFooterFontName = "Arial";
            public static string TableFooterFontSize = "9pt";
            public static string TableFooterFontWeight = "Bold";
            public static string TableFooterFontColor = "Black";
            public static string FooterFontName = "Viner Hand ITC";
            public static string FooterFontSize = "9pt";
            public static string FooterFontWeight = "Default";
            public static string FooterFontColor = "Black";
        }

        public static string ReportFileTypeExcel = "EXCEL";
        public static string ReportFileTypePDF = "PDF";

        public static Boolean IsDirectPrint = false;

        #endregion Report Variable

        #region Security Configuration
        public static Boolean IsLoginRestricted = false;
        public static String LoginRestrictedMessage = "System is under maintenance.Please login after sometime.";
        #endregion Security Configuration

        public static string ResourceTypeEquipment = "Equipment";
        public static string ResourceTypePersonal = "Personal";

        public static string DefaultRDLCLanguage = "en-IN";
    }
}