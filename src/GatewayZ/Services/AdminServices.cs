using GatewayZ.GatewayZDAO;
using GatewayZ.Models;

namespace GatewayZ.Services
{
    public class AdminServices
    {
        public void ProcessUpdate(AdminPageModel _data)
        {
            if (_data.User != null)
            {
                UserDAO userUpdate = new UserDAO();

                if (_data.User.club != null)
                {
                    userUpdate.SaveMemberClub(_data.User);
                }
                if (_data.User.userType != null)
                {
                    userUpdate.SaveUserType(_data.User);
                }
                if (_data.User.isMember != null)
                {
                    userUpdate.SaveMemberStatus(_data.User);
                }
            }

            if (_data.Club != null)
            {
                ClubDAO clubUpdate = new ClubDAO();

                clubUpdate.SaveClub(_data.Club);
            }
        }
    }
}
