using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class CandidateBasicDetailsENTBase
    {
        #region Properties

        protected SqlInt32 _CandidateID;
        public SqlInt32 CandidateID
        {
            get
            {
                return _CandidateID;
            }
            set
            {
                _CandidateID = value;
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

        protected SqlDateTime _ProfileDate;
        public SqlDateTime ProfileDate
        {
            get
            {
                return _ProfileDate;
            }
            set
            {
                _ProfileDate = value;
            }
        }

        protected SqlString _FirstName;
        public SqlString FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        protected SqlString _MiddleName;
        public SqlString MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                _MiddleName = value;
            }
        }

        protected SqlString _LastName;
        public SqlString LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        protected SqlString _CandidateAddress;
        public SqlString CandidateAddress
        {
            get
            {
                return _CandidateAddress;
            }
            set
            {
                _CandidateAddress = value;
            }
        }

        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }

        protected SqlString _Gender;
        public SqlString Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        protected SqlDateTime _DOB;
        public SqlDateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
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

        protected SqlString _EmailAddress;
        public SqlString EmailAddress
        {
            get
            {
                return _EmailAddress;
            }
            set
            {
                _EmailAddress = value;
            }
        }

        protected SqlString _ImageUrl;
        public SqlString ImageUrl
        {
            get
            {
                return _ImageUrl;
            }
            set
            {
                _ImageUrl = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CandidateBasicDetailsENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String CandidateBasicDetailsENT_String = String.Empty;

            if (!CandidateID.IsNull)
                CandidateBasicDetailsENT_String += " CandidateID = " + CandidateID.Value.ToString();
            
            if (!Username.IsNull)
                CandidateBasicDetailsENT_String += "| Username = " + Username.Value;

            if (!QueID.IsNull)
                CandidateBasicDetailsENT_String += "| QueID = " + QueID.Value.ToString();

            if (!Ans.IsNull)
                CandidateBasicDetailsENT_String += "| Ans = " + Ans.Value;

            if (!ProfileDate.IsNull)
                CandidateBasicDetailsENT_String += "| ProfileDate = " + ProfileDate.Value.ToString("dd-MM-yyyy");

            if (!FirstName.IsNull)
                CandidateBasicDetailsENT_String += "| FirstName = " + FirstName.Value;

            if (!MiddleName.IsNull)
                CandidateBasicDetailsENT_String += "| MiddleName = " + MiddleName.Value;

            if (!LastName.IsNull)
                CandidateBasicDetailsENT_String += "| LastName = " + LastName.Value;

            if (!CandidateAddress.IsNull)
                CandidateBasicDetailsENT_String += "| CandidateAddress = " + CandidateAddress.Value;

            if (!CityID.IsNull)
                CandidateBasicDetailsENT_String += "| CityID = " + CityID.Value.ToString();

            if (!Gender.IsNull)
                CandidateBasicDetailsENT_String += "| Gender = " + Gender.Value;

            if (!DOB.IsNull)
                CandidateBasicDetailsENT_String += "| DOB = " + DOB.Value.ToString("dd-MM-yyyy");
           
            if (!ContactNo.IsNull)
                CandidateBasicDetailsENT_String += "| ContactNo = " + ContactNo.Value;
            
            if (!EmailAddress.IsNull)
                CandidateBasicDetailsENT_String += "| EmailAddress = " + EmailAddress.Value;

            if (!ImageUrl.IsNull)
                CandidateBasicDetailsENT_String += "| ImageUrl = " + ImageUrl.Value;
           
            CandidateBasicDetailsENT_String = CandidateBasicDetailsENT_String.Trim();

            return CandidateBasicDetailsENT_String;
        }

        #endregion ToString
    }
}