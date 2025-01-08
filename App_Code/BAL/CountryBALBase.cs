using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class CountryBALBase
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

        public CountryBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.Insert(entCountry))
            {
                return true;
            }
            else
            {
                this.Message = dalCountry.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.Update(entCountry))
            {
                return true;
            }
            else
            {
                this.Message = dalCountry.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.Delete(CountryID))
            {
                return true;
            }
            else
            {
                this.Message = dalCountry.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public CountryENT SelectPK(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectPK(CountryID);
        }
        public DataTable SelectAll()
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectAll();
        }

        #endregion SelectOperation
    }
}