using GatewayZ.GatewayZDAO;
using GatewayZ.Models;

namespace GatewayZ.Services
{
    public class EditUserServices
    {
        private UserDAO _userDao;

        public EditUserServices(UserDAO userDao)
        {
            _userDao = userDao;
        }
        public void ProcessUpdate(User _user, string email)
        {
            if (_user != null)
            {
                if (_user.firstName != null)
                {
                    _userDao.EditFirstName(_user, email);
                }
                if (_user.lastName != null)
                {
                    _userDao.EditLastName(_user, email);
                }
                if (_user.email != null)
                {
                    _userDao.EditEmail(_user, email);
                }
                if(_user.phoneNumber != null)
                {
                    _userDao.EditPhoneNumber(_user, email);
                }
                if (_user.password != null)
                {
                    _userDao.EditPassword(_user, email);
                }
            }
        }

        public void UpdateUserPassword(User _user)
        {
            if(_user.email != null && _user.answerOne != null && _user.answerTwo != null && _user.password != null)
            {
                _userDao.ChangePassword(_user);
            }
        }
    }
}
