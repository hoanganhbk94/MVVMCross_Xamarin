// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace HelloWorld.iOS
{
	[Register ("BillView")]
	partial class BillView
	{
		[Outlet]
		UIKit.UIButton BackButton { get; set; }

		[Outlet]
		UIKit.UIButton ProcessButton { get; set; }

		[Outlet]
		UIKit.UILabel RandomLabel { get; set; }

		[Outlet]
		UIKit.UITableView UserTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (UserTableView != null) {
				UserTableView.Dispose ();
				UserTableView = null;
			}

			if (BackButton != null) {
				BackButton.Dispose ();
				BackButton = null;
			}

			if (ProcessButton != null) {
				ProcessButton.Dispose ();
				ProcessButton = null;
			}

			if (RandomLabel != null) {
				RandomLabel.Dispose ();
				RandomLabel = null;
			}
		}
	}
}
