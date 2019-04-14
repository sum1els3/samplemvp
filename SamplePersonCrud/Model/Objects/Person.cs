using SamplePersonCrud.Model.DatabaseServices;
using SamplePersonCrud.Model.DatabaseTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects
{
    class Person : ICUD
    {
        public Person(int id = 0)
        {
            ID = id;
        }

        public int ID { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName => string.Format("{0}, {1} {2}.", LastName, FirstName, MiddleName);

        public void Create()
        {
            if (ID == 0)
            {
                StoredProcedure storedProcedure = new StoredProcedure();
                storedProcedure.StoredProcedureName = ProcedureName.InsertStoredProcedureName(TPerson.TableName);
                storedProcedure.Parameters.AddRange(GetParameters.FindAll(item => !item.ParameterName.Equals(TPerson.ID)));
                storedProcedure.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Data already in the database");
            }
        }

        public void Delete()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = ProcedureName.DeleteStoredProcedureName(TPerson.TableName);
            storedProcedure.Parameters.Add(GetParameters.Find(item => item.ParameterName.Equals(TPerson.ID)));
            storedProcedure.ExecuteNonQuery();
        }

        public void Update()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.StoredProcedureName = ProcedureName.UpdateStoredProcedureName(TPerson.TableName);
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
