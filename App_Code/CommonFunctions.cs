using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI;
using System.Drawing.Printing;

namespace CompaniesatyourDoorstpe
{
    public class CommonFunctions
    {
        #region Constructor
        public CommonFunctions()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Encryption/Decryption
        public static string Encrypt_Md5(string str_encode)
        {

            return str_encode;
        }

        public static string EncryptBase64(string password)
        {
            string strmsg = string.Empty;
            return strmsg;
        }

        public static string DecryptBase64(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            return decryptpwd;
        }

        public static SqlInt32 DecryptBase64Int32(SqlString encryptpwd)
        {

            return SqlInt32.Null;
        }

        public static bool IsBase64Encoded(String str)
        {
            try
            {
                // If no exception is caught, then it is possibly a base64 encoded string
                byte[] data = Convert.FromBase64String(str);
                // The part that checks if the string was properly padded to the
                // correct length was borrowed from d@anish's solution
                return (str.Replace(" ", "").Length % 4 == 0);
            }
            catch
            {
                // If exception is caught, then it is not a base64 encoded string
                return false;
            }
        }
        #endregion Encryption/Decryption

        #region Function For Paging In List Page

        public static void BindPageList(Int32 TotalPages, Int32 TotalRecords, Int32 CurrentPage, Int32 PageDisplaySize, Int32 DisplayIndex, Repeater rp, HtmlGenericControl liPrevious, LinkButton lbtnPrevious, HtmlGenericControl liFirstPage, LinkButton lbtnFirstPage, HtmlGenericControl liNext, LinkButton lbtnNext, HtmlGenericControl liLastPage, LinkButton lbtnLastPage)
        {
            if (TotalRecords == 0 && TotalPages == 0)
            {
                liPrevious.Attributes["class"] = "paginate_button previous disabled";
                lbtnPrevious.Enabled = false;
                liFirstPage.Attributes["class"] = "paginate_button previous disabled";
                lbtnFirstPage.Enabled = false;
                liNext.Attributes["class"] = "paginate_button next disabled";
                lbtnNext.Enabled = false;
                liLastPage.Attributes["class"] = "paginate_button next disabled";
                lbtnLastPage.Enabled = false;
                return;
            }

            if (CurrentPage == 1)
            {
                liPrevious.Attributes["class"] = "paginate_button previous disabled";
                lbtnPrevious.Enabled = false;
                liFirstPage.Attributes["class"] = "paginate_button previous disabled";
                lbtnFirstPage.Enabled = false;
            }
            else
            {
                liPrevious.Attributes["class"] = "paginate_button previous";
                lbtnPrevious.Enabled = true;
                liFirstPage.Attributes["class"] = "paginate_button previous";
                lbtnFirstPage.Enabled = true;

            }
            if (CurrentPage == TotalPages)
            {
                liNext.Attributes["class"] = "paginate_button next disabled";
                lbtnNext.Enabled = false;
                liLastPage.Attributes["class"] = "paginate_button next disabled";
                lbtnLastPage.Enabled = false;
            }
            else
            {
                liNext.Attributes["class"] = "paginate_button next";
                lbtnNext.Enabled = true;
                liLastPage.Attributes["class"] = "paginate_button next";
                lbtnLastPage.Enabled = true;
            }

            if (TotalPages <= PageDisplaySize)
            {
                BindPage(1, TotalPages, rp);
            }
            else if (TotalPages > PageDisplaySize)
            {
                if (CurrentPage <= DisplayIndex)
                {
                    BindPage(1, PageDisplaySize, rp);
                }
                else
                {
                    int Suffix = PageDisplaySize - DisplayIndex;

                    int Prefix = PageDisplaySize - Suffix - 1;

                    if ((CurrentPage + Suffix) >= TotalPages)
                    {
                        BindPage(CurrentPage - Prefix, TotalPages, rp);
                    }
                    else
                    {
                        BindPage(CurrentPage - Prefix, CurrentPage + Suffix, rp);
                    }
                }
            }
        }

        public static void BindPage(int FirstPage, int LastPage, Repeater rp)
        {
            DataTable dtPageNo = new DataTable();
            dtPageNo.Columns.Add("PageNo");
            for (int i = FirstPage; i <= LastPage; i++)
            {
                DataRow drPageNo = dtPageNo.NewRow();
                drPageNo["PageNo"] = i.ToString();
                dtPageNo.Rows.Add(drPageNo);
            }
            rp.DataSource = dtPageNo;
            rp.DataBind();
        }

        public static void GetDropDownPageSize(DropDownList ddl)
        {
            List<ListItem> pageSize = new List<ListItem>();
            pageSize.Add(new ListItem("All", "0"));
            //pageSize.Add(new ListItem("1", "1"));
            //pageSize.Add(new ListItem("10", "10"));
            pageSize.Add(new ListItem("20", "20"));
            pageSize.Add(new ListItem("50", "50"));
            pageSize.Add(new ListItem("100", "100"));
            pageSize.Add(new ListItem("500", "500"));

            foreach (ListItem li in pageSize)
            {
                ddl.Items.Add(li);
            }
        }

        #endregion Function For Paging In List Page

