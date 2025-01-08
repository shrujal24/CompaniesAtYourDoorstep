using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class SavedCandidatesENTBase
    {
        #region Properties

        protected SqlInt32 _SavedID;
        public SqlInt32 SavedID
        {
            get
            {
                return _SavedID;
            }
            set
            {
                _SavedID = value;
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

        public SavedCandidatesENTBase()
        {
            
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String SavedCandidatesENT_String = String.Empty;

            if (!SavedID.IsNull)
                SavedCandidatesENT_String += " SavedID = " + SavedID.Value.ToString();

            if (!CandidateID.IsNull)
                SavedCandidatesENT_String += "| CandidateID = " + CandidateID.Value.ToString();

            if (!JobpostID.IsNull)
                SavedCandidatesENT_String += "| JobpostID = " + JobpostID.Value.ToString();


            SavedCandidatesENT_String = SavedCandidatesENT_String.Trim();

            return SavedCandidatesENT_String;
        }

        #endregion ToString
    }
}