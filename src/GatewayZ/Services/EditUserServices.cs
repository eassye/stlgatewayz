using GatewayZ.GatewayZDAO;
using GatewayZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayZ.Services
{
    public class EditUserServices
    {
        public void ProcessUpdate(User _user, string email)
        {
            if (_user != null)
            {
                UserDAO userUpdate = new UserDAO();

                if (_user.firstName != null)
                {
                    userUpdate.EditFirstName(_user, email);
                }
                if (_user.lastName != null)
                {
                    userUpdate.EditLastName(_user, email);
                }
                if (_user.email != null)
                {
                    userUpdate.EditEmail(_user, email);
                }
                if(_user.phoneNumber != null)
                {
                    userUpdate.EditPhoneNumber(_user, email);
                }
                if (_user.password != null)
                {
                    userUpdate.EditPassword(_user, email);
                }
            }
        }
    }
}