        #region Other
        public static System.Drawing.Image ByteArrayToImage(byte[] bArray)
        {
            if (bArray == null)
                return null;

            System.Drawing.Image newImage;

            try
            {
                using (MemoryStream ms = new MemoryStream(bArray, 0, bArray.Length))
                {
                    ms.Write(bArray, 0, bArray.Length);
                    newImage = System.Drawing.Image.FromStream(ms, true);
                }
            }
            catch (Exception ex)
            {
                newImage = null;
                //Log an error here
            }

            return newImage;
        }
        public static string GetMonthName(int month)
        {
            int iMonthNo = month;
            DateTime dtDate = new DateTime(2000, iMonthNo, 1);
            string sMonthName = dtDate.ToString("MMM");
            string sMonthFullName = dtDate.ToString("MMMM");
            //result = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
            //result = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            return sMonthName;
        }


        public static string GetStatusLabelCss(bool Status)
        {
            string cssclass = string.Empty;

            if (Convert.ToBoolean(Status))
                cssclass = CSSClass.StatusLabelSuccess;
            else
                cssclass = CSSClass.StatusLabelDanger;

            return cssclass;
        }

        public static string GCNStatusLabelCss(String Status, String LabelSize)
        {
            string cssclass = string.Empty;

            if (LabelSize == "sm")
            {
                if (Status == "Delivered")
                    cssclass = CSSClass.StatusLabelSuccess;
                else if (Status == "Cancel")
                    cssclass = CSSClass.StatusLabelDanger;
                else if (Status == "Pending" || Status == "UnDelivered")
                    cssclass = CSSClass.StatusLabelWarning;
                else if (Status == "On Way" || Status == "Crossing")
                    cssclass = CSSClass.LabelInfo;
            }
            else if (LabelSize == "round")
            {
                if (Status == "Delivered")
                    cssclass = "btn btn-circle btn-success sbold cursor-text";
                else if (Status == "Cancel")
                    cssclass = "btn btn-circle btn-danger sbold cursor-text";
                else if (Status == "Pending" || Status == "UnDelivered")
                    cssclass = "btn btn-circle btn-warning sbold cursor-text";
                else if (Status == "On Way" || Status == "Crossing")
                    cssclass = "btn btn-circle btn-info sbold cursor-text";
            }
            else
            {
                if (Status == "Delivered")
                    cssclass = CSSClass.LabelSuccess;
                else if (Status == "Cancel")
                    cssclass = CSSClass.LabelDanger;
                else if (Status == "Pending" || Status == "UnDelivered")
                    cssclass = CSSClass.LabelWarning;
                else if (Status == "On Way" || Status == "Crossing")
                    cssclass = CSSClass.LabelInfo;
            }

            return cssclass;
        }

        public static string GetApprovalStatusLabelText(String Status)
        {
            string StatusText = string.Empty;

            if (Status == "Approved")
            {
                StatusText = "Approved";
            }
            else if (Status == "Rejected")
            {
                StatusText = "Rejected";
            }
            else
            {
                StatusText = "Pending";
            }

            return StatusText;
        }

        public static string GetApprovalStatusLabelText(bool Status)
        {
            string StatusText = string.Empty;

            if (Status == true)
            {
                StatusText = "Approved";
            }
            else if (Status == false)
            {
                StatusText = "Rejected";
            }

            return StatusText;
        }

        public static string GetApprovalStatusLabelCss(String Status)
        {
            string cssclass = string.Empty;

            if (Status == "Approved")
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else if (Status == "Rejected")
            {
                cssclass = CSSClass.StatusLabelDanger;
            }
            else if (Status == "Locked")
            {
                cssclass = CSSClass.StatusLabelInfo;
            }
            else
            {
                cssclass = CSSClass.StatusLabelWarning;
            }

            return cssclass;
        }

        public static string GetStatusLabelActiveBlockedCss(bool Status)
        {
            string cssclass = string.Empty;

            if (!Status)
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else
            {
                cssclass = CSSClass.StatusLabelDanger;
            }

            return cssclass;
        }
        public static string GetStatusLabelYesNo(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Yes";
            }
            else
            {
                txt = "No";
            }

            return txt;
        }


        public static string GetStatusLabelChequeReturn(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Returned";
            }

