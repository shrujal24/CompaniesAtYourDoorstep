using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class CompanyPackageBALBase
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
        public CompanyPackageBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(CompanyPackageENT entCompanyPackage)
        {
            CompanyPackageDAL dalCompanyPackage = new CompanyPackageDAL();
            if (dalCompanyPackage.Insert(entCompanyPackage))
            {
                return true;
            }
            else
            {
                this.Message = dalCompanyPackage.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(CompanyPackageENT entCompanyPackage)
        {
            CompanyPackageDAL dalCompanyPackage = new CompanyPackageDAL();
            if (dalCompanyPackage.Update(entCompanyPackage))
            {
                return true;
            }
            else
            {
                this.Message = dalCompanyPackage.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 CompPackageID)
        {
            CompanyPackageDAL dalCompanyPackage = new CompanyPackageDAL();
            if (dalCompanyPackage.Delete(CompPackageID))
            {
                return true;
            }
            else
            {
                this.Message = dalCompanyPackage.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public CompanyPackageENT SelectPK(SqlInt32 CompPackageID)
        {
            CompanyPackageDAL dalCompanyPackage = new CompanyPackageDAL();
            return dalCompanyPackage.SelectPK(CompPackageID);
        }

        public DataTable SelectAll()
        {
            CompanyPackageDAL dalCompanyPackage = new CompanyPackageDAL();
            return dalCompanyPackage.SelectAll();
        }

        #endregion SelectOperation
    }
}