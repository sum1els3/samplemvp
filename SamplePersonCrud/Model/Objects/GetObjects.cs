using SamplePersonCrud.Model.Database;
using SamplePersonCrud.Model.DatabaseTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects
{
    static class GetObjects
    {
        //Gets full list of people in the database
        public static List<Person> People()
        {
            List<Person> people = new List<Person>();
            using (SqlConnection con = DatabaseLocation.Connection)
            {
                using (SqlCommand command = new SqlCommand("SelectFromPersonTable", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        people.Add
                        (
                            new Person(int.Parse(reader[TPerson.ID].ToString()))
                            {
                                LastName = reader[TPerson.LastName].ToString(),
                                FirstName = reader[TPerson.FirstName].ToString(),
                                MiddleName = reader[TPerson.MiddleName].ToString()
                            }
                        );
                    }
                    con.Close();
                }
            }
            return people;
        }
    }
}
