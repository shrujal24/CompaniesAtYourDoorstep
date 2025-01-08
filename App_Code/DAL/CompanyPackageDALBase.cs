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
    public abstract class CompanyPackageDALBase : DataBaseConfig
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

        public Boolean Insert(CompanyPackageENT entCompanyPackage)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CompanyPackage_Insert");

                sqlDB.AddOutParameter(dbCMD, "@CompPackageID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CompanyID", SqlDbType.Int, entCompanyPackage.CompanyID);
                sqlDB.AddInParameter(dbCMD, "@PackageID", SqlDbType.Int, entCompanyPackage.PackageID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entCompanyPackage.CompPackageID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@CompPackageID"].Value);

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

        public Boolean Update(CompanyPackageENT entCompanyPackage)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CompanyPackage_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@CompPackageID", SqlDbType.Int, entCompanyPackage.CompPackageID);
                sqlDB.AddInParameter(dbCMD, "@CompanyID", SqlDbType.Int, entCompanyPackage.CompanyID);
                sqlDB.AddInParameter(dbCMD, "@PackageID", SqlDbType.Int, entCompanyPackage.PackageID);

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

        public Boolean Delete(SqlInt32 CompPackageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CompanyPackage_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@CompPackageID", SqlDbType.Int, CompPackageID);

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

        public CompanyPackageENT SelectPK(SqlInt32 CompPackageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CompanyPackage_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@CompPackageID", SqlDbType.Int, CompPackageID);

                CompanyPackageENT entCompanyPackage = new CompanyPackageENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["CompPackageID"].Equals(System.DBNull.Value))
                            entCompanyPackage.CompPackageID = Convert.ToInt32(dr["CompPackageID"]);

                        if (!dr["CompanyID"].Equals(System.DBNull.Value))
                            entCompanyPackage.CompanyID = Convert.ToInt32(dr["CompanyID"]);

                        if (!dr["PackageID"].Equals(System.DBNull.Value))
                            entCompanyPackage.PackageID = Convert.ToInt32(dr["PackageID"]);
                    }
                }
                return entCompanyPackage;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CompanyPackage_SelectAll");

                DataTable dtCompanyPackage = new DataTable("PR_CompanyPackage_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCompanyPackage);

                return dtCompanyPackage;
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