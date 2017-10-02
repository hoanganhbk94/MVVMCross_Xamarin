using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace HelloWorld
{
	public class BillViewModel : BaseViewModel
	{
		private double _value;
		private IDialogService _dialogService;
		private UserModel[] _arrUsers = new UserModel[5];

		public BillViewModel(IDialogService dialogService, IMvxMessenger messenger) : base(messenger)
		{
			_dialogService = dialogService;
		}

		public void Init(double value)
		{
			_value = value;
		}

		public override void Start()
		{
			base.Start();
		}

		public double Value
		{ 
			get { return _value; }
			set
			{
				_value = value;
				RaisePropertyChanged(() => Value);
			}
		}

		public UserModel[] arrUsers
		{ 
			get
			{
				for (int i = 0; i < 5; i++)
				{
					UserModel user = new UserModel("email" + i, "password" + i);
					_arrUsers[i] = user;
				}
				return _arrUsers;
			}
		}

		public MvxCommand ProcessCommand
		{ 
			get
			{
				return new MvxCommand(async() =>
				{
					string[] arrButtonTexts = { "Cancel", "Ok" };
					String action = await _dialogService.ShowAlertAsync("Warning", 
					                                                    "Do you want to process this value?", 
					                                                    arrButtonTexts);
					Mvx.Trace("Action: " + action);
					if (action.Equals(arrButtonTexts[1]))
					{
						Close(this);
					}
				});
			}
		}

		public MvxCommand OpenWebCommand
		{ 
			get
			{
				return new MvxCommand(() => ShowWebPage("https://stackoverflow.com"));
			}
		}

		public MvxCommand ReturnValueCommand
		{ 
			get
			{
				return new MvxCommand(() =>
				{
					Mvx.Trace("Publish data");
					Messenger.Publish(new DataMessage(this, Value));
					Close(this);
				});
			}
		}

	}
}
