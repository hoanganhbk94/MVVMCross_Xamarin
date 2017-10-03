using System;
namespace HelloWorld
{
	public interface IUserService
	{
        bool LoginWithUserName(string userName, string password);
	}
}
