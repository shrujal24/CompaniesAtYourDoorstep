using CompaniesatyourDoorstpe.ENT;
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
    public abstract class MasterUserDALBase : DataBaseConfig
    {

        #region Properties

        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Properties

        #region Constructors
        public MasterUserDALBase()
        {

        }
        #endregion Constructors

        #region InsertOperation

        public Boolean Insert(MasterUserENT entMasterUser)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MasterUser_Insert");

                sqlDB.AddOutParameter(dbCMD, "@UserID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, entMasterUser.Username);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, entMasterUser.Password);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.VarChar, entMasterUser.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@EmailAddress", SqlDbType.VarChar, entMasterUser.EmailAddress);
                sqlDB.AddInParameter(dbCMD, "@Birthdate", SqlDbType.DateTime, entMasterUser.Birthdate);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMasterUser.UserID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@UserID"].Value);

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

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MasterUserENT entMasterUser)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MasterUser_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMasterUser.UserID);
                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, entMasterUser.Username);
                //sqlDB.AddInParameter(dbCMD, "@Password",    SqlDbType.VarChar, entMasterUser.Password);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.VarChar, entMasterUser.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@EmailAddress", SqlDbType.VarChar, entMasterUser.EmailAddress);
                sqlDB.AddInParameter(dbCMD, "@Birthdate", SqlDbType.DateTime, entMasterUser.Birthdate);

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

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MasterUser_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

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

        #endregion DeleteOperation

        #region SelectOperation

        public MasterUserENT SelectPK(SqlInt32 UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MasterUser_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

                MasterUserENT entMasterUser = new MasterUserENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entMasterUser.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["Username"].Equals(System.DBNull.Value))
                            entMasterUser.Username = Convert.ToString(dr["Username"]);

                        if (!dr["Password"].Equals(System.DBNull.Value))
                            entMasterUser.Password = Convert.ToString(dr["Password"]);

                        if (!dr["MobileNo"].Equals(System.DBNull.Value))
                            entMasterUser.MobileNo = Convert.ToString(dr["MobileNo"]);

                        if (!dr["EmailAddress"].Equals(System.DBNull.Value))
                            entMasterUser.EmailAddress = Convert.ToString(dr["EmailAddress"]);

                        if (!dr["Birthdate"].Equals(System.DBNull.Value))
                            entMasterUser.Birthdate = Convert.ToDateTime(dr["Birthdate"]);

                    }
                }
                return entMasterUser;
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
        
        public DataTable SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MasterUser_SelectAll");
                //sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);
                DataTable dtMasterUser = new DataTable("PR_MasterUser_SelectAll");

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

        #endregion SelectOperation

        #region ComboBox
        #endregion ComboBox

        #region AutoComplete
        #endregion AutoComplete
    }
}