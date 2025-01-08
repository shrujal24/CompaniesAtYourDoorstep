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
    public abstract class ResumeDALBase : DataBaseConfig
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

        public Boolean Insert(ResumeENT entResume)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Resume_Insert");

                sqlDB.AddOutParameter(dbCMD, "@ResumeID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entResume.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@ResumeHeadline", SqlDbType.VarChar, entResume.ResumeHeadline);
                sqlDB.AddInParameter(dbCMD, "@Path", SqlDbType.VarChar, entResume.Path);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entResume.ResumeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ResumeID"].Value);

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

        public Boolean Update(ResumeENT entResume)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Resume_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@ResumeID", SqlDbType.Int, entResume.ResumeID);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entResume.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@ResumeHeadline", SqlDbType.VarChar, entResume.ResumeHeadline);
                sqlDB.AddInParameter(dbCMD, "@Path", SqlDbType.VarChar, entResume.Path);

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

        public Boolean Delete(SqlInt32 ResumeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Resume_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@ResumeID", SqlDbType.Int, ResumeID);

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

        public ResumeENT SelectPK(SqlInt32 ResumeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Resume_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@ResumeID", SqlDbType.Int, ResumeID);

                ResumeENT entResume = new ResumeENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["ResumeID"].Equals(System.DBNull.Value))
                            entResume.ResumeID = Convert.ToInt32(dr["ResumeID"]);

                        if (!dr["CandidateID"].Equals(System.DBNull.Value))
                            entResume.CandidateID = Convert.ToInt32(dr["CandidateID"]);

                        if (!dr["ResumeHeadline"].Equals(System.DBNull.Value))
                            entResume.ResumeHeadline = Convert.ToString(dr["ResumeHeadline"]);

                        if (!dr["Path"].Equals(System.DBNull.Value))
                            entResume.Path = Convert.ToString(dr["Path"]);

                    }
                }
                return entResume;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Resume_SelectAll");

                DataTable dtResume = new DataTable("PR_Resume_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtResume);

                return dtResume;
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
