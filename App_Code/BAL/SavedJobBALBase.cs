using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class SavedJobBALBase
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
        public SavedJobBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(SavedJobENT entSavedJob)
        {
            SavedJobDAL dalSavedJob = new SavedJobDAL();
            if (dalSavedJob.Insert(entSavedJob))
            {
                return true;
            }
            else
            {
                this.Message = dalSavedJob.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(SavedJobENT entSavedJob)
        {
            SavedJobDAL dalSavedJob = new SavedJobDAL();
            if (dalSavedJob.Update(entSavedJob))
            {
                return true;
            }
            else
            {
                this.Message = dalSavedJob.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 SavedJobID)
        {
            SavedJobDAL dalSavedJob = new SavedJobDAL();
            if (dalSavedJob.Delete(SavedJobID))
            {
                return true;
            }
            else
            {
                this.Message = dalSavedJob.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public SavedJobENT SelectPK(SqlInt32 SavedJobID)
        {
            SavedJobDAL dalSavedJob = new SavedJobDAL();
            return dalSavedJob.SelectPK(SavedJobID);
        }

        public DataTable SelectAll()
        {
            SavedJobDAL dalSavedJob = new SavedJobDAL();
            return dalSavedJob.SelectAll();
        }

        #endregion SelectOperation
    }
}