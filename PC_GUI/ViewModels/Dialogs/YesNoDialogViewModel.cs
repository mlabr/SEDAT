﻿using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Views.Dialogs;
using PC_GUI.Views.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Dialogs
{
	internal partial class YesNoDialogViewModel : ViewModelBase
	{

		private static YesNoDialogView? _activeDialog; // Singleton instance dialogu


		[ObservableProperty]
		private string _title;

		[ObservableProperty]
		private string _message;

		public YesNoDialogViewModel(string title, string message)
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

			_activeDialog = new YesNoDialogView { DataContext = this };
			_activeDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			_activeDialog.Topmost = true;
			_activeDialog.Show();

			// Vrátíme Task, který bude dokončen při volání "SelectYes" nebo "SelectNo"
			return await _tcs.Task;
		}


		[RelayCommand]
		private void SelectYes()
		{
			// Nastavíme výsledek dialogu na true a ukončíme dialog
			_tcs.SetResult(true);
			CloseDialog();
		}

		[RelayCommand]
		private void SelectNo()
		{
			// Nastavíme výsledek dialogu na false a ukončíme dialog
			_tcs.SetResult(false);
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
