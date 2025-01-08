using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class AreaENTBase
    {
        #region Properties

        protected SqlInt32 _AreaID;
        public SqlInt32 AreaID
        {
            get
            {
                return _AreaID;
            }
            set
            {
                _AreaID = value;
            }
        }

        protected SqlInt32 _CategoryID;
        public SqlInt32 CategoryID
        {
            get
            {
                return _CategoryID;
            }
            set
            {
                _CategoryID = value;
            }
        }

        protected SqlString _AreaName;
        public SqlString AreaName
        {
            get
            {
                return _AreaName;
            }
            set
            {
                _AreaName = value;
            }
        }

        #endregion Properties

        #region Constructor

        public AreaENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String AreaENT_String = String.Empty;

            if (!AreaID.IsNull)
                AreaENT_String += " AreaID = " + AreaID.Value.ToString();

            if (!CategoryID.IsNull)
                AreaENT_String += "| CategoryID = " + CategoryID.Value;

            if (!AreaName.IsNull)
                AreaENT_String += "| AreaName = " + AreaName.Value;

            AreaENT_String = AreaENT_String.Trim();

            return AreaENT_String;
        }

        #endregion ToString
    }
}