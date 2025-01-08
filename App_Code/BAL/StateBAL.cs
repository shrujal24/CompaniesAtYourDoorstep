using CompaniesatyourDoorstpe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public class StateBAL : StateBALBase
    {
        #region SelectComboBoxByCountryID

        public DataTable SelectComboBoxByCountryID(SqlInt32 CountryID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectComboBoxByCountryID(CountryID);
        }

        #endregion SelectComboBoxByCountryID

    }
}