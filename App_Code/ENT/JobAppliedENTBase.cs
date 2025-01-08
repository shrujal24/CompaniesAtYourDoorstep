using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class JobAppliedENTBase
    {	

        #region Properties

        protected SqlInt32 _AppliedID;
        public SqlInt32 AppliedID
        {
            get
            {
                return _AppliedID;
            }
            set
            {
                _AppliedID = value;
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

        protected SqlDateTime _AppliedDate;
        public SqlDateTime AppliedDate
        {
            get
            {
                return _AppliedDate;
            }
            set
            {
                _AppliedDate = value;
            }
        }

        #endregion Properties

        #region Constructor

        public JobAppliedENTBase()
        {
            
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String JobAppliedENT_String = String.Empty;

            if (!AppliedID.IsNull)
                JobAppliedENT_String += " AppliedID = " + AppliedID.Value.ToString();

            if (!CandidateID.IsNull)
                JobAppliedENT_String += "| CandidateID = " + CandidateID.Value.ToString();

            if (!JobpostID.IsNull)
                JobAppliedENT_String += "| JobpostID = " + JobpostID.Value.ToString();

             if (!AppliedDate.IsNull)
                JobAppliedENT_String += "| AppliedDate = " + AppliedDate.Value.ToString("dd-MM-yyyy");


            JobAppliedENT_String = JobAppliedENT_String.Trim();

            return JobAppliedENT_String;
        }

        #endregion ToString
    }
}