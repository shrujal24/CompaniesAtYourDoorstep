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
    public abstract class CompanyDALBase : DataBaseConfig
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

        #region InsertOperation

        public Boolean Insert(CompanyENT entCompany)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Company_Insert");

                sqlDB.AddOutParameter(dbCMD, "@CompanyID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CompanyName", SqlDbType.VarChar, entCompany.CompanyName);
                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, entCompany.Username);
                sqlDB.AddInParameter(dbCMD, "@QueID", SqlDbType.Int, entCompany.QueID);
                sqlDB.AddInParameter(dbCMD, "@Ans", SqlDbType.VarChar, entCompany.Ans);
                sqlDB.AddInParameter(dbCMD, "@CompanyAddress", SqlDbType.VarChar, entCompany.CompanyAddress);
                sqlDB.AddInParameter(dbCMD, "@CompanyEmail", SqlDbType.VarChar, entCompany.CompanyEmail);
                sqlDB.AddInParameter(dbCMD, "@CompanyDetails", SqlDbType.VarChar, entCompany.CompanyDetails);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, entCompany.ContactNo);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entCompany.CompanyID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@CompanyID"].Value);

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

        public Boolean Update(CompanyENT entCompany)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Company_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@CompanyID", SqlDbType.Int, entCompany.CompanyID);
                sqlDB.AddInParameter(dbCMD, "@CompanyName", SqlDbType.VarChar, entCompany.CompanyName);
                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, entCompany.Username);
                sqlDB.AddInParameter(dbCMD, "@QueID", SqlDbType.Int, entCompany.QueID);
                sqlDB.AddInParameter(dbCMD, "@Ans", SqlDbType.VarChar, entCompany.Ans);
                sqlDB.AddInParameter(dbCMD, "@CompanyAddress", SqlDbType.VarChar, entCompany.CompanyAddress);
                sqlDB.AddInParameter(dbCMD, "@CompanyEmail", SqlDbType.VarChar, entCompany.CompanyEmail);
                sqlDB.AddInParameter(dbCMD, "@CompanyDetails", SqlDbType.VarChar, entCompany.CompanyDetails);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, entCompany.ContactNo);

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

        public Boolean Delete(SqlInt32 CompanyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Company_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@CompanyID", SqlDbType.Int, CompanyID);

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

        public CompanyENT SelectPK(SqlInt32 CompanyID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Company_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@CompanyID", SqlDbType.Int, CompanyID);

                CompanyENT entCompany = new CompanyENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["CompanyID"].Equals(System.DBNull.Value))
                            entCompany.CompanyID = Convert.ToInt32(dr["CompanyID"]);

                        if (!dr["CompanyName"].Equals(System.DBNull.Value))
                            entCompany.CompanyName = Convert.ToString(dr["CompanyName"]);

                        if (!dr["Username"].Equals(System.DBNull.Value))
                            entCompany.Username = Convert.ToString(dr["Username"]);

                        if (!dr["QueID"].Equals(System.DBNull.Value))
                            entCompany.QueID = Convert.ToInt32(dr["QueID"]);

                        if (!dr["Ans"].Equals(System.DBNull.Value))
                            entCompany.Ans = Convert.ToString(dr["Ans"]);

                        if (!dr["CompanyAddress"].Equals(System.DBNull.Value))
                            entCompany.CompanyAddress = Convert.ToString(dr["CompanyAddress"]);

                        if (!dr["CompanyEmail"].Equals(System.DBNull.Value))
                            entCompany.CompanyEmail = Convert.ToString(dr["CompanyEmail"]);

                        if (!dr["CompanyDetails"].Equals(System.DBNull.Value))
                            entCompany.CompanyDetails = Convert.ToString(dr["CompanyDetails"]);

                        if (!dr["ContactNo"].Equals(System.DBNull.Value))
                            entCompany.ContactNo = Convert.ToString(dr["ContactNo"]);

                    }
                }
                return entCompany;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Company_SelectAll");

                DataTable dtCompany = new DataTable("PR_Company_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCompany);

                return dtCompany;
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