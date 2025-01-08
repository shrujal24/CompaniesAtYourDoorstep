using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CompaniesatyourDoorstpe.ENT
{
    public abstract class PackageENTBase
    {
        #region Properties
       
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

        protected SqlString _PackageCost;
        public SqlString PackageCost
        {
            get
            {
                return _PackageCost;
            }
            set
            {
                _PackageCost = value;
            }
        }

        protected SqlDecimal _NoJobs;
        public SqlDecimal NoJobs
        {
            get
            {
                return _NoJobs;
            }
            set
            {
                _NoJobs = value;
            }
        }

        #endregion Properties

        #region Constructor

        public PackageENTBase()
        {
           
        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String PackageENT_String = String.Empty;

            if (!PackageID.IsNull)
                PackageENT_String += " PackageID = " + PackageID.Value.ToString();

            if (!PackageCost.IsNull)
                PackageENT_String += "| PackageCost = " + PackageCost.Value;

            if (!NoJobs.IsNull)
                PackageENT_String += "| NoJobs = " + NoJobs.Value.ToString();

            PackageENT_String = PackageENT_String.Trim();

            return PackageENT_String;
        }

        #endregion ToString
    }
}