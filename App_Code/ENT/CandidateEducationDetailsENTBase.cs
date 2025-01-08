using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class CandidateEducationDetailsENTBase
    {
        #region Properties

        protected SqlInt32 _CandidateEduID;
        public SqlInt32 CandidateEduID
        {
            get
            {
                return _CandidateEduID;
            }
            set
            {
                _CandidateEduID = value;
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

        protected SqlDecimal _Percantage10;
        public SqlDecimal Percantage10
        {
            get 
            {
                return _Percantage10;
            }
            set 
            {
                _Percantage10 = value;
            }
        }

        protected SqlDecimal _Percantage12;
        public SqlDecimal Percantage12
        {
            get
            {
                return _Percantage12;
            }
            set
            {
                _Percantage12 = value;
            }
        }

        protected SqlString _Graduation;
        public SqlString Graduation
        {
            get
            {
                return _Graduation;
            }
            set
            {
                _Graduation = value;
            }
        }

        protected SqlString _InstituteGrad;
        public SqlString InstituteGrad
        {
            get
            {
                return _InstituteGrad;
            }
            set
            {
                _InstituteGrad = value;
            }
        }

        protected SqlDecimal _PercantageGrad;
        public SqlDecimal PercantageGrad
        {
            get
            {
                return _PercantageGrad;
            }
            set
            {
                _PercantageGrad = value;
            }
        }

        protected SqlString _PostGrad;
        public SqlString PostGrad
        {
            get
            {
                return _PostGrad;
            }
            set
            {
                _PostGrad = value;
            }
        }

        protected SqlString _InstitutePostGrad;
        public SqlString InstitutePostGrad
        {
            get
            {
                return _InstitutePostGrad;
            }
            set
            {
                _InstitutePostGrad = value;
            }
        }

        protected SqlDecimal _PercantagePostGrad;
        public SqlDecimal PercantagePostGrad
        {
            get
            {
                return _PercantagePostGrad;
            }
            set
            {
                _PercantagePostGrad = value;
            }
        }

        

        protected SqlString _DrPhd;
        public SqlString DrPhd
        {
            get
            {
                return _DrPhd;
            }
            set
            {
                _DrPhd = value;
            }
        }

        protected SqlString _InstituteDrPhd;
        public SqlString InstituteDrPhd
        {
            get
            {
                return _InstituteDrPhd;
            }
            set
            {
                _InstituteDrPhd = value;
            }
        }

        protected SqlDecimal _PercantageDrPhd;
        public SqlDecimal PercantageDrPhd
        {
            get
            {
                return _PercantageDrPhd;
            }
            set
            {
                _PercantageDrPhd = value;
            }
        }

        protected SqlString _Certification;
        public SqlString Certification
        {
            get
            {
                return _Certification;
            }
            set
            {
                _Certification = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CandidateEducationDetailsENTBase()
        {
            
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String CandidateEducationDetailsENT_String = String.Empty;

            if (!CandidateEduID.IsNull)
                CandidateEducationDetailsENT_String += " CandidateEduID = " + CandidateEduID.Value.ToString();

            if (!CandidateID.IsNull)
                CandidateEducationDetailsENT_String += "| CandidateID = " + CandidateID.Value.ToString();

            if (!Percantage10.IsNull)
                CandidateEducationDetailsENT_String += "| Percantage10 = " + Percantage10.Value.ToString();

            if (!Percantage12.IsNull)
                CandidateEducationDetailsENT_String += "| Percantage12 = " + Percantage12.Value.ToString();

            if (!Graduation.IsNull)
                CandidateEducationDetailsENT_String += "| Graduation = " + Graduation.Value;

            if (!InstituteGrad.IsNull)
                CandidateEducationDetailsENT_String += "| InstituteGrad = " + InstituteGrad.Value;

            if (!PercantageGrad.IsNull)
                CandidateEducationDetailsENT_String += "| PercantageGrad = " + PercantageGrad.Value.ToString();

            if (!PostGrad.IsNull)
                CandidateEducationDetailsENT_String += "| PostGrad = " + PostGrad.Value;

            if (!InstitutePostGrad.IsNull)
                CandidateEducationDetailsENT_String += "| InstitutePostGrad = " + InstitutePostGrad.Value;

            if (!PercantagePostGrad.IsNull)
                CandidateEducationDetailsENT_String += "| PercantagePostGrad = " + PercantagePostGrad.Value.ToString();

            if (!DrPhd.IsNull)
                CandidateEducationDetailsENT_String += "| DrPhd = " + DrPhd.Value;

            if (!InstituteDrPhd.IsNull)
                CandidateEducationDetailsENT_String += "| InstituteDrPhd = " + InstituteDrPhd.Value;

            if (!PercantageDrPhd.IsNull)
                CandidateEducationDetailsENT_String += "| PercantageDrPhd = " + PercantageDrPhd.Value.ToString();

            if (!Certification.IsNull)
                CandidateEducationDetailsENT_String += "| Certification = " + Certification.Value;

            CandidateEducationDetailsENT_String = CandidateEducationDetailsENT_String.Trim();

            return CandidateEducationDetailsENT_String;
        }

        #endregion ToString
    }
}