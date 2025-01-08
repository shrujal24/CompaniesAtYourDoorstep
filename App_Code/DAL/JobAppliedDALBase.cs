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
    public abstract class JobAppliedDALBase : DataBaseConfig
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

        public Boolean Insert(JobAppliedENT entJobApplied)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobApplied_Insert");

                sqlDB.AddOutParameter(dbCMD, "@AppliedID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entJobApplied.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entJobApplied.JobpostID);
                sqlDB.AddInParameter(dbCMD, "@AppliedDate", SqlDbType.DateTime, entJobApplied.AppliedDate);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entJobApplied.AppliedID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@AppliedID"].Value);

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

        public Boolean Update(JobAppliedENT entJobApplied)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobApplied_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@AppliedID", SqlDbType.Int, entJobApplied.AppliedID);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entJobApplied.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entJobApplied.JobpostID);
                sqlDB.AddInParameter(dbCMD, "@AppliedDate", SqlDbType.DateTime, entJobApplied.AppliedDate);

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

        public Boolean Delete(SqlInt32 AppliedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobApplied_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@AppliedID", SqlDbType.Int, AppliedID);

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

        public JobAppliedENT SelectPK(SqlInt32 AppliedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobApplied_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@AppliedID", SqlDbType.Int, AppliedID);

                JobAppliedENT entJobApplied = new JobAppliedENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["AppliedID"].Equals(System.DBNull.Value))
                            entJobApplied.AppliedID = Convert.ToInt32(dr["AppliedID"]);

                        if (!dr["CandidateID"].Equals(System.DBNull.Value))
                            entJobApplied.CandidateID = Convert.ToInt32(dr["CandidateID"]);

                        if (!dr["JobpostID"].Equals(System.DBNull.Value))
                            entJobApplied.JobpostID = Convert.ToInt32(dr["JobpostID"]);

                        if (!dr["AppliedDate"].Equals(System.DBNull.Value))
                            entJobApplied.AppliedDate = Convert.ToDateTime(dr["AppliedDate"]);

                    }
                }
                return entJobApplied;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobApplied_SelectAll");

                DataTable dtJobApplied = new DataTable("PR_JobApplied_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtJobApplied);

                return dtJobApplied;
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