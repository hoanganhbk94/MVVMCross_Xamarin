using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HelloWorld.Converters;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;

namespace HelloWorld.iOS
{
	public class Setup : MvxIosSetup
	{
		public Setup(MvxApplicationDelegate appDelegate, IMvxIosViewPresenter presenter) : base(appDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void InitializeIoC()
		{
			base.InitializeIoC();
			Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
		}

		//protected override IEnumerable<Assembly> ValueConverterAssemblies
		//{
		//	get
		//	{
		//		var toReturn = base.ValueConverterAssemblies as IList;
		//		toReturn.Add(typeof(MvxValueConverter).Assembly);
		//		return (List<Assembly>)toReturn;
		//	}
		//}

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
		{
			base.FillValueConverters(registry);
            registry.AddOrOverwrite("CurrencyValue", new CurrencyValueConverter());
		}
	}
}
