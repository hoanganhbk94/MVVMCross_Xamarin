using System;
using HelloWorld.Interfaces.Repositorys;

namespace HelloWorld
{
	public class UserService : IUserService
	{
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool LoginWithUserName(string userName, string password)
        {
            return _userRepository.LoginWithUserName(userName, password);
        }
	}
}
