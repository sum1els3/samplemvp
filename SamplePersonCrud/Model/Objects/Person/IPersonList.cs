using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects.Person
{
    interface IPersonList
    {
        List<Person> GetPeople();
        Person GetPersonByID(int id);
    }
}
