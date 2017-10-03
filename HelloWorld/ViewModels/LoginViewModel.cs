using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace HelloWorld.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        private string _userName;
        private string _password;

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public MvxCommand LoginWithNormalUserCommand => new MvxCommand(() =>
                                                                      {
                                                                          _userService.LoginWithUserName(UserName, Password);
                                                                      });
    }
}
