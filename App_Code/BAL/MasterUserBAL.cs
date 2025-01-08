using CompaniesatyourDoorstpe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public class MasterUserBAL : MasterUserBALBase
    {
        #region SelectByUsernameAndPassword

        public DataTable SelectByUsernameAndPassword(SqlString Username, SqlString Password)
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            return dalMasterUser.SelectByUsernameAndPassword(Username, Password);
        }

        #endregion SelectByUsernameAndPassword

        #region CheckByUsername

        public DataTable CheckByUsername(SqlString Username)
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            return dalMasterUser.CheckByUsername(Username);
        }

        #endregion CheckByUsername

        #region UpdatePasswordByUserID

        public Boolean UpdatePasswordByUserID(SqlInt32 UserID, SqlString Password)
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            if (dalMasterUser.UpdatePasswordByUserID(UserID, Password))
            {
                return true;
            }
            else
            {
                this.Message = dalMasterUser.Message;
                return false;
            }
        }

        #endregion UpdatePasswordByUserID
    }
}