using CompaniesatyourDoorstpe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public class CityBAL : CityBALBase
    {
        #region SelectComboBoxByStateID

        public DataTable SelectComboBoxByStateID(SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectComboBoxByStateID(StateID);
        }

        #endregion SelectComboBoxByStateID
    }
}