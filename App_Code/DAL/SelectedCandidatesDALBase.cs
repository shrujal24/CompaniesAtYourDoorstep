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
    public abstract class SelectedCandidatesDALBase : DataBaseConfig
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

        public Boolean Insert(SelectedCandidatesENT entSelectedCandidates)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectedCandidates_Insert");

                sqlDB.AddOutParameter(dbCMD, "@SelectedID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entSelectedCandidates.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entSelectedCandidates.JobpostID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entSelectedCandidates.SelectedID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@SelectedID"].Value);

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

        public Boolean Update(SelectedCandidatesENT entSelectedCandidates)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectedCandidates_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@SelectedID", SqlDbType.Int, entSelectedCandidates.SelectedID);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entSelectedCandidates.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entSelectedCandidates.JobpostID);

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

        public Boolean Delete(SqlInt32 SelectedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectedCandidates_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@SelectedID", SqlDbType.Int, SelectedID);

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

        public SelectedCandidatesENT SelectPK(SqlInt32 SelectedID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectedCandidates_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@SelectedID", SqlDbType.Int, SelectedID);

                SelectedCandidatesENT entSelectedCandidates = new SelectedCandidatesENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["SelectedID"].Equals(System.DBNull.Value))
                            entSelectedCandidates.SelectedID = Convert.ToInt32(dr["SelectedID"]);

                        if (!dr["CandidateID"].Equals(System.DBNull.Value))
                            entSelectedCandidates.CandidateID = Convert.ToInt32(dr["CandidateID"]);

                        if (!dr["JobpostID"].Equals(System.DBNull.Value))
                            entSelectedCandidates.JobpostID = Convert.ToInt32(dr["JobpostID"]);
                    }
                }
                return entSelectedCandidates;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SelectedCandidates_SelectAll");

                DataTable dtSelectedCandidates = new DataTable("PR_SelectedCandidates_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSelectedCandidates);

                return dtSelectedCandidates;
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