using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class QuestionENTBase
    {
        #region Properties

        protected SqlInt32 _QueID;
        public SqlInt32 QueID
        {
            get
            {
                return _QueID;
            }
            set
            {
                _QueID = value;
            }
        }

        protected SqlString _Question;
        public SqlString Question
        {
            get
            {
                return _Question;
            }
            set
            {
                _Question = value;
            }
        }

        #endregion Properties

        #region Constructor

        public QuestionENTBase()
        {
           
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String QuestionENT_String = String.Empty;

            if (!QueID.IsNull)
                QuestionENT_String += " QueID = " + QueID.Value.ToString();

            if (!Question.IsNull)
                QuestionENT_String += "| Question = " + Question.Value;

            QuestionENT_String = QuestionENT_String.Trim();

            return QuestionENT_String;
        }

        #endregion ToString
    }
}