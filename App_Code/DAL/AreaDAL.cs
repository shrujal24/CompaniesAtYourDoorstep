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
    public class AreaDAL : AreaDALBase
    {
        #region ComboBox

        public DataTable SelectComboBoxByCategoryID(SqlInt32 CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Area_SelectDropDownListByCategoryID");

                sqlDB.AddInParameter(dbCMD, "@CategoryID", SqlDbType.Int, CategoryID);
                DataTable dtArea = new DataTable("PR_Area_SelectDropDownListByCategoryID");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtArea);

                return dtArea;
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

        #endregion ComboBox
    }
}