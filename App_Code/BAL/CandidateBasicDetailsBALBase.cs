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
    public abstract class CandidateBasicDetailsBALBase
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

        public CandidateBasicDetailsBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(CandidateBasicDetailsENT entCandidateBasicDetails)
        {
            CandidateBasicDetailsDAL dalCandidateBasicDetails = new CandidateBasicDetailsDAL();
            if (dalCandidateBasicDetails.Insert(entCandidateBasicDetails))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateBasicDetails.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(CandidateBasicDetailsENT entCandidateBasicDetails)
        {
            CandidateBasicDetailsDAL dalCandidateBasicDetails = new CandidateBasicDetailsDAL();
            if (dalCandidateBasicDetails.Update(entCandidateBasicDetails))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateBasicDetails.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 CandidateID)
        {
            CandidateBasicDetailsDAL dalCandidateBasicDetails = new CandidateBasicDetailsDAL();
            if (dalCandidateBasicDetails.Delete(CandidateID))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateBasicDetails.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public CandidateBasicDetailsENT SelectPK(SqlInt32 CandidateID)
        {
            CandidateBasicDetailsDAL dalCandidateBasicDetails = new CandidateBasicDetailsDAL();
            return dalCandidateBasicDetails.SelectPK(CandidateID);
        }
        public DataTable SelectAll()
        {
            CandidateBasicDetailsDAL dalCandidateBasicDetails = new CandidateBasicDetailsDAL();
            return dalCandidateBasicDetails.SelectAll();
        }

        #endregion SelectOperation
    }
}