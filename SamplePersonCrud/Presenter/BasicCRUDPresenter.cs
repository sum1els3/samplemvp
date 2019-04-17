using SamplePersonCrud.Model.Objects;
using SamplePersonCrud.Model.Objects.Person;
using SamplePersonCrud.Model.Objects.User;
using SamplePersonCrud.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Presenter
{
    class BasicCRUDPresenter
    {
        public BasicCRUDPresenter(IPerson person, IUser user, IPersonList personList, IUserList userList)
        {
            _person = person;
            _user = user;
            _personlist = personList;
            _userList = userList;
        }

        IPerson _person;
        IUser _user;
        IPersonList _personlist;
        IUserList _userList;

        public void CreatePerson()
        {
            PersonContext person = NewPersonContext;
            person.Create();
        }

        public void UpdatePerson()
        {
            PersonContext person = NewPersonContext;
            person.Update();
        }

        public void DeletePerson()
        {
            PersonContext person = NewPersonContext;
            person.Delete();
        }

        private PersonContext NewPersonContext
        {
            get => new PersonContext()
            {
                PersonID = _person.PersonID,
                LastName = _person.LastName,
                FirstName = _person.FirstName,
                MiddleName = _person.MiddleName
            };
        }

        public List<Person> GetPeople() =>_personlist.GetPeople();

        public Person GetPersonByID(int i) => _personlist.GetPersonByID(i);

        public void CreateUser()
        {
            UserContext user = NewUserContext;
            user.Create();
        }

        public void UpdateUser()
        {
            UserContext user = NewUserContext;
            user.Update();
        }

        public void DeleteUser()
        {
            UserContext user = NewUserContext;
            user.Delete();
        }

        private UserContext NewUserContext
        {
            get => new UserContext()
            {
                UserID = _user.UserID,
                Username = _user.Username,
                Password = _user.Password
            };
        }

        public List<User> GetUsers() => _userList.GetUsers();

        public User GetUserByID(int id) => _userList.GetUserByID(id);
    }
}
