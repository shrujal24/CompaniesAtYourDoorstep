using CompaniesatyourDoorstpe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.BAL
{
    public class CategoryBAL : CategoryBALBase
    {
        public DataTable SelectComboBox()
        {
            CategoryDAL dalCategory = new CategoryDAL();
            return dalCategory.SelectComboBox();
        }
    }
}