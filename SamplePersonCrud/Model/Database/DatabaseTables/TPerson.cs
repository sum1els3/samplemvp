using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Database.DatabaseTables
{
    class TPerson
    {
        //Defines the table from the database
        public static string TableName => "person";

        //Table columns
        public static string PersonID => "personID";
        public static string LastName => "lastName";
        public static string FirstName => "firstName";
        public static string MiddleName => "middleName";

        //Stored proceduress
        public static string Select => ConfigurationManager.AppSettings["personSelect"].ToString();
        public static string Insert => ConfigurationManager.AppSettings["personInsert"].ToString();
        public static string Update => ConfigurationManager.AppSettings["personUpdate"].ToString();
        public static string Delete => ConfigurationManager.AppSettings["personDelete"].ToString();
    }
}
