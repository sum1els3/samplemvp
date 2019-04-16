using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.DatabaseTables
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
    }
}
