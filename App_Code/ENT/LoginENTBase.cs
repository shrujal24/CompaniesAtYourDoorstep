using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class LoginENTBase
    {
        #region Properties
        
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
       
        protected SqlString _Role;
        public SqlString Role
        {
            get
            {
                return _Role;
            }
            set
            {
                _Role = value;
            }
        }



        #endregion Properties

        #region Constructor

        public LoginENTBase()
        {
            
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String LoginENT_String = String.Empty;

          
            if (!Username.IsNull)
                LoginENT_String += "| Username = " + Username.Value;
            
            if (!Password.IsNull)
                LoginENT_String += "| Password = " + Password.Value;

            if (!Role.IsNull)
                LoginENT_String += "| Role = " + Role.Value;

            LoginENT_String = LoginENT_String.Trim();

            return LoginENT_String;
        }

        #endregion ToString
    }
}