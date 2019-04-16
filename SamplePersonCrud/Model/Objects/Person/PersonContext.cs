using SamplePersonCrud.Model.Database.DatabaseServices;
using SamplePersonCrud.Model.Database.DatabaseTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.Person
{
    class PersonContext : Person, ICUD
    {
        public void Create()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = TPerson.Insert;
            storedProcedure.Parameters.AddRange(GetParameters.FindAll(item => !item.ParameterName.Equals(TPerson.ID)));
            storedProcedure.ExecuteNonQuery();
        }

        public void Delete()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = TPerson.Delete;
            storedProcedure.Parameters.Add(GetParameters.Find(item => item.ParameterName.Equals(TPerson.ID)));
            storedProcedure.ExecuteNonQuery();
        }

        public void Update()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = TPerson.Update;
            storedProcedure.Parameters.AddRange(GetParameters);
            storedProcedure.ExecuteNonQuery();
        }

        private List<Parameter> GetParameters
        {
            get => new List<Parameter>()
            {
                //Can be in any order
                new Parameter()
                {
                    //Gets the column name as the parameter name
                    ParameterName = TPerson.ID,
                    ParameterType = SqlDbType.Int,
                    ParameterValue = ID
                },
                new Parameter()
                {
                    ParameterName = TPerson.LastName,
                    ParameterType = SqlDbType.VarChar,
                    ParameterValue = LastName
                },
                new Parameter()
                {
                    ParameterName = TPerson.FirstName,
                    ParameterType = SqlDbType.VarChar,
                    ParameterValue = FirstName
                },
                new Parameter()
                {
                    ParameterName = TPerson.MiddleName,
                    ParameterType = SqlDbType.VarChar,
                    ParameterValue = MiddleName
                }
            };
        }
    }
}
