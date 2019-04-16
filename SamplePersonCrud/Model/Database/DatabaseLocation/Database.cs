using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Database.DatabaseLocation
{
    class Database
    {
        //Gets the value from App.config to avoid compiling when changing the data of the database
        public static string DatabaseIP => ConfigurationManager.AppSettings["databaseIP"].ToString();
        public static string DatabasePort => ConfigurationManager.AppSettings["databasePort"].ToString();
        public static string DatabaseName => ConfigurationManager.AppSettings["databaseName"].ToString();
        public static string DatabaseUsername => ConfigurationManager.AppSettings["databaseUsername"].ToString();
        public static string DatabasePassword => ConfigurationManager.AppSettings["databasePassword"].ToString();

        public static string DatabaseConnectionString => string.Format
        (
            "data source={0},{1}; database={2};user id={3};password={4}",
            DatabaseIP,
            DatabasePort,
            DatabaseName,
            DatabaseUsername,
            DatabasePassword
        );

        public static SqlConnection Connection => new SqlConnection(DatabaseConnectionString);
    }
}
