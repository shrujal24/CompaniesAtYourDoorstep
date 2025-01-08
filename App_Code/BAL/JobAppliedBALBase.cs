using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class JobAppliedBALBase
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
        public JobAppliedBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(JobAppliedENT entJobApplied)
        {
            JobAppliedDAL dalJobApplied = new JobAppliedDAL();
            if (dalJobApplied.Insert(entJobApplied))
            {
                return true;
            }
            else
            {
                this.Message = dalJobApplied.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(JobAppliedENT entJobApplied)
        {
            JobAppliedDAL dalJobApplied = new JobAppliedDAL();
            if (dalJobApplied.Update(entJobApplied))
            {
                return true;
            }
            else
            {
                this.Message = dalJobApplied.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 AppliedID)
        {
            JobAppliedDAL dalJobApplied = new JobAppliedDAL();
            if (dalJobApplied.Delete(AppliedID))
            {
                return true;
            }
            else
            {
                this.Message = dalJobApplied.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public JobAppliedENT SelectPK(SqlInt32 AppliedID)
        {
            JobAppliedDAL dalJobApplied = new JobAppliedDAL();
            return dalJobApplied.SelectPK(AppliedID);
        }

        public DataTable SelectAll()
        {
            JobAppliedDAL dalJobApplied = new JobAppliedDAL();
            return dalJobApplied.SelectAll();
        }

        #endregion SelectOperation
    }
}