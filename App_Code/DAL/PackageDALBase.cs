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
    public abstract class PackageDALBase : DataBaseConfig
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

        public Boolean Insert(PackageENT entPackage)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Package_Insert");

                sqlDB.AddOutParameter(dbCMD, "@PackageID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PackageCost", SqlDbType.NVarChar, entPackage.PackageCost);
                sqlDB.AddInParameter(dbCMD, "@NoJobs", SqlDbType.Decimal, entPackage.NoJobs);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entPackage.PackageID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@PackageID"].Value);

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

        public Boolean Update(PackageENT entPackage)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Package_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@PackageID", SqlDbType.Int, entPackage.PackageID);
                sqlDB.AddInParameter(dbCMD, "@PackageCost", SqlDbType.NVarChar, entPackage.PackageCost);
                sqlDB.AddInParameter(dbCMD, "@NoJobs", SqlDbType.Decimal, entPackage.NoJobs);

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

        public Boolean Delete(SqlInt32 PackageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Package_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@PackageID", SqlDbType.Int, PackageID);

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

        public PackageENT SelectPK(SqlInt32 PackageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Package_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@PackageID", SqlDbType.Int, PackageID);

                PackageENT entPackage = new PackageENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["PackageID"].Equals(System.DBNull.Value))
                            entPackage.PackageID = Convert.ToInt32(dr["PackageID"]);

                        if (!dr["PackageCost"].Equals(System.DBNull.Value))
                            entPackage.PackageCost = Convert.ToString(dr["PackageCost"]);

                        if (!dr["NoJobs"].Equals(System.DBNull.Value))
                            entPackage.NoJobs = Convert.ToDecimal(dr["NoJobs"]);
                    }
                }
                return entPackage;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Package_SelectAll");

                DataTable dtPackage = new DataTable("PR_Package_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtPackage);

                return dtPackage;
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