using CompaniesatyourDoorstpe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public class LoginBAL : LoginBALBase
    {
        #region SelectByUsernameAndPasswordAndRole

        public DataTable SelectByUsernameAndPasswordAndRole(SqlString Username, SqlString Password , SqlString Role)
        {
            LoginDAL dalLogin = new LoginDAL();
            return dalLogin.SelectByUsernameAndPasswordAndRole(Username, Password,Role);
        }

        #endregion SelectByUsernameAndPasswordAndRole

        #region CheckByUsername

        public DataTable CheckByUsername(SqlString Username)
        {
            LoginDAL dalLogin = new LoginDAL();
            return dalLogin.CheckByUsername(Username);
        }

        #endregion CheckByUsername

        #region UpdatePasswordByUsername

        public Boolean UpdatePasswordByUsername(SqlInt32 Username, SqlString Password)
        {
            LoginDAL dalLogin = new LoginDAL();
            if (dalLogin.UpdatePasswordByUsername(Username, Password))
            {
                return true;
            }
            else
            {
                this.Message = dalLogin.Message;
                return false;
            }
        }

        #endregion UpdatePasswordByUsername
    }
}