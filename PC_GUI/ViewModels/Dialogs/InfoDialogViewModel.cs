using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Dialogs
{
	internal partial class InfoDialogViewModel : ViewModelBase
	{
		private static InfoDialogView? _activeDialog; // Singleton instance dialogu


		[ObservableProperty]
		private string _title;

		[ObservableProperty]
		private string _message;

		public InfoDialogViewModel(string title, string message)
		{

			_title = title;
			_message = message;
		}

		private TaskCompletionSource<bool>? _tcs = new TaskCompletionSource<bool>();

		public async Task<bool> ShowAsync()
		{
			if (_activeDialog != null)
			{
				//There is only one!
				return await _tcs!.Task;
			}

			_activeDialog = new InfoDialogView { DataContext = this };
			_activeDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			_activeDialog.Topmost = true;
			_activeDialog.Show();

			// Vrátíme Task, který bude dokončen při volání "SelectYes" nebo "SelectNo"
			return await _tcs.Task;
		}


		[RelayCommand]
		private void SelectOk()
		{
			// Nastavíme výsledek dialogu na true a ukončíme dialog
			_tcs.SetResult(true);
			CloseDialog();
		}

		private void CloseDialog()
		{
			// Ukončíme dialogové okno
			if (App.Current.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
			{
				var activeWindow = desktop.Windows.FirstOrDefault(w => w.DataContext == this);
				activeWindow?.Close();
				_activeDialog = null;
			}
		}
	}
}
