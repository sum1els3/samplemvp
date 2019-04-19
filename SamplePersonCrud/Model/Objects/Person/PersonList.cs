using SamplePersonCrud.Model.Database.DatabaseLocation;
using SamplePersonCrud.Model.Database.DatabaseServices;
using SamplePersonCrud.Model.Database.DatabaseTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.Person
{
    class PersonList : IPersonList
    {
        public List<IPerson> GetPeople()
        {
            List<IPerson> people = new List<IPerson>();
            StoredProcedure storedProcedure = new StoredProcedure
            {
                StoredProcedureName = TPerson.Select
            };
            using (IDataReader reader = storedProcedure.ExecuteDataReader())
            {
                while (reader.Read())
                {
                    IPerson person = new PersonContext()
                    {
                        PersonID = int.Parse(reader[TPerson.PersonID].ToString()),
                        LastName = reader[TPerson.LastName].ToString(),
                        FirstName = reader[TPerson.FirstName].ToString(),
                        MiddleName = reader[TPerson.MiddleName].ToString()
                    };
                    people.Add(person);
                }
                reader.Close();
            }
            return people;
        }

        public IPerson GetPersonByID(int id) => GetPeople().Find(item => item.PersonID == id);
    }
}
