using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class CandidateProfessionalDetailsENTBase
    {

        #region Properties

        protected SqlInt32 _CandidateProfID;
        public SqlInt32 CandidateProfID
        {
            get
            {
                return _CandidateProfID;
            }
            set
            {
                _CandidateProfID = value;
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

        protected SqlInt32 _ExpYrs;
        public SqlInt32 ExpYrs
        {
            get
            {
                return _ExpYrs;
            }
            set
            {
                _ExpYrs = value;
            }
        }

        protected SqlInt32 _ExpMns;
        public SqlInt32 ExpMns
        {
            get
            {
                return _ExpMns;
            }
            set
            {
                _ExpMns = value;
            }
        }

        protected SqlString _Salary;
        public SqlString Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                _Salary = value;
            }
        }

        protected SqlString _Industry;
        public SqlString Industry
        {
            get
            {
                return _Industry;
            }
            set
            {
                _Industry = value;
            }
        }

        protected SqlString _IndRole;
        public SqlString IndRole
        {
            get
            {
                return _IndRole;
            }
            set
            {
                _IndRole = value;
            }
        }

        protected SqlString _Skills;
        public SqlString Skills
        {
            get
            {
                return _Skills;
            }
            set
            {
                _Skills = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CandidateProfessionalDetailsENTBase()
        {
           
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String CandidateProfessionalDetailsENT_String = String.Empty;

            if (!CandidateProfID.IsNull)
                CandidateProfessionalDetailsENT_String += " CandidateProfID = " + CandidateProfID.Value.ToString();
            
            if (!CandidateID.IsNull)
                CandidateProfessionalDetailsENT_String += "| CandidateID = " + CandidateID.Value.ToString();

            if (!AreaID.IsNull)
                CandidateProfessionalDetailsENT_String += "| AreaID = " + AreaID.Value.ToString();

            if (!ExpYrs.IsNull)
                CandidateProfessionalDetailsENT_String += "| ExpYrs = " + ExpYrs.Value.ToString();

            if (!ExpMns.IsNull)
                CandidateProfessionalDetailsENT_String += "| ExpMns = " + ExpMns.Value.ToString();

            if (!Salary.IsNull)
                CandidateProfessionalDetailsENT_String += "| Salary = " + Salary.Value;

            if (!Industry.IsNull)
                CandidateProfessionalDetailsENT_String += "| Industry = " + Industry.Value;

            if (!IndRole.IsNull)
                CandidateProfessionalDetailsENT_String += "| IndRole = " + IndRole.Value;

            if (!Skills.IsNull)
                CandidateProfessionalDetailsENT_String += "| Skills = " + Skills.Value;

            
            CandidateProfessionalDetailsENT_String = CandidateProfessionalDetailsENT_String.Trim();

            return CandidateProfessionalDetailsENT_String;
        }

        #endregion ToString
    }
}