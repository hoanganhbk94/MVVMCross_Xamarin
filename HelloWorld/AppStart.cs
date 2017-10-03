using System;
using HelloWorld.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace HelloWorld
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;

        public AppStart(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Start(object hint = null)
        {
            _navigationService.Navigate<LoginViewModel>();
        }
    }
}
