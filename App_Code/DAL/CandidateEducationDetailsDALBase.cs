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
    public abstract class CandidateEducationDetailsDALBase : DataBaseConfig
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

        public Boolean Insert(CandidateEducationDetailsENT entCandidateEducationDetails)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateEducationDetails_Insert");

                sqlDB.AddOutParameter(dbCMD, "@CandidateEduID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entCandidateEducationDetails.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@Percantage10", SqlDbType.Decimal, entCandidateEducationDetails.Percantage10);
                sqlDB.AddInParameter(dbCMD, "@Percantage12", SqlDbType.Decimal, entCandidateEducationDetails.Percantage12);
                sqlDB.AddInParameter(dbCMD, "@Graduation", SqlDbType.VarChar, entCandidateEducationDetails.Graduation);
                sqlDB.AddInParameter(dbCMD, "@InstituteGrad", SqlDbType.VarChar, entCandidateEducationDetails.InstituteGrad);
                sqlDB.AddInParameter(dbCMD, "@PercantageGrad", SqlDbType.Decimal, entCandidateEducationDetails.PercantageGrad);
                sqlDB.AddInParameter(dbCMD, "@PostGrad", SqlDbType.VarChar, entCandidateEducationDetails.PostGrad);
                sqlDB.AddInParameter(dbCMD, "@InstitutePostGrad", SqlDbType.VarChar, entCandidateEducationDetails.InstitutePostGrad);
                sqlDB.AddInParameter(dbCMD, "@PercantagePostGrad", SqlDbType.Decimal, entCandidateEducationDetails.PercantagePostGrad);
                sqlDB.AddInParameter(dbCMD, "@DrPhd", SqlDbType.VarChar, entCandidateEducationDetails.DrPhd);
                sqlDB.AddInParameter(dbCMD, "@InstituteDrPhd", SqlDbType.VarChar, entCandidateEducationDetails.InstituteDrPhd);
                sqlDB.AddInParameter(dbCMD, "@PercantageDrPhd", SqlDbType.Decimal, entCandidateEducationDetails.PercantageDrPhd);
                sqlDB.AddInParameter(dbCMD, "@Certification", SqlDbType.VarChar, entCandidateEducationDetails.Certification);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entCandidateEducationDetails.CandidateEduID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@CandidateEduID"].Value);

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

        public Boolean Update(CandidateEducationDetailsENT entCandidateEducationDetails)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateEducationDetails_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateEduID", SqlDbType.Int, entCandidateEducationDetails.CandidateEduID);
                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entCandidateEducationDetails.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@Percantage10", SqlDbType.Decimal, entCandidateEducationDetails.Percantage10);
                sqlDB.AddInParameter(dbCMD, "@Percantage12", SqlDbType.Decimal, entCandidateEducationDetails.Percantage12);
                sqlDB.AddInParameter(dbCMD, "@Graduation", SqlDbType.VarChar, entCandidateEducationDetails.Graduation);
                sqlDB.AddInParameter(dbCMD, "@InstituteGrad", SqlDbType.VarChar, entCandidateEducationDetails.InstituteGrad);
                sqlDB.AddInParameter(dbCMD, "@PercantageGrad", SqlDbType.Decimal, entCandidateEducationDetails.PercantageGrad);
                sqlDB.AddInParameter(dbCMD, "@PostGrad", SqlDbType.VarChar, entCandidateEducationDetails.PostGrad);
                sqlDB.AddInParameter(dbCMD, "@InstitutePostGrad", SqlDbType.VarChar, entCandidateEducationDetails.InstitutePostGrad);
                sqlDB.AddInParameter(dbCMD, "@PercantagePostGrad", SqlDbType.Decimal, entCandidateEducationDetails.PercantagePostGrad);
                sqlDB.AddInParameter(dbCMD, "@DrPhd", SqlDbType.VarChar, entCandidateEducationDetails.DrPhd);
                sqlDB.AddInParameter(dbCMD, "@InstituteDrPhd", SqlDbType.VarChar, entCandidateEducationDetails.InstituteDrPhd);
                sqlDB.AddInParameter(dbCMD, "@PercantageDrPhd", SqlDbType.Decimal, entCandidateEducationDetails.PercantageDrPhd);
                sqlDB.AddInParameter(dbCMD, "@Certification", SqlDbType.VarChar, entCandidateEducationDetails.Certification);

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

        public Boolean Delete(SqlInt32 CandidateEduID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateEducationDetails_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateEduID", SqlDbType.Int, CandidateEduID);

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

        public CandidateEducationDetailsENT SelectPK(SqlInt32 CandidateEduID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateEducationDetails_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateEduID", SqlDbType.Int, CandidateEduID);

                CandidateEducationDetailsENT entCandidateEducationDetails = new CandidateEducationDetailsENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["CandidateEduID"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.CandidateEduID = Convert.ToInt32(dr["CandidateEduID"]);

                        if (!dr["CandidateID"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.CandidateID = Convert.ToInt32(dr["CandidateID"]);

                        if (!dr["Percantage10"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.Percantage10 = Convert.ToDecimal(dr["Percantage10"]);

                        if (!dr["Percantage12"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.Percantage12 = Convert.ToDecimal(dr["Percantage12"]);

                        if (!dr["Graduation"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.Graduation = Convert.ToString(dr["Graduation"]);

                        if (!dr["InstituteGrad"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.InstituteGrad = Convert.ToString(dr["InstituteGrad"]);

                        if (!dr["PercantageGrad"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.PercantageGrad = Convert.ToDecimal(dr["PercantageGrad"]);

                        if (!dr["PostGrad"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.PostGrad = Convert.ToString(dr["PostGrad"]);

                        if (!dr["InstitutePostGrad"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.InstitutePostGrad = Convert.ToString(dr["InstitutePostGrad"]);

                        if (!dr["PercantagePostGrad"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.PercantagePostGrad = Convert.ToDecimal(dr["PercantagePostGrad"]);

                        if (!dr["DrPhd"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.DrPhd = Convert.ToString(dr["DrPhd"]);

                        if (!dr["InstituteDrPhd"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.Graduation = Convert.ToString(dr["InstituteDrPhd"]);

                        if (!dr["PercantageDrPhd"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.PercantageDrPhd = Convert.ToDecimal(dr["PercantageDrPhd"]);

                        if (!dr["Certification"].Equals(System.DBNull.Value))
                            entCandidateEducationDetails.Certification = Convert.ToString(dr["Certification"]);

                    }
                }
                return entCandidateEducationDetails;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateEducationDetails_SelectAll");

                DataTable dtCandidateEducationDetails = new DataTable("PR_CandidateEducationDetails_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCandidateEducationDetails);

                return dtCandidateEducationDetails;
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