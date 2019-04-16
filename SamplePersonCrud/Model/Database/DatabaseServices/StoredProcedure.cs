using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamplePersonCrud.Model.Database.DatabaseLocation;

namespace SamplePersonCrud.Model.Database.DatabaseServices
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
            using (SqlConnection con = DatabaseLocation.Database.Connection)
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
}
