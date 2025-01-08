using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class ResumeENTBase
    {
        #region Properties

        protected SqlInt32 _ResumeID;
        public SqlInt32 ResumeID
        {
            get
            {
                return _ResumeID;
            }
            set
            {
                _ResumeID = value;
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

        protected SqlString _ResumeHeadline;
        public SqlString ResumeHeadline
        {
            get
            {
                return _ResumeHeadline;
            }
            set
            {
                _ResumeHeadline = value;
            }
        }

        protected SqlString _Path;
        public SqlString Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
            }
        }


        #endregion Properties

        #region Constructor

        public ResumeENTBase()
        {
            
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String AreaENT_String = String.Empty;

            if (!ResumeID.IsNull)
                AreaENT_String += " ResumeID = " + ResumeID.Value.ToString();

            if (!CandidateID.IsNull)
                AreaENT_String += "| CandidateID = " + CandidateID.Value;

            if (!ResumeHeadline.IsNull)
                AreaENT_String += "| ResumeHeadline = " + ResumeHeadline.Value;

             if (!Path.IsNull)
                AreaENT_String += "| Path = " + Path.Value;

            AreaENT_String = AreaENT_String.Trim();

            return AreaENT_String;
        }

        #endregion ToString
    }
}