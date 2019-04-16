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
    class MainFormPresenter
    {
        public MainFormPresenter(IPerson person)
        {
            _person = person;
        }

        IPerson _person;

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
    }
}
