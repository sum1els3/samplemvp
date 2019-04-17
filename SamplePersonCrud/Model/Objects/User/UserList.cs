using SamplePersonCrud.Model.Database.DatabaseTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.User
{
    class UserList : IUserList
    {
        public User GetUserByID(int id) => GetUsers().Find(item => item.UserID == id);

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = Database.DatabaseLocation.Database.Connection)
            {
                using (SqlCommand command = new SqlCommand(TUser.Select, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add
                        (
                            new User()
                            {
                                UserID = int.Parse(reader[TUser.UserID].ToString()),
                                Username = reader[TUser.Username].ToString(),
                                Password = reader[TUser.Password].ToString()
                            }
                        );
                    }
                    con.Close();
                }
            }
            return users;
        }

        public User LogIn(string username, string password) => GetUsers().Find(item => item.Username.Equals(username) && item.Password.Equals(password));
    }
}
