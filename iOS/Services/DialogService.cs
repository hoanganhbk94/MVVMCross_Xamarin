using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using UIKit;

namespace HelloWorld.iOS
{
	public class DialogService : IDialogService
	{
		public Task<String> ShowAlertAsync(string title, string message, string[] arrButtonTexts)
		{
			var taskCompletionSource = new TaskCompletionSource<String>();

			UIApplication.SharedApplication.InvokeOnMainThread(() =>
			{
				var alertController = UIAlertController.Create(title, message,
																 UIAlertControllerStyle.Alert);
				foreach (string buttonText in arrButtonTexts)
				{ 
					alertController.AddAction(UIAlertAction.Create(buttonText, UIAlertActionStyle.Default, action =>
					{
						taskCompletionSource.SetResult(buttonText);
					}));
				}
					
				UIViewController rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;
				rootController.PresentViewController(alertController, true, null);
			});

			return taskCompletionSource.Task;
		}
	}
}
