using SamplePersonCrud.Model.Objects;
using SamplePersonCrud.Model.Objects.Person;
using SamplePersonCrud.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Presenter
{
    class MainPresenter
    {
        public MainPresenter(IPerson person, IPersonList personList)
        {
            _person = person;
            _personlist = personList;
        }

        IPerson _person;
        IPersonList _personlist;

        public void Insert()
        {
            PersonContext person = new PersonContext()
            {
                ID = int.Parse(_person.ID.ToString()),
                LastName = _person.LastName,
                FirstName = _person.FirstName,
                MiddleName = _person.MiddleName
            };
            person.Create();
        }

        public void Update()
        {
            PersonContext person = new PersonContext()
            {
                ID = int.Parse(_person.ID.ToString()),
                LastName = _person.LastName,
                FirstName = _person.FirstName,
                MiddleName = _person.MiddleName
            };
            person.Update();
        }

        public void Delete()
        {
            PersonContext person = new PersonContext()
            {
                ID = int.Parse(_person.ID.ToString()),
                LastName = _person.LastName,
                FirstName = _person.FirstName,
                MiddleName = _person.MiddleName
            };
            person.Delete();
        }

        public List<Person> GetPeople()
        {
            return _personlist.GetPeople();
        }

        public Person GetPersonByID(int i)
        {
            return _personlist.GetPersonByID(i);
        }
    }
}
