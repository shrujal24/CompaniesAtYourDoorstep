using CompaniesatyourDoorstpe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public class QuestionBAL : QuestionBALBase
    {
        #region ComboBox

        public DataTable SelectComboBox()
        {
            QuestionDAL dalQuestion = new QuestionDAL();
            return dalQuestion.SelectComboBox();
        }

        #endregion ComboBox
    }
}