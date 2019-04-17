using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.User
{
    interface IUser
    {
        int UserID { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
