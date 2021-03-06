﻿using SamplePersonCrud.Model.Database.DatabaseLocation;
using SamplePersonCrud.Model.Database.DatabaseServices;
using SamplePersonCrud.Model.Database.DatabaseTables;
using SamplePersonCrud.Model.Objects.Person;
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
            StoredProcedure storedProcedure = new StoredProcedure
            {
                StoredProcedureName = TUser.Select
            };
            using (IDataReader reader = storedProcedure.ExecuteDataReader())
            {
                while (reader.Read())
                {
                    IPerson person = new Person.Person()
                    {
                        PersonID = int.Parse(reader[TUser.PersonID].ToString()),
                        LastName = reader[TPerson.LastName].ToString(),
                        FirstName = reader[TPerson.FirstName].ToString(),
                        MiddleName = reader[TPerson.MiddleName].ToString()
                    };
                    IUser user = new User()
                    {
                        UserID = int.Parse(reader[TUser.UserID].ToString()),
                        Username = reader[TUser.Username].ToString(),
                        Password = reader[TUser.Password].ToString(),
                        Person = person
                    };
                    users.Add(user);
                }
                reader.Close();
            }
            return users;
        }

        public IUser LogIn(string username, string password) => GetUsers().Find(item => item.Username.Equals(username) && item.Password.Equals(password));
    }
}
