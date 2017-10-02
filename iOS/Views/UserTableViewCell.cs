using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace HelloWorld.iOS
{
	public partial class UserTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("UserTableViewCell");
		public static readonly UINib Nib;

		static UserTableViewCell()
		{
			Nib = UINib.FromName("UserTableViewCell", NSBundle.MainBundle);
		}

		protected UserTableViewCell(IntPtr handle) : base(handle)
		{
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			CreatedBindings();
		}

		private void CreatedBindings()
		{
			var set = this.CreateBindingSet<UserTableViewCell, UserModel>();
			set.Bind(EmailLabel).To(vm => vm.email);
			set.Bind(PasswordLabel).To(vm => vm.password);
			set.Apply();
		}
	}
}
