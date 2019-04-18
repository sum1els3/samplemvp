using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamplePersonCrud.Model.Objects.Person;

namespace SamplePersonCrud.Model.Objects.User
{
    class User : IUser
    {
        public User()
        {
            UserID = 0;
            Person = new PersonContext();
        }

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IPerson Person { get; set; }
    }
}
