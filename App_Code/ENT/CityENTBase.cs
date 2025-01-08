using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class CityENTBase
    {
        #region Properties


        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }

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

        protected SqlString _CityName;
        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CityENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String CityENT_String = String.Empty;

            if (!CityID.IsNull)
                CityENT_String += " CityID = " + CityID.Value.ToString();

            if (!StateID.IsNull)
                CityENT_String += "| StateID = " + StateID.Value.ToString();

            if (!CityName.IsNull)
                CityENT_String += "| CityName = " + CityName.Value;

            CityENT_String = CityENT_String.Trim();

            return CityENT_String;
        }

        #endregion ToString
    }
}