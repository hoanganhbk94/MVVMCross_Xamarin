using System;
namespace HelloWorld.Interfaces.Repositorys
{
    public interface IUserRepository
    {
        bool LoginWithUserName(string userName, string password);
    }
}
