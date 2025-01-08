using CompaniesatyourDoorstpe.DAL;
using CompaniesatyourDoorstpe.ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace CompaniesatyourDoorstpe.BAL
{
    public abstract class PostBALBase
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
        public PostBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(PostENT entPost)
        {
            PostDAL dalPost = new PostDAL();
            if (dalPost.Insert(entPost))
            {
                return true;
            }
            else
            {
                this.Message = dalPost.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(PostENT entPost)
        {
            PostDAL dalPost = new PostDAL();
            if (dalPost.Update(entPost))
            {
                return true;
            }
            else
            {
                this.Message = dalPost.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 PostID)
        {
            PostDAL dalPost = new PostDAL();
            if (dalPost.Delete(PostID))
            {
                return true;
            }
            else
            {
                this.Message = dalPost.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public PostENT SelectPK(SqlInt32 PostID)
        {
            PostDAL dalPost = new PostDAL();
            return dalPost.SelectPK(PostID);
        }

        public DataTable SelectAll()
        {
            PostDAL dalPost = new PostDAL();
            return dalPost.SelectAll();
        }

        #endregion SelectOperation
    }
}