using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.User
{
    interface IUserList
    {
        List<IUser> GetUsers();
        IUser GetUserByID(int id);
        IUser LogIn(string username, string password);
    }
}
