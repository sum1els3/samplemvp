using SamplePersonCrud.Model.Objects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Presenter
{
    class LoginPresenter
    {
        public LoginPresenter(IUser user)
        {
            _user = user;
            _userList = new UserList();
        }

        IUser _user;
        IUserList _userList;

        public IUser Login()
        {
            return _userList.LogIn(_user.Username, _user.Password);
        }
    }
}
