using System;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;

namespace HelloWorld
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterType<ICalculation, Calculation>();
			var appStart = new MvxAppStart<TipViewModel>();
			Mvx.RegisterSingleton<IMvxAppStart>(appStart);
		}
	}
}
