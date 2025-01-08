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
    public abstract class SavedCandidatesDALBase : DataBaseConfig
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

        public Boolean Insert(SavedCandidatesENT entSavedCandidates)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedCandidates_Insert");

                sqlDB.AddOutParameter(dbCMD, "@SavedID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entSavedCandidates.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entSavedCandidates.JobpostID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entSavedCandidates.SavedID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@SavedID"].Value);

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

        public Boolean Update(SavedCandidatesENT entSavedCandidates)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedCandidates_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@SavedID", SqlDbType.Int, entSavedCandidates.SavedID);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entSavedCandidates.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entSavedCandidates.JobpostID);

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

        public Boolean Delete(SqlInt32 SavedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedCandidates_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@SavedID", SqlDbType.Int, SavedID);

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

        public SavedCandidatesENT SelectPK(SqlInt32 SavedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedCandidates_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@SavedID", SqlDbType.Int, SavedID);

                SavedCandidatesENT entSavedCandidates = new SavedCandidatesENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["SavedID"].Equals(System.DBNull.Value))
                            entSavedCandidates.SavedID = Convert.ToInt32(dr["SavedID"]);

                        if (!dr["CandidateID"].Equals(System.DBNull.Value))
                            entSavedCandidates.CandidateID = Convert.ToInt32(dr["CandidateID"]);

                        if (!dr["JobpostID"].Equals(System.DBNull.Value))
                            entSavedCandidates.JobpostID = Convert.ToInt32(dr["JobpostID"]);
                    }
                }
                return entSavedCandidates;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SavedCandidates_SelectAll");

                DataTable dtSavedCandidates = new DataTable("PR_SavedCandidates_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSavedCandidates);

                return dtSavedCandidates;
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