using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class CategoryBALBase
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
        public CategoryBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(CategoryENT entCategory)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            if (dalCategory.Insert(entCategory))
            {
                return true;
            }
            else
            {
                this.Message = dalCategory.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(CategoryENT entCategory)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            if (dalCategory.Update(entCategory))
            {
                return true;
            }
            else
            {
                this.Message = dalCategory.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 CategoryID)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            if (dalCategory.Delete(CategoryID))
            {
                return true;
            }
            else
            {
                this.Message = dalCategory.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public CategoryENT SelectPK(SqlInt32 CategoryID)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            return dalCategory.SelectPK(CategoryID);
        }

        public DataTable SelectAll()
        {
            CategoryDAL dalCategory = new CategoryDAL();
            return dalCategory.SelectAll();
        }

        #endregion SelectOperation
    }
}