using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.User
{
    interface IUserList
    {
        List<User> GetUsers();
        User GetUserByID(int id);
        User LogIn(string username, string password);
    }
}
