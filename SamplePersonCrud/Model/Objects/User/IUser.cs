﻿using SamplePersonCrud.Model.Objects.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.User
{
    public interface IUser
    {
        int UserID { get; set; }
        string Username { get; set; }
        string Password { get; set; }

        IPerson Person { get; set; }
    }
}
