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
    public class LoginDAL : LoginDALBase
    {
        #region SelectByUsernameAndPasswordAndRole
        public DataTable SelectByUsernameAndPasswordAndRole(SqlString Username, SqlString Password, SqlString Role)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Login_SelectByUsernameAndPasswordAndRole");

                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, Username);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, Password);
                sqlDB.AddInParameter(dbCMD, "@Role", SqlDbType.VarChar, Role);


                DataTable dtLogin = new DataTable("PR_Login_SelectByUsernameAndPasswordAndRole");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtLogin);

                return dtLogin;

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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Login_CheckByUsername");

                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, Username);

                DataTable dtLogin = new DataTable("PR_Login_CheckByUsername");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtLogin);

                return dtLogin;

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

        #region UpdatePasswordByUsername
        public Boolean UpdatePasswordByUsername(SqlInt32 Username, SqlString Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Login_UpdatePasswordByUsername");

                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.Int, Username);
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
        #endregion UpdatePasswordByUsername
    }
}