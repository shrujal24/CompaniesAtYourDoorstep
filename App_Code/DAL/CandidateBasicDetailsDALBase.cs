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
    public abstract class CandidateBasicDetailsDALBase : DataBaseConfig
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

        public Boolean Insert(CandidateBasicDetailsENT entCandidateBasicDetails)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateBasicDetails_Insert");

                sqlDB.AddOutParameter(dbCMD, "@CandidateID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, entCandidateBasicDetails.Username);
                sqlDB.AddInParameter(dbCMD, "@QueID", SqlDbType.Int, entCandidateBasicDetails.QueID);
                sqlDB.AddInParameter(dbCMD, "@Ans", SqlDbType.VarChar, entCandidateBasicDetails.Ans);
                sqlDB.AddInParameter(dbCMD, "@ProfileDate", SqlDbType.DateTime, entCandidateBasicDetails.ProfileDate);
                sqlDB.AddInParameter(dbCMD, "@FirstName", SqlDbType.VarChar, entCandidateBasicDetails.FirstName);
                sqlDB.AddInParameter(dbCMD, "@MiddleName", SqlDbType.VarChar, entCandidateBasicDetails.MiddleName);
                sqlDB.AddInParameter(dbCMD, "@LastName", SqlDbType.VarChar, entCandidateBasicDetails.LastName);
                sqlDB.AddInParameter(dbCMD, "@CandidateAddress", SqlDbType.VarChar, entCandidateBasicDetails.CandidateAddress);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entCandidateBasicDetails.CityID);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.VarChar, entCandidateBasicDetails.Gender);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entCandidateBasicDetails.DOB);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, entCandidateBasicDetails.ContactNo);
                sqlDB.AddInParameter(dbCMD, "@EmailAddress", SqlDbType.VarChar, entCandidateBasicDetails.EmailAddress);
                sqlDB.AddInParameter(dbCMD, "@ImageUrl", SqlDbType.VarChar, entCandidateBasicDetails.ImageUrl);


                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entCandidateBasicDetails.CandidateID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@CandidateID"].Value);

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

        public Boolean Update(CandidateBasicDetailsENT entCandidateBasicDetails)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateBasicDetails_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, entCandidateBasicDetails.CandidateID);
                sqlDB.AddInParameter(dbCMD, "@Username", SqlDbType.VarChar, entCandidateBasicDetails.Username);
                sqlDB.AddInParameter(dbCMD, "@QueID", SqlDbType.Int, entCandidateBasicDetails.QueID);
                sqlDB.AddInParameter(dbCMD, "@Ans", SqlDbType.VarChar, entCandidateBasicDetails.Ans);
                sqlDB.AddInParameter(dbCMD, "@ProfileDate", SqlDbType.DateTime, entCandidateBasicDetails.ProfileDate);
                sqlDB.AddInParameter(dbCMD, "@FirstName", SqlDbType.VarChar, entCandidateBasicDetails.FirstName);
                sqlDB.AddInParameter(dbCMD, "@MiddleName", SqlDbType.VarChar, entCandidateBasicDetails.MiddleName);
                sqlDB.AddInParameter(dbCMD, "@LastName", SqlDbType.VarChar, entCandidateBasicDetails.LastName);
                sqlDB.AddInParameter(dbCMD, "@CandidateAddress", SqlDbType.VarChar, entCandidateBasicDetails.CandidateAddress);
                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entCandidateBasicDetails.CityID);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.VarChar, entCandidateBasicDetails.Gender);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entCandidateBasicDetails.DOB);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, entCandidateBasicDetails.ContactNo);
                sqlDB.AddInParameter(dbCMD, "@EmailAddress", SqlDbType.VarChar, entCandidateBasicDetails.EmailAddress);
                sqlDB.AddInParameter(dbCMD, "@ImageUrl", SqlDbType.VarChar, entCandidateBasicDetails.ImageUrl);

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

        public Boolean Delete(SqlInt32 CandidateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateBasicDetails_DeleteByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, CandidateID);

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

        public CandidateBasicDetailsENT SelectPK(SqlInt32 CandidateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateBasicDetails_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@CandidateID", SqlDbType.Int, CandidateID);

                CandidateBasicDetailsENT entCandidateBasicDetails = new CandidateBasicDetailsENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["CandidateID"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.CandidateID = Convert.ToInt32(dr["CandidateID"]);

                        if (!dr["Username"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.Username = Convert.ToString(dr["Username"]);

                        if (!dr["QueID"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.QueID = Convert.ToInt32(dr["QueID"]);

                        if (!dr["Ans"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.Ans = Convert.ToString(dr["Ans"]);

                        if (!dr["ProfileDate"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.ProfileDate = Convert.ToDateTime(dr["ProfileDate"]);

                        if (!dr["FirstName"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.FirstName = Convert.ToString(dr["FirstName"]);

                        if (!dr["MiddleName"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.MiddleName = Convert.ToString(dr["MiddleName"]);

                        if (!dr["LastName"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.LastName = Convert.ToString(dr["LastName"]);

                        if (!dr["CandidateAddress"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.CandidateAddress = Convert.ToString(dr["CandidateAddress"]);

                        if (!dr["CityID"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.CityID = Convert.ToInt32(dr["CityID"]);

                        if (!dr["StateID"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.StateID = Convert.ToInt32(dr["StateID"]);

                        if (!dr["CountryID"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.CountryID = Convert.ToInt32(dr["CountryID"]);

                        if (!dr["Gender"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.Gender = Convert.ToString(dr["Gender"]);

                        if (!dr["DOB"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.DOB = Convert.ToDateTime(dr["DOB"]);

                        if (!dr["ContactNo"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.ContactNo = Convert.ToString(dr["ContactNo"]);

                        if (!dr["EmailAddress"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.EmailAddress = Convert.ToString(dr["EmailAddress"]);

                        if (!dr["ImageUrl"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.ImageUrl = Convert.ToString(dr["ImageUrl"]);

                        if (!dr["Password"].Equals(System.DBNull.Value))
                            entCandidateBasicDetails.Password = Convert.ToString(dr["Password"]);


                    }
                }
                return entCandidateBasicDetails;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CandidateBasicDetails_SelectAll");

                DataTable dtCandidateBasicDetails = new DataTable("PR_CandidateBasicDetails_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCandidateBasicDetails);

                return dtCandidateBasicDetails;
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