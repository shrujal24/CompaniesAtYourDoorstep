using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class CompanyPackageENTBase
    {

        #region Properties

        protected SqlInt32 _CompPackageID;
        public SqlInt32 CompPackageID
        {
            get
            {
                return _CompPackageID;
            }
            set
            {
                _CompPackageID = value;
            }
        }

        protected SqlInt32 _CompanyID;
        public SqlInt32 CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                _CompanyID = value;
            }
        }

        protected SqlInt32 _PackageID;
        public SqlInt32 PackageID
        {
            get
            {
                return _PackageID;
            }
            set
            {
                _PackageID = value;
            }
        }

        #endregion Properties

        #region Constructor

        public CompanyPackageENTBase()
        {
           
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String CompanyPackageENT_String = String.Empty;

            if (!CompPackageID.IsNull)
                CompanyPackageENT_String += " CompPackageID = " + CompPackageID.Value.ToString();

            if (!CompanyID.IsNull)
                CompanyPackageENT_String += "| CompanyID = " + CompanyID.Value.ToString();

            if (!PackageID.IsNull)
                CompanyPackageENT_String += "| PackageID = " + PackageID.Value.ToString();

            CompanyPackageENT_String = CompanyPackageENT_String.Trim();

            return CompanyPackageENT_String;
        }

        #endregion ToString
    }
}