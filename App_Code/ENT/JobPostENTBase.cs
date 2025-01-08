using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class JobPostENTBase
    {
        #region Properties

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

        protected SqlInt32 _CompanyID;
        public SqlInt32 CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                _CompanyID = value;
            }
        }
        
        protected SqlString _JobTitle;
        public SqlString JobTitle
        {
            get
            {
                return _JobTitle;
            }
            set
            {
                _JobTitle = value;
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

        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }


        protected SqlString _Post;
        public SqlString Post
        {
            get
            {
                return _Post;
            }
            set
            {
                _Post = value;
            }
        }

        protected SqlDecimal _NoVacancy;
        public SqlDecimal NoVacancy
        {
            get
            {
                return _NoVacancy;
            }
            set
            {
                _NoVacancy = value;
            }
        }

        protected SqlDateTime _StartDate;
        public SqlDateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }

        
        protected SqlDateTime _EndDate;
        public SqlDateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }

        protected SqlString _ExpYrs;
        public SqlString ExpYrs
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

        protected SqlString _SkillsReq;
        public SqlString SkillsReq
        {
            get
            {
                return _SkillsReq;
            }
            set
            {
                _SkillsReq = value;
            }
        }

        protected SqlString _EduReq;
        public SqlString EduReq
        {
            get
            {
                return _EduReq;
            }
            set
            {
                _EduReq = value;
            }
        }

        protected SqlString _BasicReq;
        public SqlString BasicReq
        {
            get
            {
                return _BasicReq;
            }
            set
            {
                _BasicReq = value;
            }
        }

        
        protected SqlDecimal _SalaryMin;
        public SqlDecimal SalaryMin
        {
            get
            {
                return _SalaryMin;
            }
            set
            {
                _SalaryMin = value;
            }
        }

        protected SqlDecimal _SalaryMax;
        public SqlDecimal SalaryMax
        {
            get
            {
                return _SalaryMax;
            }
            set
            {
                _SalaryMax = value;
            }
        }

        #endregion Properties

        #region Constructor

        public JobPostENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String JobPostENT_String = String.Empty;

            if (!JobpostID.IsNull)
                JobPostENT_String += " JobpostID = " + JobpostID.Value.ToString();

            if (!CompanyID.IsNull)
                JobPostENT_String += "| CompanyID = " + CompanyID.Value.ToString();

            if (!JobTitle.IsNull)
                JobPostENT_String += "| JobTitle = " + JobTitle.Value;

            if (!AreaID.IsNull)
                JobPostENT_String += "| AreaID = " + AreaID.Value.ToString();

            if (!CityID.IsNull)
                JobPostENT_String += "| CityID = " + CityID.Value.ToString();

            if (!Post.IsNull)
                JobPostENT_String += "| Post = " + Post.Value;

            if (!NoVacancy.IsNull)
                JobPostENT_String += "| NoVacancy = " + NoVacancy.Value.ToString();

            if (!StartDate.IsNull)
                JobPostENT_String += "| StartDate = " + StartDate.Value.ToString("dd-MM-yyyy");

            if (!EndDate.IsNull)
                JobPostENT_String += "| EndDate = " + EndDate.Value.ToString("dd-MM-yyyy");

            if (!ExpYrs.IsNull)
                JobPostENT_String += "| ExpYrs = " + ExpYrs.Value;

            if (!SkillsReq.IsNull)
                JobPostENT_String += "| SkillsReq = " + SkillsReq.Value;

            if (!EduReq.IsNull)
                JobPostENT_String += "| EduReq = " + EduReq.Value;

            if (!BasicReq.IsNull)
                JobPostENT_String += "| BasicReq = " + BasicReq.Value;

            if (!SalaryMin.IsNull)
                JobPostENT_String += "| SalaryMin = " + SalaryMin.Value;

            if (!SalaryMax.IsNull)
                JobPostENT_String += "| SalaryMax = " + SalaryMax.Value;

            JobPostENT_String = JobPostENT_String.Trim();

            return JobPostENT_String;
        }

        #endregion ToString
    }
}