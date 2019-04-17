using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Database.DatabaseTables
{
    class TUser
    {
        //Defines the person table from the database
        public static string TableName => "users";

        //Table columns
        public static string UserID => "usersID";
        public static string Username => "username";
        public static string Password => "password";

        //Stored proceduress
        public static string Select => ConfigurationManager.AppSettings["userSelect"].ToString();
        public static string Insert => ConfigurationManager.AppSettings["userInsert"].ToString();
        public static string Update => ConfigurationManager.AppSettings["userUpdate"].ToString();
        public static string Delete => ConfigurationManager.AppSettings["userDelete"].ToString();
    }
}
