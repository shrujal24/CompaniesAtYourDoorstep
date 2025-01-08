using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class JobPostBALBase
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
        public JobPostBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(JobPostENT entJobPost)
        {
            JobPostDAL dalJobPost = new JobPostDAL();
            if (dalJobPost.Insert(entJobPost))
            {
                return true;
            }
            else
            {
                this.Message = dalJobPost.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(JobPostENT entJobPost)
        {
            JobPostDAL dalJobPost = new JobPostDAL();
            if (dalJobPost.Update(entJobPost))
            {
                return true;
            }
            else
            {
                this.Message = dalJobPost.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 JobpostID)
        {
            JobPostDAL dalJobPost = new JobPostDAL();
            if (dalJobPost.Delete(JobpostID))
            {
                return true;
            }
            else
            {
                this.Message = dalJobPost.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public JobPostENT SelectPK(SqlInt32 JobpostID)
        {
            JobPostDAL dalJobPost = new JobPostDAL();
            return dalJobPost.SelectPK(JobpostID);
        }

        public DataTable SelectAll()
        {
            JobPostDAL dalJobPost = new JobPostDAL();
            return dalJobPost.SelectAll();
        }

        #endregion SelectOperation
    }
}