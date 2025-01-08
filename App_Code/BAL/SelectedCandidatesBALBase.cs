using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class SelectedCandidatesBALBase
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
        public SelectedCandidatesBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(SelectedCandidatesENT entSelectedCandidates)
        {
            SelectedCandidatesDAL dalSelectedCandidates = new SelectedCandidatesDAL();
            if (dalSelectedCandidates.Insert(entSelectedCandidates))
            {
                return true;
            }
            else
            {
                this.Message = dalSelectedCandidates.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(SelectedCandidatesENT entSelectedCandidates)
        {
            SelectedCandidatesDAL dalSelectedCandidates = new SelectedCandidatesDAL();
            if (dalSelectedCandidates.Update(entSelectedCandidates))
            {
                return true;
            }
            else
            {
                this.Message = dalSelectedCandidates.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 SelectedID)
        {
            SelectedCandidatesDAL dalSelectedCandidates = new SelectedCandidatesDAL();
            if (dalSelectedCandidates.Delete(SelectedID))
            {
                return true;
            }
            else
            {
                this.Message = dalSelectedCandidates.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public SelectedCandidatesENT SelectPK(SqlInt32 SelectedID)
        {
            SelectedCandidatesDAL dalSelectedCandidates = new SelectedCandidatesDAL();
            return dalSelectedCandidates.SelectPK(SelectedID);
        }

        public DataTable SelectAll()
        {
            SelectedCandidatesDAL dalSelectedCandidates = new SelectedCandidatesDAL();
            return dalSelectedCandidates.SelectAll();
        }

        #endregion SelectOperation
    }
}