using System;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace HelloWorld
{
	public class App : MvxApplication
    {
        public override void Initialize()
        {
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();
			Mvx.RegisterType<ICalculation, Calculation>();
			RegisterNavigationServiceAppStart<TipViewModel>();
        }
	}
}
