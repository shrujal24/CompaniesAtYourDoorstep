using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class MasterUserBALBase
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

        public MasterUserBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MasterUserENT entMasterUser)
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            if (dalMasterUser.Insert(entMasterUser))
            {
                return true;
            }
            else
            {
                this.Message = dalMasterUser.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MasterUserENT entMasterUser)
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            if (dalMasterUser.Update(entMasterUser))
            {
                return true;
            }
            else
            {
                this.Message = dalMasterUser.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 UserID)
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            if (dalMasterUser.Delete(UserID))
            {
                return true;
            }
            else
            {
                this.Message = dalMasterUser.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MasterUserENT SelectPK(SqlInt32 UserID)
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            return dalMasterUser.SelectPK(UserID);
        }
        
        public DataTable SelectAll()
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            return dalMasterUser.SelectAll();
        }

        #endregion SelectOperation
    }
}