            return txt;
        }

        public static string GetDocumentIcon(string URL)
        {
            string Extension = Path.GetExtension(URL);

            if (Extension.ToLower() == ".txt")
                return CSSClass.TXTIcon;
            else if (Extension.ToLower() == ".pdf")
                return CSSClass.PDFIcon;
            else if (Extension.ToLower() == ".doc" || Extension.ToLower() == ".docx")
                return CSSClass.WordIcon;
            else if (Extension.ToLower() == ".xls" || Extension.ToLower() == ".xlsx" || Extension.ToLower() == ".xlsm" || Extension.ToLower() == ".csv")
                return CSSClass.ExcelIcon;
            else if (Extension.ToLower() == ".jpg" || Extension.ToLower() == ".jpeg" || Extension.ToLower() == ".png" || Extension.ToLower() == ".gif")
                return CSSClass.ImageIcon;
            else
                return CSSClass.DownloadIcon;
        }

        public static string GetImageByURL(string URL)
        {
            var filePath = HttpContext.Current.Server.MapPath(URL);
            var dataUrl = string.Empty;
            if (File.Exists(filePath))
            {
                var bytes = File.ReadAllBytes(filePath);
                var b64String = Convert.ToBase64String(bytes);
                dataUrl = "data:image/png;base64," + b64String;
            }
            return dataUrl;
        }

        #endregion Other

        #region Validation

        public static String IsValidPhoto(FileUpload fu, String ImageName)
        {
            string extension = System.IO.Path.GetExtension(fu.PostedFile.FileName);
            string[] validFileTypes = CV.validImageFileTypes;
            String Message = String.Empty;
            bool IsValid = false;

            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (extension.ToLower() == "." + validFileTypes[i])
                {
                    IsValid = true;
                    break;
                }
            }

            if (IsValid)
            {
                Bitmap img = new Bitmap(fu.PostedFile.InputStream, false);
                int height = img.Height;
                int width = img.Width;
                int fileSize = (fu.PostedFile.ContentLength) / 1024;

                if (height >= CV.MaxPhotoHeightInPX || width >= CV.MaxPhotoWidthInPX || fileSize > CV.MaxPhotoSizeInKB)
                    IsValid = false;

                if (!IsValid)
                    Message = ImageName + " size not be greater than " + CV.MaxPhotoSizeInKB + "KB, " + CV.MaxPhotoWidthInPX.ToString() + " X " + CV.MaxPhotoHeightInPX.ToString() + "px";
            }
            else
                Message = ImageName + " extension must be (" + String.Join(" or ", validFileTypes) + ")";

            return Message;
        }

        public static bool CheckImageType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = CV.validImageFileTypes;
            bool result = false;

            if (FileSize < CV.MaxAllowedFileSize)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static bool CheckFileType(string FileExtension, int FileSize)
        {
            return CheckFileType(FileExtension, FileSize, "Medimum");
        }

        public static bool CheckFileType(string FileExtension, int FileSize, String FileSizeType)
        {
            string[] validFileTypes = CV.validFileTypes;

            bool result = false;

            if (FileSize < CV.MaxAllowedFileSize)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckFileTypeWithOutImageFile(string FileExtension, int FileSize)
        {
            string[] validFileTypes = CV.validFileTypesWithOutImageFileType;

            bool result = false;

            if (FileSize < CV.MaxAllowedFileSize)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }



        public static bool CheckFileType(string FileExtension, int FileSize, int MaxAllowedSize)
        {
            string[] validFileTypes = CV.validFileTypes;

            bool result = false;

            if (FileSize < MaxAllowedSize)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckPDFFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "pdf" };
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }


        public static bool CheckWordFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "doc", "docx" };
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckWordPDFFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "pdf", "doc", "docx" };
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckDocumentType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "doc", "docx", "pdf", "jpg", "jpeg", "png", "gif", "bmp" };
            bool result = false;

            if (FileSize < 52428800)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckExcelFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = CV.validOnlyExcelFileTypes;
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckHTMLFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "html", "htm" };
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool ValidateFromDateToDate(DateTime FromDate, DateTime ToDate)
        {
            bool result = false;

            if (FromDate <= ToDate)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static void SetIcon(HtmlControl Control, String URL)
        {
            string Extension = Path.GetExtension(URL);
            if (Extension.ToLower() == ".txt")
                Control.Attributes.Add("class", CSSClass.TXTIcon);
            else if (Extension.ToLower() == ".pdf")
                Control.Attributes.Add("class", CSSClass.PDFIcon);
            else if (Extension.ToLower() == ".doc" || Extension.ToLower() == ".docx")
                Control.Attributes.Add("class", CSSClass.WordIcon);
            else if (Extension.ToLower() == ".xls" || Extension.ToLower() == ".xlsx" || Extension.ToLower() == ".xlsm" || Extension.ToLower() == ".csv")
                Control.Attributes.Add("class", CSSClass.ExcelIcon);
            else if (Extension.ToLower() == ".jpg" || Extension.ToLower() == ".jpeg" || Extension.ToLower() == ".png" || Extension.ToLower() == ".gif" || Extension.ToLower() == ".bmp")
                Control.Attributes.Add("class", CSSClass.ImageIcon);
            else
                Control.Attributes.Add("class", CSSClass.DownloadIcon);
        }


        public static Boolean IsValideFinYearDate(DateTime VoucherDate, out String ErrorMsg)
        {
            SqlDateTime FinYearFromDate = SqlDateTime.Null;
            SqlDateTime FinYearToDate = SqlDateTime.Null;

            if (HttpContext.Current.Session["FinYearFromDate"] != null && HttpContext.Current.Session["FinYearToDate"] != null)
            {
                FinYearFromDate = Convert.ToDateTime(HttpContext.Current.Session["FinYearFromDate"]).Date;
                FinYearToDate = Convert.ToDateTime(HttpContext.Current.Session["FinYearToDate"]).Date;

                if (VoucherDate.Date >= FinYearFromDate.Value.Date && VoucherDate.Date <= FinYearToDate.Value.Date)
                {
                    ErrorMsg = String.Empty;
                    return true;
                }
                else
                {
                    ErrorMsg = "Date allowed between Fin Year Date <b>From " + FinYearFromDate.Value.Date.ToShortDateString() + " To " + FinYearToDate.Value.Date.ToShortDateString() + "</b>";
                    return false;
                }
            }
            else
            {
                ErrorMsg = "Fin Year not available or session expired";
                return false;
            }
        }

        #endregion Validation

        #region Document
        public static Boolean UploadDocument(FileUpload fu, String DirectoryPath, String NewPath, String OldPath)
        {
            #region Upload Document
            if (fu.HasFile && NewPath != String.Empty)
            {
                #region Create File Path

                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                #endregion Create File Path

                #region Upload File

                fu.SaveAs(NewPath);

                #endregion Upload File
            }
            #endregion Upload Document

            return true;
        }

        public static void DownloadDocument(String Path, String FileName)
        {
            #region Download Document

            if (File.Exists(Path))
            {
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + FileName + "\"");
                byte[] data = req.DownloadData(Path);
                response.BinaryWrite(data);
                response.End();
            }

            #endregion Download Document
        }

        #endregion Document

        #region Generate Password
        public static string GenerateRandomPWD(int length)
        {
            return "";
        }

        #endregion Generate Password

        #region Error Log

        public static void SaveErrorToDb(Exception ex)
        {


        }


        public static void Error(string message)
        {
            //MailMessage mm = new MailMessage();

            //mm.Body = message;
            //mm.IsBodyHtml = true;
            //mm.To.Add(CV.EmailDeveloper);
            //mm.Subject = "Error from "+CV.DefaultCompanyName+" - " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            ////SendEmail(mm);
            //return;
        }

        #endregion Error Log

        #region Security

        public static Boolean IsAllowedForOperation(String FormName, out Boolean IsAdd, out Boolean IsEdit, out Boolean IsView, out Boolean IsDelete, out Boolean IsPrint)
        {
            IsAdd = false;
            IsEdit = false;
            IsView = false;
            IsDelete = false;
            IsPrint = false;

            if (HttpContext.Current.Session["UserID"] == null)
                return false;

            #region Gather Data
            SqlString CurrentMenuURL = HttpContext.Current.Request.Url.AbsoluteUri;
            SqlString SessionID = System.Web.HttpContext.Current.Session.SessionID;
            SqlString IPAddress = GetClientIP();
            #endregion Gather Data

            //SEC_UserGroupWiseMenuBAL balSEC_UserWiseMenu = new SEC_UserGroupWiseMenuBAL();

            //DataTable dtSEC_UserWiseMenu = balSEC_UserWiseMenu.SelectToCheckUserRight(FormName, CurrentMenuURL, SessionID, IPAddress, Convert.ToInt32(HttpContext.Current.Session["UserID"]));
            //if (dtSEC_UserWiseMenu != null && dtSEC_UserWiseMenu.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dtSEC_UserWiseMenu.Rows)
            //    {
            //        if (!dr["IsAdd"].Equals(System.DBNull.Value))
            //            IsAdd = Convert.ToBoolean(dr["IsAdd"]);

            //        if (!dr["IsEdit"].Equals(System.DBNull.Value))
            //            IsEdit = Convert.ToBoolean(dr["IsEdit"]);

            //        if (!dr["IsView"].Equals(System.DBNull.Value))
            //            IsView = Convert.ToBoolean(dr["IsView"]);

            //        if (!dr["IsDelete"].Equals(System.DBNull.Value))
            //            IsDelete = Convert.ToBoolean(dr["IsDelete"]);

            //        if (!dr["IsPrint"].Equals(System.DBNull.Value))
            //            IsPrint = Convert.ToBoolean(dr["IsPrint"]);

            //    }
            //    return true;

            //}
            //else
            return false;
        }


        public static string GetClientIP()
        {
            string ip = "";
            string strHostName = "";
            strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            //ip = addr[2].ToString();
            return ip;
        }

        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        public static string GetOS(String UserAgent)
        {
            String OsName = UserAgent;
            if (UserAgent.IndexOf("Windows NT 6.3") > 0)
                OsName = "Windows 8.1";
            else if (UserAgent.IndexOf("Windows NT 6.2") > 0)
                OsName = "Windows 8";
            else if (UserAgent.IndexOf("Windows NT 6.1") > 0)
                OsName = "Windows 7";
            else if (UserAgent.IndexOf("Windows NT 6.0") > 0)
                OsName = "Windows Vista";
            else if (UserAgent.IndexOf("Windows NT 5.2") > 0)
                OsName = "Windows Server 2003; Windows XP x64 Edition";
            else if (UserAgent.IndexOf("Windows NT 5.1") > 0)
                OsName = "Windows XP";
            else if (UserAgent.IndexOf("Windows NT 5.01") > 0)
                OsName = "Windows 2000, Service Pack 1 (SP1)";
            else if (UserAgent.IndexOf("Windows NT 5.0") > 0)
                OsName = "Windows 2000";
            else if (UserAgent.IndexOf("Windows NT 4.0") > 0)
                OsName = "Microsoft Windows NT 4.0";
            else if (UserAgent.IndexOf("Win 9x 4.90") > 0)
                OsName = "Windows Millennium Edition (Windows Me)";
            else if (UserAgent.IndexOf("Windows 98") > 0)
                OsName = "Windows 98";
            else if (UserAgent.IndexOf("Windows 95") > 0)
                OsName = "Windows 95";
            else if (UserAgent.IndexOf("Windows CE") > 0)
                OsName = "Windows CE";

            return OsName;
        }


        public static Boolean IsLocked(SqlString LockLevel)
        {
            if (LockLevel.Value != String.Empty)
                return true;
            else
                return false;
        }


        #endregion Security

        #region Common
        public static void ImageResize(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        public static void ImageResizeHeightWidth(int Height, int Width, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = Width;
                var newHeight = Height;
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        public static string GetInRuppe(String Amount)
        {
            String Amt = "";
            if (Amount != String.Empty)
            {
                decimal parsed = decimal.Parse(Amount, CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                Amt = string.Format(hindi, "{0:c}", parsed);
            }
            return Amt;
        }

        public static string ToOrdinal(Int32 i, SqlString word)
        {
            string suffix = "<sup>th</sup>";
            string final = "";
            if (word != "")
            {
                switch (i % 100)
                {
                    case 11:
                    case 12:
                    case 13:
                        break;
                    default:
                        switch (i % 10)
                        {
                            case 1:
                                suffix = "<sup>st</sup>";
                                break;
                            case 2:
                                suffix = "<sup>nd</sup>";
                                break;
                            case 3:
                                suffix = "<sup>rd</sup>";
                                break;
                        }
                        break;
                }
                final = i.ToString() + suffix + " " + word.ToString();
            }
            return final;
        }

        public static Int32 HourFormatsToMinutes(String HourFormat)
        {
            //HourFormat is as per dtpTimeSelector of the theme: eg. 12:20 AM
            return Convert.ToInt32(DateTime.Parse(HourFormat).Hour) * 60 + Convert.ToInt32(DateTime.Parse(HourFormat).Minute);
        }

        public static string GetReportFileName(string FileName)
        {
            FileName = FileName.Replace(".", "_");
            FileName = FileName.Replace(",", "_");
            FileName = FileName.Replace("*", "_");
            FileName = FileName.Replace("\"", "_");
            FileName = FileName.Replace("\\", "_");
            FileName = FileName.Replace("/", "_");
            FileName = FileName.Replace("[", "_");
            FileName = FileName.Replace("]", "_");
            FileName = FileName.Replace(":", "_");
            FileName = FileName.Replace(";", "_");
            FileName = FileName.Replace("|", "_");
            FileName = FileName.Replace("=", "_");
            FileName = FileName.Replace("?", "_");
            FileName = FileName.Replace("<", "_");
            FileName = FileName.Replace(">", "_");
            FileName = FileName.Replace(" ", "_");
            FileName = FileName.Replace("-", "_");
            FileName = FileName.Replace("__", "_");
            FileName = FileName.Replace("__", "_");
            FileName = FileName.Replace("__", "_");

            return FileName;
        }

        public static string ConvertDatatableToXML_New(DataTable dt)
        {
            String xmlData = String.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                xmlData += "<" + dt.TableName.ToString() + ">\r\n";
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType.Name == "DateTime" && dr[dc.ColumnName.ToString()].ToString().Trim() != String.Empty)
                        xmlData += "<" + dc.ColumnName.ToString() + ">" + Convert.ToDateTime(dr[dc.ColumnName.ToString()].ToString()).ToString("yyyy-MM-dd hh:mm:ss") + "</" + dc.ColumnName.ToString() + ">\r\n";
                    else if (dr[dc.ColumnName.ToString()].ToString() != String.Empty)
                        xmlData += "<" + dc.ColumnName.ToString() + ">" + dr[dc.ColumnName.ToString()].ToString() + "</" + dc.ColumnName.ToString() + ">\r\n";
                    else
                        xmlData += "<" + dc.ColumnName.ToString() + "></" + dc.ColumnName.ToString() + ">\r\n";
                }
                xmlData += "</" + dt.TableName.ToString() + ">\r\n";
            }
            return xmlData;
        }

        #endregion Common

        #region Create Matrix

        public static DataTable DataTableToDataMatrix(DataTable dt, String PrimaryKeyColumns, String TableColumns, String TableColumnsTitle, String MatrixColumns, String MatrixColumnsTitle, String CellColumn, String OrderBy)
        {
            DataTable dtMatrix = new DataTable();

            String[] TableColumnsArray = TableColumns.Split(new char[] { ',' });
            String[] TableColumnsTitleArray = TableColumnsTitle.Split(new char[] { ',' });
            String[] MatrixColumnsArray = MatrixColumns.Split(new char[] { ',' });
            String[] MatrixColumnsTitleArray = MatrixColumnsTitle.Split(new char[] { ',' });
            String[] OrderByArray = OrderBy.Split(new char[] { ',' });

            #region Step 1 : Add Table Columns to dtMatrix
            for (Int32 i = 0; i < TableColumnsArray.Length; i++)
            {
                DataColumn dc = new DataColumn(TableColumnsArray[i], dt.Columns[TableColumnsArray[i]].DataType);
                dc.Caption = TableColumnsTitleArray[i];
                dtMatrix.Columns.Add(dc);
            }
            #endregion Step 1 : Add Table Columns to dtMatrix

            #region Step 2 : Add Matrix Columns to dtMatrix
            // For Each Column of Matrix Column Array
            for (Int32 i = 0; i < MatrixColumnsArray.Length; i++)
            {
                // Verify each and every row for each column
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[MatrixColumnsArray[i]].Equals(DBNull.Value))
                        continue;

                    // If dtMatrix already contains column
                    if (dtMatrix.Columns.Contains(dr[MatrixColumnsArray[i]].ToString()))
                        continue;

                    DataColumn dcNew = new DataColumn(dr[MatrixColumnsArray[i]].ToString());

                    // Caption is assigned with Matrix Columns Title Array
                    dcNew.Caption = MatrixColumnsTitleArray[i];

                    // Replace Columns Names in caption with Column Value
                    foreach (DataColumn dc in dt.Columns)
                        dcNew.Caption = dcNew.Caption.Replace("~" + dc.ColumnName + "~", dr[dc.ColumnName].ToString());

                    dtMatrix.Columns.Add(dcNew);
                }
            }
            #endregion Step 2 : Add Matrix Columns to dtMatrix

            #region Step 3 : Transfer Data
            // Each row of dt
            foreach (DataRow dr in dt.Rows)
            {
                // Each Matrix Column
                for (Int32 i = 0; i < MatrixColumnsArray.Length; i++)
                {
                    Int32 j = 0;
                    for (; j < dtMatrix.Rows.Count; j++)
                    {
                        if (dtMatrix.Rows[j][PrimaryKeyColumns].ToString() == dr[PrimaryKeyColumns].ToString())
                            break;
                    }
                    // If Table Row is added to Matrix Row then j < Matrix row so following condition is false else it will add new row
                    #region Check Whether Row Is Added or Not
                    if (j == dtMatrix.Rows.Count)
                    {
                        DataRow drNew = dtMatrix.NewRow();

                        foreach (String _TableColumns in TableColumnsArray)
                        {
                            if (dr[_TableColumns].Equals(DBNull.Value))
                                continue;
                            drNew[_TableColumns] = dr[_TableColumns];
                        }

                        dtMatrix.Rows.Add(drNew);
                    }
                    #endregion Check Whether Row Is Added or Not

                    // Set Value to Matrix Column and Table Row
                    if (!dr[CellColumn].Equals(DBNull.Value))
                        dtMatrix.Rows[j][dr[MatrixColumnsArray[i]].ToString()] = dr[CellColumn];
                }
            }
            #endregion Step 3 : Transfer Data

            return dtMatrix;
        }

        #endregion

        #region Import/Export

        public static DataTable ImportExcelToDataTable(string FilePath, string Extension, Boolean hasHDR)
        {
            try
            {
                string conStr = "";
                string isHDR = "";

                if (hasHDR)
                    isHDR = "Yes";
                else
                    isHDR = "No";

                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                                 .ConnectionString;
                        break;
                    case ".xlsx": //Excel 07
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                                  .ConnectionString;
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void ExportDataTableToExcel(DataTable dt, String FileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", FileName + ".xls"));

            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

            HttpContext.Current.Response.Write("<style>TD { mso-number-format:\\@; white-space: nowrap; } </style>");

            HttpContext.Current.Response.Write("<Table border='1'" +
              "borderColor='#000000' cellSpacing='0' cellPadding='0'><TR>");
            int columnscount = dt.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {
                HttpContext.Current.Response.Write("<Td>");
                HttpContext.Current.Response.Write(dt.Columns[j].ColumnName.ToString());
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in dt.Rows)
            {//write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            //HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static String ConvertDataTableToCSVString(DataTable dt)
        {
            StringBuilder sbExcel = new StringBuilder();
            foreach (DataColumn col in dt.Columns)
            {
                sbExcel.Append(col.ColumnName + ',');
            }
            sbExcel.Remove(sbExcel.Length - 1, 1);
            sbExcel.Append(Environment.NewLine);
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sbExcel.Append(row[i].ToString() + ",");
                }

                sbExcel.Append(Environment.NewLine);
            }

            return sbExcel.ToString();
        }

        public static void ExportDataTableToCSVFile(DataTable dtTable, String FileName)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append(col.ColumnName + ',');
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        sbldr.Append(row[column].ToString() + ',');
                    }
                    sbldr.Append("\r\n");
                }
            }

            HttpContext.Current.Response.ContentType = "Application/x-msexcel";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".csv");
            HttpContext.Current.Response.Write(sbldr.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportDataTableToCSVFilePipeline(DataTable dtTable, String FileName)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append(col.ColumnName + '|');
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        sbldr.Append(row[column].ToString() + '|');
                    }
                    sbldr.Append("\r\n");
                }
            }

            HttpContext.Current.Response.ContentType = "Application/x-msexcel";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".csv");
            HttpContext.Current.Response.Write(sbldr.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportDataTableToTXTFilePipeline(DataTable dtTable, String FileName)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append(col.ColumnName + '|');
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        sbldr.Append(row[column].ToString() + '|');
                    }
                    sbldr.Append("\r\n");
                }
            }

            HttpContext.Current.Response.ContentType = "Application/x-msexcel";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".txt");
            HttpContext.Current.Response.Write(sbldr.ToString());
            HttpContext.Current.Response.End();
        }

        #endregion Import/Export

        #region Conversion

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
        }
        public static string ConvertDatatableToXML(DataTable dt)
        {
            String xmlData = String.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                xmlData += "<" + dt.TableName.ToString() + ">\r\n";
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType.Name == "DateTime" && dr[dc.ColumnName.ToString()].ToString().Trim() != String.Empty)
                        xmlData += "<" + dc.ColumnName.ToString() + ">" + Convert.ToDateTime(dr[dc.ColumnName.ToString()].ToString()).ToString("yyyy-MM-dd hh:mm:ss") + "</" + dc.ColumnName.ToString() + ">\r\n";
                    else if (dr[dc.ColumnName.ToString()].ToString() != String.Empty)
                        xmlData += "<" + dc.ColumnName.ToString() + ">" + dr[dc.ColumnName.ToString()].ToString() + "</" + dc.ColumnName.ToString() + ">\r\n";
                    else
                        xmlData += "<" + dc.ColumnName.ToString() + "></" + dc.ColumnName.ToString() + ">\r\n";
                }
                xmlData += "</" + dt.TableName.ToString() + ">\r\n";
            }


            return xmlData;
        }

        #endregion Conversion

        #region Custom Developer Function

        public static void BindEmptyRepeater(Repeater rp)
        {
            rp.DataSource = null;
            rp.DataBind();
        }

        public static void BindEmptyGrid(GridView gv)
        {
            gv.DataSource = null;
            gv.DataBind();
        }

        public static void SetFocusWithoutScroll(Control c, String ClientID)
        {
            string script = string.Format("$('#{0}').focus();", ClientID);
            ScriptManager.RegisterStartupScript(c, c.GetType(), "SetFocus", script, true);
        }

        public static void FillDropDownListBlank(DropDownList ddl, String DropDownName)
        {
            ddl.Items.Clear();
            ddl.DataSource = null;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select " + DropDownName, "-99"));
        }

        public static DataTable DataTableRemoveReadOnlyProperty(DataTable dt)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                dc.ReadOnly = false;
                dc.AllowDBNull = true;
            }
            return dt;
        }

        #endregion Custom Developer Function

        #region FillDropDownList


        public static void FillDropDownListYear(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Year", "-99"));
            for (int i = DateTime.Now.Year + 1; i >= 1970; i--)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        public static void FillDropDownListMonth(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Month", "-99"));
            for (int i = 1; i <= 12; i++)
            {
                string monthName = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i);
                ddl.Items.Add(new ListItem(i.ToString() + "-" + monthName, i.ToString()));
            }
        }





        #endregion FillDropDownList

        public static Boolean IsAllowedForOperation(Object listPageFormName, out Object isAdd, out Object isEdit, out Object isView, out Object isDelete, out Object isPrint)
        {
            throw new NotImplementedException();
        }

        public static DateTime GetPreviousMonthFirstDate()
        {
            Int32 Month = DateTime.Now.Month;
            if (Month == 1)
                Month = 12;
            else
                Month = Month - 1;

            return new DateTime(DateTime.Now.Year, Month, 1);
        }
        public static DateTime GetPreviousMonthLastDate()
        {
            Int32 Month = DateTime.Now.Month;
            if (Month == 1)
                Month = 12;
            else
                Month = Month - 1;

            return new DateTime(DateTime.Now.Year, Month, DateTime.DaysInMonth(DateTime.Now.Year, Month));
        }

        public static void FillDropDownListWeather(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select Weather", "-99"));
            ddl.Items.Insert(1, new ListItem("Clear", "Clear"));
            ddl.Items.Insert(2, new ListItem("Rain", "Rain"));
            ddl.Items.Insert(3, new ListItem("Fair", "Fair"));
            ddl.Items.Insert(4, new ListItem("Cloudy", "Cloudy"));
            ddl.Items.Insert(5, new ListItem("Shower", "Shower"));
            ddl.Items.Insert(6, new ListItem("Snow", "Snow"));
        }

        public static void FillDropDownListTemperature(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select Temperature", "-99"));
            ddl.Items.Insert(1, new ListItem("<0 °C", "<0 °C"));
            ddl.Items.Insert(2, new ListItem("0-5 °C", "0-5 °C"));
            ddl.Items.Insert(3, new ListItem("5-10 °C", "5-10 °C"));
            ddl.Items.Insert(4, new ListItem("10-20 °C", "10-20 °C"));
            ddl.Items.Insert(5, new ListItem("20-30 °C", "20-30 °C"));
            ddl.Items.Insert(6, new ListItem(">30 °C", ">30 °C"));
        }

        public static void FillDropDownListWind(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select Wind", "-99"));
            ddl.Items.Insert(1, new ListItem("Still", "Still"));
            ddl.Items.Insert(2, new ListItem("Light", "Light"));
            ddl.Items.Insert(3, new ListItem("Strong", "Strong"));
            ddl.Items.Insert(4, new ListItem("Gale", "Gale"));
        }

        public static void FillDropDownListHumidity(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select Humidity", "-99"));
            ddl.Items.Insert(1, new ListItem("Dry", "Dry"));
            ddl.Items.Insert(2, new ListItem("Low", "Low"));
            ddl.Items.Insert(3, new ListItem("Medium", "Medium"));
            ddl.Items.Insert(4, new ListItem("High", "High"));
        }
        public static String WindIcon(String WindIcon)
        {
            if (WindIcon == "Still")
            {
                WindIcon = "fas fa-cloud-sun";
            }
            if (WindIcon == "Light")
            {
                WindIcon = "fas fa-cloud-sun-rain";
            }
            if (WindIcon == "Strong")
            {
                WindIcon = "fas fa-wind";
            }
            if (WindIcon == "Gale")
            {
                WindIcon = "fas fa-bolt";
            }
            return WindIcon;
        }

        public static String WindColor(String WindColor)
        {
            if (WindColor == "Still")
            {
                WindColor = "#26a69a";
            }
            if (WindColor == "Light")
            {
                WindColor = "#f2cf0d";
            }
            if (WindColor == "Strong")
            {
                WindColor = "#c82828";
            }
            if (WindColor == "Gale")
            {
                WindColor = "#cc9d1a";
            }
            return WindColor;
        }
        public static String HumidityIcon(String HumidityIcon)
        {
            if (HumidityIcon == "Dry")
            {
                HumidityIcon = "fas fa-snowflake";
            }
            if (HumidityIcon == "Low")
            {
                HumidityIcon = "fas fa-cloud-rain";
            }
            if (HumidityIcon == "Medium")
            {
                HumidityIcon = "fas fa-smog";
            }
            if (HumidityIcon == "High")
            {
                HumidityIcon = "fas fa-temperature-high";
            }
            return HumidityIcon;
        }

        public static String HumidityColor(String HumidityColor)
        {
            if (HumidityColor == "Dry")
            {
                HumidityColor = "#0094ff";
            }
            if (HumidityColor == "Low")
            {
                HumidityColor = "#26a69a";
            }
            if (HumidityColor == "Medium")
            {
                HumidityColor = "#cf8fe1";
            }
            if (HumidityColor == "High")
            {
                HumidityColor = "#46a7ee";
            }
            return HumidityColor;
        }
        public static String WeatherIcon(String WeatherIcon)
        {
            if (WeatherIcon == "Clear")
            {
                WeatherIcon = "	fas fa-sun";
            }
            if (WeatherIcon == "Rain")
            {
                WeatherIcon = "fas fa-cloud-showers-heavy";
            }
            if (WeatherIcon == "Fair")
            {
                WeatherIcon = "fas fa-cloud-sun";
            }
            if (WeatherIcon == "Cloudy")
            {
                WeatherIcon = "fas fa-cloud";
            }
            if (WeatherIcon == "Shower")
            {
                WeatherIcon = "fas fa-cloud-rain";
            }
            if (WeatherIcon == "Snow")
            {
                WeatherIcon = "far fa-snowflake";
            }
            return WeatherIcon;
        }
        public static String WeatherColor(String WeatherColor)
        {
            if (WeatherColor == "Clear")
            {
                WeatherColor = "#a9bb30";
            }
            if (WeatherColor == "Rain")
            {
                WeatherColor = "#0094ff";
            }
            if (WeatherColor == "Fair")
            {
                WeatherColor = "#4800ff";
            }
            if (WeatherColor == "Cloudy")
            {
                WeatherColor = "#58adea";
            }
            if (WeatherColor == "Shower")
            {
                WeatherColor = "#5491bd";
            }
            if (WeatherColor == "Snow")
            {
                WeatherColor = "#0e44c4";
            }
            return WeatherColor;
        }
        public static String TemperatureColor(String TemperatureColor)
        {
            if (TemperatureColor == "<0 °C")
            {
                TemperatureColor = "#9c2fae";
            }
            if (TemperatureColor == "0-5 °C")
            {
                TemperatureColor = "#663fb4";
            }
            if (TemperatureColor == "5-10 °C")
            {
                TemperatureColor = "#4055b2";
            }
            if (TemperatureColor == "10-20 °C")
            {
                TemperatureColor = "#587cf7";
            }
            if (TemperatureColor == "20-30 °C")
            {
                TemperatureColor = "#1daaf1";
            }
            if (TemperatureColor == ">30 °C")
            {
                TemperatureColor = "#1ebdd0";
            }
            return TemperatureColor;
        }


        #region Send SMS
        public static bool SendSMS(String MobileNo, String SMSText)
        {
            return true;
        }

        #endregion Send SMS

        public static Boolean SendEmail(MailMessage mm)
        {
            return true;
        }
    
    }
}