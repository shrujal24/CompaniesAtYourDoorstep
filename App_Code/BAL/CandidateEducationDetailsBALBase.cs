using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class CandidateEducationDetailsBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Public Properties

        #region Constructor

        public CandidateEducationDetailsBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(CandidateEducationDetailsENT entCandidateEducationDetails)
        {
            CandidateEducationDetailsDAL dalCandidateEducationDetails = new CandidateEducationDetailsDAL();
            if (dalCandidateEducationDetails.Insert(entCandidateEducationDetails))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateEducationDetails.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(CandidateEducationDetailsENT entCandidateEducationDetails)
        {
            CandidateEducationDetailsDAL dalCandidateEducationDetails = new CandidateEducationDetailsDAL();
            if (dalCandidateEducationDetails.Update(entCandidateEducationDetails))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateEducationDetails.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 CandidateEduID)
        {
            CandidateEducationDetailsDAL dalCandidateEducationDetails = new CandidateEducationDetailsDAL();
            if (dalCandidateEducationDetails.Delete(CandidateEduID))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateEducationDetails.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public CandidateEducationDetailsENT SelectPK(SqlInt32 CandidateEduID)
        {
            CandidateEducationDetailsDAL dalCandidateEducationDetails = new CandidateEducationDetailsDAL();
            return dalCandidateEducationDetails.SelectPK(CandidateEduID);
        }
        public DataTable SelectAll()
        {
            CandidateEducationDetailsDAL dalCandidateEducationDetails = new CandidateEducationDetailsDAL();
            return dalCandidateEducationDetails.SelectAll();
        }

        #endregion SelectOperation
    }
}