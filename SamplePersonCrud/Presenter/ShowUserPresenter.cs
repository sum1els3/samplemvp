using SamplePersonCrud.Model.Objects;
using SamplePersonCrud.Model.Objects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Presenter
{
    class ShowUserPresenter
    {
        public ShowUserPresenter(IUser user)
        {
            _user = user;
        }

        IUser _user;

        public void Update()
        {
            NewUser.Update();
        }

        private ICUD NewUser => new UserContext()
        {
            UserID = _user.UserID,
            Username = _user.Username,
            Password = _user.Password,
            Person = _user.Person
        };
    }
}
