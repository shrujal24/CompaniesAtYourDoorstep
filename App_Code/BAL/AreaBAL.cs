using CompaniesatyourDoorstpe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public class AreaBAL : AreaBALBase
    {
        #region SelectComboBoxByCategoryID

        public DataTable SelectComboBoxByCategoryID(SqlInt32 CategoryID)
        {
            AreaDAL dalArea = new AreaDAL();
            return dalArea.SelectComboBoxByCategoryID(CategoryID);
        }

        #endregion SelectComboBoxByCategoryID
    }
}