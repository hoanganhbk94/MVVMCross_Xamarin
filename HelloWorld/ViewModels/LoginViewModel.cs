using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace HelloWorld.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        private string _userName;
        private string _password;

        public LoginViewModel(IMvxNavigationService navigationService, IDialogService dialogService,
                              IUserService userService) : base(navigationService, dialogService)
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

        public MvxCommand LoginWithNormalUserCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if (_userService.LoginWithUserName(UserName, Password))
                    {
                        NavigationService.Navigate<TipViewModel>();
                    }
                    else
                    {
                        string[] arrTexts = { "OK" };
                        DialogService.ShowAlertAsync("Warning",
                                                    "Username and password isn't valid",
                                                     arrTexts);
                    }
                });
            }
        }
    }
}
