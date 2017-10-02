using System;
using System.Threading.Tasks;

namespace HelloWorld
{
	public interface IDialogService
	{
		Task<String> ShowAlertAsync(string title, string message, string[] arrButtonTexts);
	}
}
