using System;
using MvvmCross.Binding.BindingContext;

using UIKit;

namespace HelloWorld.iOS
{
	public partial class BillView : BaseView<BillViewModel>
	{
		private UserTableViewDataSource _userTableViewDataSource;

		public BillView() : base("BillView", null)
		{
		}

		public override void ViewDidLoad()
		{
			_userTableViewDataSource = new UserTableViewDataSource(UserTableView);

			base.ViewDidLoad();

			UserTableView.Source = _userTableViewDataSource;
			UserTableView.ReloadData();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void CreateBindings()
		{
			base.CreateBindings();

			var set = this.CreateBindingSet<BillView, BillViewModel>();
			set.Bind(BackButton).To(vm => vm.BackCommand);
            set.Bind(RandomLabel).To(vm => vm.Value).WithConversion("CurrencyValue");
			set.Bind(ProcessButton).To(vm => vm.ReturnValueCommand);
			set.Bind(_userTableViewDataSource).To(vm => vm.arrUsers);
			set.Bind(_userTableViewDataSource)
			   .For(source => source.SelectionChangedCommand)
			   .To(vm => vm.BackCommand);

			set.Apply();
		}
	}
}

