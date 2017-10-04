using System;
using HelloWorld.iOS.Services;
using HelloWorld.ViewModels;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace HelloWorld.iOS.Views
{
    public partial class LoginView : BaseView<LoginViewModel>
    {
        private ProgressHUD _progress;

        public LoginView() : base("LoginView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void CustomViews()
        {
            base.CustomViews();

			// Dismiss keyboard
			this.UserNameTextField.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.PasswordTextField.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

            _progress = new ProgressHUD(View);
        }

        public override void CreateBindings()
        {
            base.CreateBindings();

            var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            set.Bind(UserNameTextField).To(vm => vm.UserName);
            set.Bind(PasswordTextField).To(vm => vm.Password);
            set.Bind(LoginButton).To(vm => vm.LoginWithNormalUserCommand);
            set.Bind(_progress).For(v => v.Visible).To(vm => vm.IsBusy);

            set.Apply();
        }
    }
}

