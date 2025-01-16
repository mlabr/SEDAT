 using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Business.Mapping;
using Microsoft.Extensions.DependencyInjection;
using PC_GUI.ViewModels;
using PC_GUI.ViewModels.CodeList;
using PC_GUI.Views;
using PC_GUI.Views.CodeList;
using System;

namespace PC_GUI
{
	public partial class App : Application
	{
		//private IServiceProvider _serviceProvider;

		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);


			// DI container init
			//_serviceProvider = ConfigureServices();
		}

		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				//var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
				//mainWindow.DataContext = new MainWindowViewModel();

				//desktop.MainWindow = mainWindow;


				desktop.MainWindow = new MainWindow
				{
					DataContext = new MainWindowViewModel(),
				};
			}

			base.OnFrameworkInitializationCompleted();
		}

		//private IServiceProvider ConfigureServices()
		//{
		//	// Vytvoøíme nový DI kontejner
		//	var services = new ServiceCollection();

		//	// Registrace Avalonia Views (MainWindow v tomto pøípadì)
		//	services.AddTransient<MainWindow>();
		//	services.AddTransient<CSightsOverviewView>();
			
		//	services.AddTransient<MainWindowViewModel>();
		//	services.AddTransient<CSightsOverviewViewModel>();


		//	// Registrace služeb
		//	services.AddTransient<MapperService>();

		//	// Registrace AutoMapper
		//	services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
		//	//services.AddAutoMapper(typeof(MappingProfile));

		//	return services.BuildServiceProvider();
		//}
	}
}