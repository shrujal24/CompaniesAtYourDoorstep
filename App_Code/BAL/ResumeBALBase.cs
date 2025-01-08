using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class ResumeBALBase
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
        public ResumeBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(ResumeENT entResume)
        {
            ResumeDAL dalResume = new ResumeDAL();
            if (dalResume.Insert(entResume))
            {
                return true;
            }
            else
            {
                this.Message = dalResume.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(ResumeENT entResume)
        {
            ResumeDAL dalResume = new ResumeDAL();
            if (dalResume.Update(entResume))
            {
                return true;
            }
            else
            {
                this.Message = dalResume.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 ResumeID)
        {
            ResumeDAL dalResume = new ResumeDAL();
            if (dalResume.Delete(ResumeID))
            {
                return true;
            }
            else
            {
                this.Message = dalResume.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public ResumeENT SelectPK(SqlInt32 ResumeID)
        {
            ResumeDAL dalResume = new ResumeDAL();
            return dalResume.SelectPK(ResumeID);
        }

        public DataTable SelectAll()
        {
            ResumeDAL dalResume = new ResumeDAL();
            return dalResume.SelectAll();
        }

        #endregion SelectOperation
    }
}