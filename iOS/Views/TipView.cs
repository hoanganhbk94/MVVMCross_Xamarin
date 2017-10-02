using System;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace HelloWorld.iOS
{
	public partial class TipView : BaseView<TipViewModel>
	{
		public TipView() : base("TipView", null)
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

		public override void CreateBindings()
		{
			base.CreateBindings();

			var set = this.CreateBindingSet<TipView, TipViewModel>();
			set.Bind(TipLabel).To(vm => vm.Tip);
			set.Bind(SubTotalTextField).To(vm => vm.SubTotal);
			set.Bind(GenerositySlider).To(vm => vm.Tip);
			set.Bind(BillButton).To(vm => vm.GoToBillCommand);
			set.Apply();
		}
	}
}

