using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class QuestionBALBase
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
        public QuestionBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(QuestionENT entQuestion)
        {
            QuestionDAL dalQuestion = new QuestionDAL();
            if (dalQuestion.Insert(entQuestion))
            {
                return true;
            }
            else
            {
                this.Message = dalQuestion.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(QuestionENT entQuestion)
        {
            QuestionDAL dalQuestion = new QuestionDAL();
            if (dalQuestion.Update(entQuestion))
            {
                return true;
            }
            else
            {
                this.Message = dalQuestion.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 QueID)
        {
            QuestionDAL dalQuestion = new QuestionDAL();
            if (dalQuestion.Delete(QueID))
            {
                return true;
            }
            else
            {
                this.Message = dalQuestion.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public QuestionENT SelectPK(SqlInt32 QueID)
        {
            QuestionDAL dalQuestion = new QuestionDAL();
            return dalQuestion.SelectPK(QueID);
        }

        public DataTable SelectAll()
        {
            QuestionDAL dalQuestion = new QuestionDAL();
            return dalQuestion.SelectAll();
        }

        #endregion SelectOperation
    }
}