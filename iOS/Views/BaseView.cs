using System;
using Foundation;
using MvvmCross.iOS.Views;
using UIKit;

namespace HelloWorld.iOS
{
	public abstract class BaseView<TViewModel> : MvxViewController
	{
		public BaseView(string nibName, NSBundle bundle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NavigationController.NavigationBarHidden = true;
            CustomViews();

			CreateBindings();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

        public virtual void CustomViews()
        {
            
        }

		public virtual void CreateBindings()
		{
		}
	}
}

