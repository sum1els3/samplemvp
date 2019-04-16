using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.Person
{
    interface IPerson
    {
        int ID { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string FullName { get; }
    }
}
