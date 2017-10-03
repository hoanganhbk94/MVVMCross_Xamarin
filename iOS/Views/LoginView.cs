using System;
using HelloWorld.ViewModels;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace HelloWorld.iOS.Views
{
    public partial class LoginView : BaseView<LoginViewModel>
    {
        public LoginView() : base("LoginView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void CreateBindings()
        {
            base.CreateBindings();

            var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            set.Bind(UserNameTextField).To(vm => vm.UserName);
            set.Bind(PasswordTextField).To(vm => vm.Password);
            set.Bind(LoginButton).To(vm => vm.LoginWithNormalUserCommand);

            set.Apply();
        }
    }
}

