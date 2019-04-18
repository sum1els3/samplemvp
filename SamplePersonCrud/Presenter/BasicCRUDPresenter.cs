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
        public BasicCRUDPresenter(IUser user)
        {
            _user = user;
            _userList = new UserList();
        }
        
        IUser _user;
        IUserList _userList;

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
            Password = _user.Password,
            Person = new Person()
            {
                PersonID = _user.Person.PersonID,
                LastName = _user.Person.LastName,
                FirstName = _user.Person.FirstName,
                MiddleName = _user.Person.MiddleName
            }
        };

        public List<IUser> GetUsers() => _userList.GetUsers();

        public IUser GetUserByID(int id) => _userList.GetUserByID(id);
    }
}
