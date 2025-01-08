using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class CategoryENTBase
    {
        #region Properties

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

        protected SqlString _CategoryName;
        public SqlString CategoryName
        {
            get
            {
                return _CategoryName;
            }
            set
            {
                _CategoryName = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CategoryENTBase()
        {
            
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String CategoryENT_String = String.Empty;

            if (!CategoryID.IsNull)
                CategoryENT_String += " CategoryID = " + CategoryID.Value.ToString();

            if (!CategoryName.IsNull)
                CategoryENT_String += "| CategoryName = " + CategoryName.Value;

            CategoryENT_String = CategoryENT_String.Trim();

            return CategoryENT_String;
        }

        #endregion ToString
    }
}