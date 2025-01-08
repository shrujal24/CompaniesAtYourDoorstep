using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class PackageBALBase
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
        public PackageBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PackageENT entPackage)
        {
            PackageDAL dalPackage = new PackageDAL();
            if (dalPackage.Insert(entPackage))
            {
                return true;
            }
            else
            {
                this.Message = dalPackage.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(PackageENT entPackage)
        {
            PackageDAL dalPackage = new PackageDAL();
            if (dalPackage.Update(entPackage))
            {
                return true;
            }
            else
            {
                this.Message = dalPackage.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 PackageID)
        {
            PackageDAL dalPackage = new PackageDAL();
            if (dalPackage.Delete(PackageID))
            {
                return true;
            }
            else
            {
                this.Message = dalPackage.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public PackageENT SelectPK(SqlInt32 PackageID)
        {
            PackageDAL dalPackage = new PackageDAL();
            return dalPackage.SelectPK(PackageID);
        }

        public DataTable SelectAll()
        {
            PackageDAL dalPackage = new PackageDAL();
            return dalPackage.SelectAll();
        }

        #endregion SelectOperation
    }
}