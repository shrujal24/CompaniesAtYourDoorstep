using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.DAL
{
    public class MasterUserDAL : MasterUserDALBase
    {
        #region SelectByUsernameAndPassword
        public DataTable SelectByUsernameAndPassword(SqlString Username, SqlString Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MasterUser_SelectByUsernameAndPassword");

                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, Username);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, Password);

                DataTable dtMasterUser = new DataTable("PR_MasterUser_SelectByUsernameAndPassword");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMasterUser);

                return dtMasterUser;

            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion SelectByUsernameAndPassword

        #region CheckByUsername
        public DataTable CheckByUsername(SqlString Username)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MasterUser_CheckByUsername");

                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, Username);

                DataTable dtMasterUser = new DataTable("PR_MasterUser_CheckByUsername");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMasterUser);

                return dtMasterUser;

            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion CheckByUsername

        #region UpdatePasswordByUserID
        public Boolean UpdatePasswordByUserID(SqlInt32 UserID, SqlString Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MasterUser_UpdatePasswordByUserID");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, Password);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;

            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }
        #endregion UpdatePasswordByUserID
    }
}