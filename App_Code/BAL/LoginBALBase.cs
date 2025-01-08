using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class LoginBALBase
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
        public LoginBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(LoginENT entLogin)
        {
            LoginDAL dalLogin = new LoginDAL();
            if (dalLogin.Insert(entLogin))
            {
                return true;
            }
            else
            {
                this.Message = dalLogin.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(LoginENT entLogin)
        {
            LoginDAL dalLogin = new LoginDAL();
            if (dalLogin.Update(entLogin))
            {
                return true;
            }
            else
            {
                this.Message = dalLogin.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlString Username)
        {
            LoginDAL dalLogin = new LoginDAL();
            if (dalLogin.Delete(Username))
            {
                return true;
            }
            else
            {
                this.Message = dalLogin.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public LoginENT SelectPK(SqlString Username)
        {
            LoginDAL dalLogin = new LoginDAL();
            return dalLogin.SelectPK(Username);
        }

        public DataTable SelectAll()
        {
            LoginDAL dalLogin = new LoginDAL();
            return dalLogin.SelectAll();
        }

        #endregion SelectOperation
    }
}