using SamplePersonCrud.Model.Database.DatabaseLocation;
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
        public IUser GetUserByID(int id) => GetUsers().Find(item => item.UserID == id);

        public List<IUser> GetUsers()
        {
            List<IUser> users = new List<IUser>();
            using (IDbConnection con = DatabaseConnection.Connection)
            {
                using (IDbCommand command = DatabaseConnection.Command(TUser.Select))
                {
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    IDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add
                        (
                            new UserContext()
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

        public IUser LogIn(string username, string password) => GetUsers().Find(item => item.Username.Equals(username) && item.Password.Equals(password));
    }
}
