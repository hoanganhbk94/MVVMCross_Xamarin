using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace HelloWorld
{
	public class TipViewModel : BaseViewModel
	{
		private readonly ICalculation _calculation;

		private double _subTotal;
		private int _generosity;
		private double _tip;

		public TipViewModel(ICalculation calculation, IMvxMessenger messager) : base(messager)
		{
			_calculation = calculation;
			InitializeMessager();
		}

		private void InitializeMessager()
		{
			Mvx.Trace("Subscribe data");
			Messenger.Subscribe<DataMessage>(async message => await ReloadDataAsync());
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

		public MvxCommand GoToBillCommand
		{
			get
			{
				return new MvxCommand(() =>
				{
					double value = _tip;
					ShowViewModel<BillViewModel>(new { value });
				});
			}
		}
	}
}
