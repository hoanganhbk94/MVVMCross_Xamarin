using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Plugins.WebBrowser;

namespace HelloWorld
{
    public class BaseViewModel : MvxViewModel, IDisposable, IMvxViewModel
	{
        protected IMvxNavigationService NavigationService;

		public BaseViewModel()
		{ 
		}

		public BaseViewModel(IMvxNavigationService navigationService)
		{
            this.NavigationService = navigationService;
		}

		protected virtual void ReloadData()
		{
			try
			{
				InitializeSync();
			}
			catch (Exception ex)
			{
				Mvx.Error(ex.Message);
			}
		}

		protected virtual void InitializeSync()
		{ 
			
		}

		protected async Task ReloadDataAsync()
		{ 
			try
			{
				Mvx.Trace("ReloadDataAsync");
				await InitializeAsync();
			}
			catch (Exception ex)
			{
				Mvx.Error(ex.Message);
			}
		}

		protected virtual Task InitializeAsync()
		{
			return Task.FromResult(0);
		}

		public IMvxCommand BackCommand
		{ 
			get
			{ 
				return new MvxCommand(() => Close(this));
			}
		}

		protected void ShowWebPage(string url)
		{
			if (!string.IsNullOrEmpty(url))
			{
				var task = Mvx.Resolve<IMvxWebBrowserTask>();
				try
				{
					task.ShowWebPage(url);
				}
				catch (Exception exception)
				{
					Mvx.Trace(exception.Message);
				}
			}
		}

		public void Dispose()
		{
		}
	}
}
