using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Helpers;
using PC_GUI.Mapping;
using PC_GUI.ViewModels.Dialogs;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PC_GUI.ViewModels
{

	public class ViewModelBase : ObservableObject
	{
		string connectionString = "";

		public string Label;

		protected async Task<bool> OpenYesNoDialogAsync(string title, string message)
		{

			var dialogViewModel = new YesNoDialogViewModel(title, message);
			var result = await dialogViewModel.ShowAsync();
			return result;
		}

		protected async Task<bool> OpenInfoDialogAsync(string title, string message)
		{

			var dialogViewModel = new InfoDialogViewModel(title, message);
			var result = await dialogViewModel.ShowAsync();
			return result;
		}


	}
}