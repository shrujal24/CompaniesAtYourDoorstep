using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class CompanyBALBase
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
        public CompanyBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(CompanyENT entCompany)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            if (dalCompany.Insert(entCompany))
            {
                return true;
            }
            else
            {
                this.Message = dalCompany.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(CompanyENT entCompany)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            if (dalCompany.Update(entCompany))
            {
                return true;
            }
            else
            {
                this.Message = dalCompany.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 CompanyID)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            if (dalCompany.Delete(CompanyID))
            {
                return true;
            }
            else
            {
                this.Message = dalCompany.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public CompanyENT SelectPK(SqlInt32 CompanyID)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            return dalCompany.SelectPK(CompanyID);
        }

        public DataTable SelectAll()
        {
            CompanyDAL dalCompany = new CompanyDAL();
            return dalCompany.SelectAll();
        }

        #endregion SelectOperation
    }
}