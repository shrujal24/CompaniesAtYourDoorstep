using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class SelectedCandidatesENTBase
    {
        #region Properties

        protected SqlInt32 _SelectedID;
        public SqlInt32 SelectedID
        {
            get
            {
                return _SelectedID;
            }
            set
            {
                _SelectedID = value;
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

        public SelectedCandidatesENTBase()
        {
            
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String SelectedCandidatesENT_String = String.Empty;

            if (!SelectedID.IsNull)
                SelectedCandidatesENT_String += " SelectedID = " + SelectedID.Value.ToString();

            if (!CandidateID.IsNull)
                SelectedCandidatesENT_String += "| CandidateID = " + CandidateID.Value.ToString();

            if (!JobpostID.IsNull)
                SelectedCandidatesENT_String += "| JobpostID = " + JobpostID.Value.ToString();


            SelectedCandidatesENT_String = SelectedCandidatesENT_String.Trim();

            return SelectedCandidatesENT_String;
        }

        #endregion ToString
    }
}