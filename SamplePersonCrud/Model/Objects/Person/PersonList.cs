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
    class PersonList
    {
        public List<Person> GetPeople()
        {
            List<Person> person = new List<Person>();
            using (SqlConnection con = Database.DatabaseLocation.Database.Connection)
            {
                using (SqlCommand command = new SqlCommand(TPerson.Select, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    con.Open();
                    while (reader.Read())
                    {
                        person.Add
                        (
                            new Person()
                            {
                                ID = int.Parse(reader[TPerson.ID].ToString()),
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
    }
}
