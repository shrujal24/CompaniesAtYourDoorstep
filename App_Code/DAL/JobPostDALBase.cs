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
    public abstract class JobPostDALBase : DataBaseConfig
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

        public Boolean Insert(JobPostENT entJobPost)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobPost_Insert");

                sqlDB.AddOutParameter(dbCMD, "@JobpostID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CompanyID", SqlDbType.Int, entJobPost.CompanyID);
                sqlDB.AddInParameter(dbCMD, "@JobTitle", SqlDbType.VarChar, entJobPost.JobTitle);
                sqlDB.AddInParameter(dbCMD, "@AreaID", SqlDbType.Int, entJobPost.AreaID);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entJobPost.CityID);
                sqlDB.AddInParameter(dbCMD, "@Post", SqlDbType.VarChar, entJobPost.Post);
                sqlDB.AddInParameter(dbCMD, "@NoVacancy", SqlDbType.Decimal, entJobPost.NoVacancy);
                sqlDB.AddInParameter(dbCMD, "@StartDate", SqlDbType.DateTime, entJobPost.StartDate);
                sqlDB.AddInParameter(dbCMD, "@EndDate", SqlDbType.DateTime, entJobPost.EndDate);
                sqlDB.AddInParameter(dbCMD, "@ExpYrs", SqlDbType.VarChar, entJobPost.ExpYrs);
                sqlDB.AddInParameter(dbCMD, "@SkillsReq", SqlDbType.VarChar, entJobPost.SkillsReq);
                sqlDB.AddInParameter(dbCMD, "@EduReq", SqlDbType.VarChar, entJobPost.EduReq);
                sqlDB.AddInParameter(dbCMD, "@BasicReq", SqlDbType.VarChar, entJobPost.BasicReq);
                sqlDB.AddInParameter(dbCMD, "@SalaryMin", SqlDbType.Decimal, entJobPost.SalaryMin);
                sqlDB.AddInParameter(dbCMD, "@SalaryMax", SqlDbType.Decimal, entJobPost.SalaryMax);


                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entJobPost.JobpostID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@JobpostID"].Value);

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

        public Boolean Update(JobPostENT entJobPost)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobPost_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, entJobPost.JobpostID);
                sqlDB.AddInParameter(dbCMD, "@CompanyID", SqlDbType.Int, entJobPost.CompanyID);
                sqlDB.AddInParameter(dbCMD, "@JobTitle", SqlDbType.VarChar, entJobPost.JobTitle);
                sqlDB.AddInParameter(dbCMD, "@AreaID", SqlDbType.Int, entJobPost.AreaID);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entJobPost.CityID);
                sqlDB.AddInParameter(dbCMD, "@Post", SqlDbType.VarChar, entJobPost.Post);
                sqlDB.AddInParameter(dbCMD, "@NoVacancy", SqlDbType.Decimal, entJobPost.NoVacancy);
                sqlDB.AddInParameter(dbCMD, "@StartDate", SqlDbType.DateTime, entJobPost.StartDate);
                sqlDB.AddInParameter(dbCMD, "@EndDate", SqlDbType.DateTime, entJobPost.EndDate);
                sqlDB.AddInParameter(dbCMD, "@ExpYrs", SqlDbType.VarChar, entJobPost.ExpYrs);
                sqlDB.AddInParameter(dbCMD, "@SkillsReq", SqlDbType.VarChar, entJobPost.SkillsReq);
                sqlDB.AddInParameter(dbCMD, "@EduReq", SqlDbType.VarChar, entJobPost.EduReq);
                sqlDB.AddInParameter(dbCMD, "@BasicReq", SqlDbType.VarChar, entJobPost.BasicReq);
                sqlDB.AddInParameter(dbCMD, "@SalaryMin", SqlDbType.Decimal, entJobPost.SalaryMin);
                sqlDB.AddInParameter(dbCMD, "@SalaryMax", SqlDbType.Decimal, entJobPost.SalaryMax);

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

        public Boolean Delete(SqlInt32 JobpostID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobPost_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, JobpostID);

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

        public JobPostENT SelectPK(SqlInt32 JobpostID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobPost_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@JobpostID", SqlDbType.Int, JobpostID);

                JobPostENT entJobPost = new JobPostENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["JobpostID"].Equals(System.DBNull.Value))
                            entJobPost.JobpostID = Convert.ToInt32(dr["JobpostID"]);

                        if (!dr["CompanyID"].Equals(System.DBNull.Value))
                            entJobPost.CompanyID = Convert.ToInt32(dr["CompanyID"]);

                        if (!dr["JobTitle"].Equals(System.DBNull.Value))
                            entJobPost.JobTitle = Convert.ToString(dr["JobTitle"]);

                        if (!dr["AreaID"].Equals(System.DBNull.Value))
                            entJobPost.AreaID = Convert.ToInt32(dr["AreaID"]);

                        if (!dr["CityID"].Equals(System.DBNull.Value))
                            entJobPost.CityID = Convert.ToInt32(dr["CityID"]);

                        if (!dr["Post"].Equals(System.DBNull.Value))
                            entJobPost.Post = Convert.ToString(dr["Post"]);

                        if (!dr["NoVacancy"].Equals(System.DBNull.Value))
                            entJobPost.NoVacancy = Convert.ToDecimal(dr["NoVacancy"]);

                        if (!dr["ExpYrs"].Equals(System.DBNull.Value))
                            entJobPost.ExpYrs = Convert.ToString(dr["ExpYrs"]);

                        if (!dr["StartDate"].Equals(System.DBNull.Value))
                            entJobPost.StartDate = Convert.ToDateTime(dr["StartDate"]);

                        if (!dr["EndDate"].Equals(System.DBNull.Value))
                            entJobPost.StartDate = Convert.ToDateTime(dr["EndDate"]);

                        if (!dr["SkillsReq"].Equals(System.DBNull.Value))
                            entJobPost.SkillsReq = Convert.ToString(dr["SkillsReq"]);

                        if (!dr["EduReq"].Equals(System.DBNull.Value))
                            entJobPost.EduReq = Convert.ToString(dr["EduReq"]);

                        if (!dr["BasicReq"].Equals(System.DBNull.Value))
                            entJobPost.BasicReq = Convert.ToString(dr["BasicReq"]);

                        if (!dr["SalaryMin"].Equals(System.DBNull.Value))
                            entJobPost.SalaryMin = Convert.ToDecimal(dr["SalaryMin"]);

                        if (!dr["SalaryMax"].Equals(System.DBNull.Value))
                            entJobPost.SalaryMax = Convert.ToDecimal(dr["SalaryMax"]);


                    }
                }
                return entJobPost;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_JobPost_SelectAll");

                DataTable dtJobPost = new DataTable("PR_JobPost_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtJobPost);

                return dtJobPost;
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