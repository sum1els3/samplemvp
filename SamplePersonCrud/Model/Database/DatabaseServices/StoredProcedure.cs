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

        public void ExecuteNonQuery() => CreateNewConnectionAndExecuteNonQuery();

        public IDataReader ExecuteDataReader() => CreateNewConnectionAndExecuteDataReader();

        private void CreateNewConnectionAndExecuteNonQuery()
        {
            using (IDbConnection con = DatabaseConnection.Connection)
            {
                using (IDbCommand command = DatabaseConnection.Command(StoredProcedureName))
                {
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    AddParametersIntoStoredProcedure(command, Parameters);
                    ExecuteNonQuery(command);
                }
            }
        }

        private IDataReader CreateNewConnectionAndExecuteDataReader()
        {
            IDbConnection con = DatabaseConnection.Connection;
            using (IDbCommand command = DatabaseConnection.Command(StoredProcedureName))
            {
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                AddParametersIntoStoredProcedure(command, Parameters);
                con.Open();
                IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }

        private static void AddParametersIntoStoredProcedure(IDbCommand command, List<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                IDataParameter param = DatabaseConnection.Parameter;
                param.ParameterName = string.Format("@{0}", parameter.ParameterName);
                param.DbType = (DbType)parameter.ParameterType;
                param.Value = parameter.ParameterValue;
                command.Parameters.Add(param);
            }
        }

        private static void ExecuteNonQuery(IDbCommand command)
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
