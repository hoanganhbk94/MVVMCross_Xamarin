using System;
using HelloWorld.Interfaces.Repositorys;

namespace HelloWorld.Repositorys
{
    public class UserRepository : IUserRepository
    {
        public bool LoginWithUserName(string userName, string password)
        {
            if (userName.Equals("admin") && password.Equals("admin"))
            {
                return true;
            }
            return false;
        }
    }
}
