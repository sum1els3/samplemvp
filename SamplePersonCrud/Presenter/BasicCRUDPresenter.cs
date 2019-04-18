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
        public BasicCRUDPresenter(IPerson person, IUser user)
        {
            _person = person;
            _user = user;
            _personlist = new PersonList();
            _userList = new UserList();
        }

        IPerson _person;
        IUser _user;
        IPersonList _personlist;
        IUserList _userList;

        public void CreatePerson()
        {
            NewPersonContext.Create();
        }

        public void UpdatePerson()
        {
            NewPersonContext.Update();
        }

        public void DeletePerson()
        {
            NewPersonContext.Delete();
        }

        private PersonContext NewPersonContext => new PersonContext()
        {
            PersonID = _person.PersonID,
            LastName = _person.LastName,
            FirstName = _person.FirstName,
            MiddleName = _person.MiddleName
        };

        public List<IPerson> GetPeople() =>_personlist.GetPeople();

        public IPerson GetPersonByID(int i) => _personlist.GetPersonByID(i);

        public void CreateUser()
        {
            NewUserContext.Create();
        }

        public void UpdateUser()
        {
            NewUserContext.Update();
        }

        public void DeleteUser()
        {
            NewUserContext.Delete();
        }

        private UserContext NewUserContext => new UserContext()
        {
            UserID = _user.UserID,
            Username = _user.Username,
            Password = _user.Password
        };

        public List<IUser> GetUsers() => _userList.GetUsers();

        public IUser GetUserByID(int id) => _userList.GetUserByID(id);
    }
}
