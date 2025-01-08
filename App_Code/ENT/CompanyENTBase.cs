using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class CompanyENTBase
    {

        #region Properties

        protected SqlInt32 _CompanyID;
        public SqlInt32 CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                _CompanyID = value;
            }
        }

        protected SqlString _CompanyName;
        public SqlString CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }

        protected SqlString _Username;
        public SqlString Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }

        protected SqlInt32 _QueID;
        public SqlInt32 QueID
        {
            get
            {
                return _QueID;
            }
            set
            {
                _QueID = value;
            }
        }

        protected SqlString _Ans;
        public SqlString Ans
        {
            get
            {
                return _Ans;
            }
            set
            {
                _Ans = value;
            }
        }
        protected SqlString _CompanyAddress;
        public SqlString CompanyAddress
        {
            get
            {
                return _CompanyAddress;
            }
            set
            {
                _CompanyAddress = value;
            }
        }

        protected SqlString _CompanyEmail;
        public SqlString CompanyEmail
        {
            get
            {
                return _CompanyEmail;
            }
            set
            {
                _CompanyEmail = value;
            }
        }

        protected SqlString _CompanyDetails;
        public SqlString CompanyDetails
        {
            get
            {
                return _CompanyDetails;
            }
            set
            {
                _CompanyDetails = value;
            }
        }

        protected SqlString _ContactNo;
        public SqlString ContactNo
        {
            get
            {
                return _ContactNo;
            }
            set
            {
                _ContactNo = value;
            }
        }

        

        #endregion Properties

        #region Constructor

        public CompanyENTBase()
        {
           
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String CompanyENT_String = String.Empty;

            if (!CompanyID.IsNull)
                CompanyENT_String += " CompanyID = " + CompanyID.Value.ToString();

            if (!CompanyName.IsNull)
                CompanyENT_String += "| CompanyName = " + CompanyName.Value;

            if (!Username.IsNull)
                CompanyENT_String += "| Username = " + Username.Value;

            if (!QueID.IsNull)
                CompanyENT_String += "| QueID = " + QueID.Value.ToString();

            if (!Ans.IsNull)
                CompanyENT_String += "| Ans = " + Ans.Value;

            if (!CompanyAddress.IsNull)
                CompanyENT_String += "| CompanyAddress = " + CompanyAddress.Value;

            if (!CompanyEmail.IsNull)
                CompanyENT_String += "| CompanyEmail = " + CompanyEmail.Value;

            if (!CompanyDetails.IsNull)
                CompanyENT_String += "| CompanyDetails = " + CompanyDetails.Value;

            if (!ContactNo.IsNull)
                CompanyENT_String += "| ContactNo = " + ContactNo.Value;

            CompanyENT_String = CompanyENT_String.Trim();

            return CompanyENT_String;
        }

        #endregion ToString
    }
}