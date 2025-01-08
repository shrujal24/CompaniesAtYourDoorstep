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
    public abstract class CandidateProfessionalDetailsDALBase : DataBaseConfig
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

        public Boolean Insert(CandidateProfessionalDetailsENT entCandidateProfessionalDetails)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateProfessionalDetails_Insert");

                sqlDB.AddOutParameter(dbCMD, "@CandidateProfID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entCandidateProfessionalDetails.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@AreaID", SqlDbType.Int, entCandidateProfessionalDetails.AreaID);
                sqlDB.AddInParameter(dbCMD, "@ExpYrs", SqlDbType.Int, entCandidateProfessionalDetails.ExpYrs);
                sqlDB.AddInParameter(dbCMD, "@ExpMns", SqlDbType.Int, entCandidateProfessionalDetails.ExpMns);
                sqlDB.AddInParameter(dbCMD, "@Salary", SqlDbType.VarChar, entCandidateProfessionalDetails.Salary);
                sqlDB.AddInParameter(dbCMD, "@Industry", SqlDbType.VarChar, entCandidateProfessionalDetails.Industry);
                sqlDB.AddInParameter(dbCMD, "@IndRole", SqlDbType.VarChar, entCandidateProfessionalDetails.IndRole);
                sqlDB.AddInParameter(dbCMD, "@Skills", SqlDbType.VarChar, entCandidateProfessionalDetails.Skills);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entCandidateProfessionalDetails.CandidateProfID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@CandidateProfID"].Value);

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

        public Boolean Update(CandidateProfessionalDetailsENT entCandidateProfessionalDetails)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateProfessionalDetails_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateProfID", SqlDbType.Int, entCandidateProfessionalDetails.CandidateProfID);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entCandidateProfessionalDetails.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@AreaID", SqlDbType.Int, entCandidateProfessionalDetails.AreaID);
                sqlDB.AddInParameter(dbCMD, "@ExpYrs", SqlDbType.Int, entCandidateProfessionalDetails.ExpYrs);
                sqlDB.AddInParameter(dbCMD, "@ExpMns", SqlDbType.Int, entCandidateProfessionalDetails.ExpMns);
                sqlDB.AddInParameter(dbCMD, "@Salary", SqlDbType.VarChar, entCandidateProfessionalDetails.Salary);
                sqlDB.AddInParameter(dbCMD, "@Industry", SqlDbType.VarChar, entCandidateProfessionalDetails.Industry);
                sqlDB.AddInParameter(dbCMD, "@IndRole", SqlDbType.VarChar, entCandidateProfessionalDetails.IndRole);
                sqlDB.AddInParameter(dbCMD, "@Skills", SqlDbType.VarChar, entCandidateProfessionalDetails.Skills);

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

        public Boolean Delete(SqlInt32 CandidateProfID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateProfessionalDetails_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateProfID", SqlDbType.Int, CandidateProfID);

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

        public CandidateProfessionalDetailsENT SelectPK(SqlInt32 CandidateProfID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateProfessionalDetails_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateProfID", SqlDbType.Int, CandidateProfID);

                CandidateProfessionalDetailsENT entCandidateProfessionalDetails = new CandidateProfessionalDetailsENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["CandidateProfID"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.CandidateProfID = Convert.ToInt32(dr["CandidateProfID"]);

                        if (!dr["CandidateID"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.CandidateID = Convert.ToInt32(dr["CandidateID"]);

                        if (!dr["AreaID"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.AreaID = Convert.ToInt32(dr["AreaID"]);

                        if (!dr["ExpYrs"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.ExpYrs = Convert.ToInt32(dr["ExpYrs"]);

                        if (!dr["ExpMns"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.ExpMns = Convert.ToInt32(dr["ExpMns"]);

                        if (!dr["Salary"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.Salary = Convert.ToString(dr["Salary"]);

                        if (!dr["Industry"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.Industry = Convert.ToString(dr["Industry"]);

                        if (!dr["IndRole"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.IndRole = Convert.ToString(dr["IndRole"]);

                        if (!dr["Skills"].Equals(System.DBNull.Value))
                            entCandidateProfessionalDetails.Skills = Convert.ToString(dr["Skills"]);

                    }
                }
                return entCandidateProfessionalDetails;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateProfessionalDetails_SelectAll");

                DataTable dtCandidateProfessionalDetails = new DataTable("PR_CandidateProfessionalDetails_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCandidateProfessionalDetails);

                return dtCandidateProfessionalDetails;
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