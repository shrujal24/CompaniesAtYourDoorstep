using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class CountryENTBase
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

        protected SqlString _CountryName;
        public SqlString CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                _CountryName = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CountryENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String CountryENT_String = String.Empty;

            if (!CountryID.IsNull)
                CountryENT_String += " CountryID = " + CountryID.Value.ToString();

            if (!CountryName.IsNull)
                CountryENT_String += "| CountryName = " + CountryName.Value;

            CountryENT_String = CountryENT_String.Trim();

            return CountryENT_String;
        }

        #endregion ToString
    }
}