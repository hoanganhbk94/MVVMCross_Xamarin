using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace HelloWorld
{
	public class TipViewModel : BaseViewModel
	{
		private readonly ICalculationService _calculation;

		private double _subTotal;
		private int _generosity;
		private double _tip;

		public TipViewModel(ICalculationService calculation, IMvxNavigationService navigationService) : base(navigationService)
		{
			_calculation = calculation;
			InitializeMessager();
		}

		private void InitializeMessager()
		{
			Mvx.Trace("Subscribe data");
		}

		public override async void Start()
		{
			_subTotal = 100;
			_generosity = 10;
			Recalculate();
			base.Start();

			await ReloadDataAsync();
		}

		public double SubTotal
		{
			get { return _subTotal; }
			set
			{
				_subTotal = value;
				RaisePropertyChanged(() => SubTotal);
				Recalculate();
			}
		}

		public int Generosity
		{
			get { return _generosity; }
			set
			{
				_generosity = value;
				RaisePropertyChanged(() => Generosity);
				Recalculate();
			}
		}

		public double Tip
		{
			get { return _tip; }
			set
			{
				_tip = value;
				RaisePropertyChanged(() => Tip);
			}
		}

		private void Recalculate()
		{
			Tip = _calculation.TipAmount(SubTotal, Generosity);
		}

		//public MvxCommand GoToBillCommand
		//{
		//	get
		//	{
  //              return new MvxCommand(() =>
		//		{
  //                  double value = _tip;
  //                  ShowViewModel<BillViewModel>(new { value });
		//		});
		//	}
		//}

		public MvxCommand GoToBillCommand => new MvxCommand(async () =>
		{
			await SendData();
		});

		public override void Prepare()
		{
			//Do anything before navigating to the view
		}

		public async Task SendData()
		{
            var result = await NavigationService.Navigate<BillViewModel, double, double>(Tip);

            Mvx.Trace("Result return: " + result);
			//Do something with the result MyReturnObject that you get back
		}

        public MvxCommand LogOutCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
	}
}
