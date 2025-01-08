using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class SavedCandidatesBALBase
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
        public SavedCandidatesBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(SavedCandidatesENT entSavedCandidates)
        {
            SavedCandidatesDAL dalSavedCandidates = new SavedCandidatesDAL();
            if (dalSavedCandidates.Insert(entSavedCandidates))
            {
                return true;
            }
            else
            {
                this.Message = dalSavedCandidates.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(SavedCandidatesENT entSavedCandidates)
        {
            SavedCandidatesDAL dalSavedCandidates = new SavedCandidatesDAL();
            if (dalSavedCandidates.Update(entSavedCandidates))
            {
                return true;
            }
            else
            {
                this.Message = dalSavedCandidates.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 SavedID)
        {
            SavedCandidatesDAL dalSavedCandidates = new SavedCandidatesDAL();
            if (dalSavedCandidates.Delete(SavedID))
            {
                return true;
            }
            else
            {
                this.Message = dalSavedCandidates.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public SavedCandidatesENT SelectPK(SqlInt32 SavedID)
        {
            SavedCandidatesDAL dalSavedCandidates = new SavedCandidatesDAL();
            return dalSavedCandidates.SelectPK(SavedID);
        }

        public DataTable SelectAll()
        {
            SavedCandidatesDAL dalSavedCandidates = new SavedCandidatesDAL();
            return dalSavedCandidates.SelectAll();
        }

        #endregion SelectOperation
    }
}