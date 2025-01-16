using Avalonia;
using Avalonia.Logging;
using Business.Handlers;
using PC_GUI;
using System;
using System.IO;

namespace PC_GUI
{
	internal class Program
	{
		// Initialization code. Don't use any Avalonia, third-party APIs or any
		// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
		// yet and stuff might break.
		[STAThread]
		public static void Main(string[] args)
		{
			//Db exist check
			var dbdfile = "testDb.db"; // TODO: config file
			string path = Directory.GetCurrentDirectory();
			if (!File.Exists(dbdfile))
			{
				var handler = new DbHandler(dbdfile);
				handler.CreateSqliteDatabase();
			}


			BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
		}



		// Avalonia configuration, don't remove; also used by visual designer.
		public static AppBuilder BuildAvaloniaApp()
			=> AppBuilder.Configure<App>()
				.UsePlatformDetect()
				.LogToTrace();


	}
}