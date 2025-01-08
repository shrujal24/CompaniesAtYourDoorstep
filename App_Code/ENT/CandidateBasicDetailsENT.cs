using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public class CandidateBasicDetailsENT : CandidateBasicDetailsENTBase
    {
        #region Properties

        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }

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

        protected SqlString _Password;
        public SqlString Password 
        { 
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }


        #endregion Properties

        #region ToString

        public override String ToString()
        {
            String CityENT_String = String.Empty;
            if (!StateID.IsNull)
                CityENT_String += "| StateID = " + StateID.Value.ToString();

            if (!CountryID.IsNull)
                CityENT_String += "| CountryID = " + CountryID.Value.ToString();

            CityENT_String = CityENT_String.Trim();

            return CityENT_String;
        }

        #endregion ToString

    }
}