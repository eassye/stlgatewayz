using GatewayZ.GatewayZDAO;

namespace GatewayZ.Services
{
    public class MembersServices
    {
        public void gatherUsersByCompany()
        {
            UserDAO data = new UserDAO();

            string club = "GatewayZ";

            data.UsersList(club);
        }
    }
}
