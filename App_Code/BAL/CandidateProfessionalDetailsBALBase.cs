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
    public abstract class CandidateProfessionalDetailsBALBase
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

        public CandidateProfessionalDetailsBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(CandidateProfessionalDetailsENT entCandidateProfessionalDetails)
        {
            CandidateProfessionalDetailsDAL dalCandidateProfessionalDetails = new CandidateProfessionalDetailsDAL();
            if (dalCandidateProfessionalDetails.Insert(entCandidateProfessionalDetails))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateProfessionalDetails.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(CandidateProfessionalDetailsENT entCandidateProfessionalDetails)
        {
            CandidateProfessionalDetailsDAL dalCandidateProfessionalDetails = new CandidateProfessionalDetailsDAL();
            if (dalCandidateProfessionalDetails.Update(entCandidateProfessionalDetails))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateProfessionalDetails.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 CandidateProfID)
        {
            CandidateProfessionalDetailsDAL dalCandidateProfessionalDetails = new CandidateProfessionalDetailsDAL();
            if (dalCandidateProfessionalDetails.Delete(CandidateProfID))
            {
                return true;
            }
            else
            {
                this.Message = dalCandidateProfessionalDetails.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public CandidateProfessionalDetailsENT SelectPK(SqlInt32 CandidateProfID)
        {
            CandidateProfessionalDetailsDAL dalCandidateProfessionalDetails = new CandidateProfessionalDetailsDAL();
            return dalCandidateProfessionalDetails.SelectPK(CandidateProfID);
        }
        public DataTable SelectAll()
        {
            CandidateProfessionalDetailsDAL dalCandidateProfessionalDetails = new CandidateProfessionalDetailsDAL();
            return dalCandidateProfessionalDetails.SelectAll();
        }

        #endregion SelectOperation
    }
}