﻿using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace HelloWorld
{
    public class BillViewModel : BaseViewModel, IMvxViewModel<double, double>
	{
		private readonly IDialogService _dialogService;
        private readonly IMvxNavigationService _navigationService;

        private double _value;
		private UserModel[] _arrUsers = new UserModel[5];

		public BillViewModel(IDialogService dialogService, IMvxMessenger messenger, 
                             IMvxNavigationService navigationService) : base(messenger, navigationService)
		{
			_dialogService = dialogService;
            _navigationService = navigationService;
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

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public void Prepare(double parameter)
        {
            this.Value = parameter;
        }

		public async Task SomeMethodToClose()
		{
            await _navigationService.Close(this, this.Value);
		}
    }
}
