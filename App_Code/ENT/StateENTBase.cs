using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class StateENTBase
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

        protected SqlString _StateName;
        public SqlString StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }

        #endregion Properties

        #region Constructor

        public StateENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String StateENT_String = String.Empty;

            if (!StateID.IsNull)
                StateENT_String += " StateID = " + StateID.Value.ToString();

            if (!CountryID.IsNull)
                StateENT_String += "| CountryID = " + CountryID.Value;

            if (!StateName.IsNull)
                StateENT_String += "| StateName = " + StateName.Value;

            StateENT_String = StateENT_String.Trim();

            return StateENT_String;
        }

        #endregion ToString
    }
}