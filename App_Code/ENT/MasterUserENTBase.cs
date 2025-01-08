using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class MasterUserENTBase
    {
        #region Properties

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
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

        protected SqlString _Password;
        public SqlString Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        protected SqlString _MobileNo;
        public SqlString MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
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

        protected SqlDateTime _Birthdate;
        public SqlDateTime Birthdate
        {
            get
            {
                return _Birthdate;
            }
            set
            {
                _Birthdate = value;
            }
        }

        #endregion Properties

        #region Constructor

        public MasterUserENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MasterUserENT_String = String.Empty;

            if (!UserID.IsNull)
                MasterUserENT_String += " UserID = " + UserID.Value.ToString();

            if (!Username.IsNull)
                MasterUserENT_String += "| Username = " + Username.Value;

            if (!Password.IsNull)
                MasterUserENT_String += "| Password = " + Password.Value;

            if (!MobileNo.IsNull)
                MasterUserENT_String += "| MobileNo = " + MobileNo.Value;

            if (!EmailAddress.IsNull)
                MasterUserENT_String += "| EmailAddress = " + EmailAddress.Value;

            if (!Birthdate.IsNull)
                MasterUserENT_String += "| Birthdate = " + Birthdate.Value.ToString("dd-MM-yyyy");

            MasterUserENT_String = MasterUserENT_String.Trim();

            return MasterUserENT_String;
        }

        #endregion ToString
    }
}