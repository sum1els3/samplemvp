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
        //Defines the person table from the database
        public static string TableName => "person";

        //Table columns
        public static string ID => "personID";
        public static string LastName => "lastName";
        public static string FirstName => "firstName";
        public static string MiddleName => "middleName";

        //Stored proceduress
        public static string Select => ConfigurationManager.AppSettings[""].ToString();
        public static string Insert => ConfigurationManager.AppSettings[""].ToString();
        public static string Update => ConfigurationManager.AppSettings[""].ToString();
        public static string Delete => ConfigurationManager.AppSettings[""].ToString();
    }
}
