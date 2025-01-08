using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class AreaBALBase
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
        public AreaBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(AreaENT entArea)
        {
            AreaDAL dalArea = new AreaDAL();
            if (dalArea.Insert(entArea))
            {
                return true;
            }
            else
            {
                this.Message = dalArea.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(AreaENT entArea)
        {
            AreaDAL dalArea = new AreaDAL();
            if (dalArea.Update(entArea))
            {
                return true;
            }
            else
            {
                this.Message = dalArea.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 AreaID)
        {
            AreaDAL dalArea = new AreaDAL();
            if (dalArea.Delete(AreaID))
            {
                return true;
            }
            else
            {
                this.Message = dalArea.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public AreaENT SelectPK(SqlInt32 AreaID)
        {
            AreaDAL dalArea = new AreaDAL();
            return dalArea.SelectPK(AreaID);
        }
        
        public DataTable SelectAll()
        {
            AreaDAL dalArea = new AreaDAL();
            return dalArea.SelectAll();
        }

        #endregion SelectOperation
    }
}