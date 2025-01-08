using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class SavedJobENTBase
    {
        #region Properties

        protected SqlInt32 _SavedJobID;
        public SqlInt32 SavedJobID
        {
            get
            {
                return _SavedJobID;
            }
            set
            {
                _SavedJobID = value;
            }
        }

        protected SqlInt32 _CandidateID;
        public SqlInt32 CandidateID
        {
            get
            {
                return _CandidateID;
            }
            set
            {
                _CandidateID = value;
            }
        }

        protected SqlInt32 _JobpostID;
        public SqlInt32 JobpostID
        {
            get
            {
                return _JobpostID;
            }
            set
            {
                _JobpostID = value;
            }
        }


        #endregion Properties

        #region Constructor
        public SavedJobENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String SavedJobENT_String = String.Empty;

            if (!SavedJobID.IsNull)
                SavedJobENT_String += " SavedJobID = " + SavedJobID.Value.ToString();

            if (!CandidateID.IsNull)
                SavedJobENT_String += "| CandidateID = " + CandidateID.Value.ToString();

            if (!JobpostID.IsNull)
                SavedJobENT_String += "| JobpostID = " + JobpostID.Value.ToString();


            SavedJobENT_String = SavedJobENT_String.Trim();

            return SavedJobENT_String;
        }

        #endregion ToString
    }
}