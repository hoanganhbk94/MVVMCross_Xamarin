using System;
using Foundation;
using UIKit;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;

namespace HelloWorld.iOS
{
	public class UserTableViewDataSource : MvxTableViewSource
	{
		public UserTableViewDataSource(UITableView tableView) : base(tableView)
		{
			tableView.RegisterNibForCellReuse(UserTableViewCell.Nib, UserTableViewCell.Key);
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return ItemsSource.Count();
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
			var cell = (UserTableViewCell)tableView.DequeueReusableCell(UserTableViewCell.Key);
			return cell;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 65;
		}

		protected override object GetItemAt(NSIndexPath indexPath)
		{
			return ItemsSource?.ElementAt(indexPath.Row);
		}
	}
}
