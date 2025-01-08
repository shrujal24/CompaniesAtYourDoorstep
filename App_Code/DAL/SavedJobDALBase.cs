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
    public abstract class SavedJobDALBase : DataBaseConfig
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

        public Boolean Insert(SavedJobENT entSavedJob)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedJob_Insert");

                sqlDB.AddOutParameter(dbCMD, "@SavedJobID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entSavedJob.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entSavedJob.JobpostID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entSavedJob.SavedJobID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@SavedJobID"].Value);

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

        public Boolean Update(SavedJobENT entSavedJob)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedJob_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@SavedJobID", SqlDbType.Int, entSavedJob.SavedJobID);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entSavedJob.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entSavedJob.JobpostID);

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

        public Boolean Delete(SqlInt32 SavedJobID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedJob_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@SavedJobID", SqlDbType.Int, SavedJobID);

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

        public SavedJobENT SelectPK(SqlInt32 SavedJobID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedJob_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@SavedJobID", SqlDbType.Int, SavedJobID);

                SavedJobENT entSavedJob = new SavedJobENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["SavedJobID"].Equals(System.DBNull.Value))
                            entSavedJob.SavedJobID = Convert.ToInt32(dr["SavedJobID"]);

                        if (!dr["CandidateID"].Equals(System.DBNull.Value))
                            entSavedJob.CandidateID = Convert.ToInt32(dr["CandidateID"]);

                        if (!dr["JobpostID"].Equals(System.DBNull.Value))
                            entSavedJob.JobpostID = Convert.ToInt32(dr["JobpostID"]);
                    }
                }
                return entSavedJob;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedJob_SelectAll");

                DataTable dtSavedJob = new DataTable("PR_SavedJob_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSavedJob);

                return dtSavedJob;
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