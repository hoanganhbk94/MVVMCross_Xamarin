using System;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using HelloWorld.ViewModels;

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

            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

			RegisterNavigationServiceAppStart<LoginViewModel>();
        }
	}
}
