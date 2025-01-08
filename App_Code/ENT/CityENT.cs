using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public class CityENT : CityENTBase
    {
        #region Properties

        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }

        #endregion Properties

        #region ToString

        public override String ToString()
        {
            String CityENT_String = String.Empty;

            if (!CountryID.IsNull)
                CityENT_String += "| CountryID = " + CountryID.Value.ToString();

            CityENT_String = CityENT_String.Trim();

            return CityENT_String;
        }

        #endregion ToString
    }
}