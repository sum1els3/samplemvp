using SamplePersonCrud.Model.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.DatabaseServices
{
    class StoredProcedure
    {
        public StoredProcedure()
        {
            Parameters = new List<Parameter>();
        }

        public string StoredProcedureName { get; set; }
        public List<Parameter> Parameters { get; set; }

        public void ExecuteNonQuery()
        {
            CreateNewConnectionAndExecuteNonQuery();
        }

        private void CreateNewConnectionAndExecuteNonQuery()
        {
            using (SqlConnection con = DatabaseLocation.Connection)
            {
                using (SqlCommand command = new SqlCommand(StoredProcedureName, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    AddParametersIntoStoredProcedure(command, Parameters);
                    ExecuteNonQuery(command);
                }
            }
        }

        private static void AddParametersIntoStoredProcedure(SqlCommand command, List<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                command.Parameters.Add(string.Format("@{0}", parameter.ParameterName), parameter.ParameterType).Value = parameter.ParameterValue;
            }
        }

        private static void ExecuteNonQuery(SqlCommand command)
        {
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }

    class Parameter
    {
        public string ParameterName { get; set; }
        public object ParameterValue { get; set; }
        public SqlDbType ParameterType { get; set; }
    }

    static class ProcedureName
    {
        //My stored procedure naming convention (optional)
        public static string InsertStoredProcedureName(string tableName) => string.Format("InsertInto{0}Table", tableName);
        public static string UpdateStoredProcedureName(string tableName) => string.Format("UpdateSet{0}Table", tableName);
        public static string DeleteStoredProcedureName(string tableName) => string.Format("DeleteFrom{0}Table", tableName);
    }
}
