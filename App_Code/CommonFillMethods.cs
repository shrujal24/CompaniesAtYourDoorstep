using CompaniesatyourDoorstpe.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CompaniesatyourDoorstpe
{
    public class CommonFillMethods
    {
        public CommonFillMethods()
        {
           
        }

        public static void FillDropDownListCountry(DropDownList ddl)
        {
            CountryBAL balCountry = new CountryBAL();
            ddl.DataSource = balCountry.SelectComboBox();
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Country ", "-99"));
        }

        public static void FillDropDownListStateByCountryID(DropDownList ddl, SqlInt32 CountryID)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectComboBoxByCountryID(CountryID);
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select State ", "-99"));
        }

        public static void FillDropDownListCityByStateID(DropDownList ddl, SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectComboBoxByStateID(StateID);
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select City ", "-99"));
        }

        public static void FillDropDownListCategory(DropDownList ddl)
        {
            CategoryBAL balCategory = new CategoryBAL();
            ddl.DataSource = balCategory.SelectComboBox();
            ddl.DataValueField = "CategoryID";
            ddl.DataTextField = "CategoryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Category ", "-99"));
        }

        public static void FillDropDownListQuestion(DropDownList ddl)
        {
            QuestionBAL balQuestion = new QuestionBAL();
            ddl.DataSource = balQuestion.SelectComboBox();
            ddl.DataValueField = "QueID";
            ddl.DataTextField = "Question";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Question ", "-99"));
        }
    }
}