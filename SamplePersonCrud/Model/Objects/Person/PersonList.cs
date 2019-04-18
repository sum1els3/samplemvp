using SamplePersonCrud.Model.Database.DatabaseLocation;
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
            List<IPerson> person = new List<IPerson>();
            using (IDbConnection con = DatabaseConnection.Connection)
            {
                using (IDbCommand command = DatabaseConnection.Command(TPerson.Select))
                {
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    IDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        person.Add
                        (
                            new PersonContext()
                            {
                                PersonID = int.Parse(reader[TPerson.PersonID].ToString()),
                                LastName = reader[TPerson.LastName].ToString(),
                                FirstName = reader[TPerson.FirstName].ToString(),
                                MiddleName = reader[TPerson.MiddleName].ToString()
                            }
                        );
                    }
                    con.Close();
                }
            }
            return person;
        }

        public IPerson GetPersonByID(int id) => GetPeople().Find(item => item.PersonID == id);
    }
}
