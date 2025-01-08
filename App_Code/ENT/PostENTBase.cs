using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class PostENTBase
    {
        #region Properties

        protected SqlInt32 _PostID;
        public SqlInt32 PostID
        {
            get
            {
                return _PostID;
            }
            set
            {
                _PostID = value;
            }
        }

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

        protected SqlString _PostName;
        public SqlString PostName
        {
            get
            {
                return _PostName;
            }
            set
            {
                _PostName = value;
            }
        }

        #endregion Properties

        #region Constructor

        public PostENTBase()
        {
            
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String PostENT_String = String.Empty;

            if (!PostID.IsNull)
                PostENT_String += " PostID = " + PostID.Value.ToString();

            if (!AreaID.IsNull)
                PostENT_String += "| AreaID = " + AreaID.Value;

            if (!PostName.IsNull)
                PostENT_String += "| PostName = " + PostName.Value;

            PostENT_String = PostENT_String.Trim();

            return PostENT_String;
        }

        #endregion ToString
    }
}