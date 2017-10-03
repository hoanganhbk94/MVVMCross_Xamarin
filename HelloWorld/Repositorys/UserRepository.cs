using System;
using HelloWorld.Interfaces.Repositorys;

namespace HelloWorld.Repositorys
{
    public class UserRepository : IUserRepository
    {
        public bool LoginWithUserName(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && userName.Equals("admin") && 
                !string.IsNullOrEmpty(password) && password.Equals("admin"))
            {
                return true;
            }
            return false;
        }
    }
}
