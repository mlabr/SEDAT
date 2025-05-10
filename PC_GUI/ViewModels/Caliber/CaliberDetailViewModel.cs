using Business.BusinessObjects.CodeList;
using Business.Handlers.WeaponHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Helpers;
using PC_GUI.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Caliber
{
	internal partial class CaliberDetailViewModel : ViewModelBase
	{
		private MainWindowViewModel mainWindowViewModel;

		[ObservableProperty]
		private string _description = "";

		[ObservableProperty]
		private string _name = "";

		[ObservableProperty]
		private string _note = "";

		[ObservableProperty]
		private bool _isEditEnabled = false;

		[ObservableProperty]
		private bool _isFieldReadOnly = true;

		CaliberHandler handler;

		CaliberBo bo;

		public CaliberDetailViewModel(MainWindowViewModel main, int id)
		{
			handler = new CaliberHandler();
			mainWindowViewModel = main;
			bo = handler.GetCaliberById(id);
			Name = bo.Name;
			Description = bo.Description;
			Note = bo.Note;
		}

		[RelayCommand]
		internal void ReturnToOverView()
		{
			mainWindowViewModel.ChangeView(MenuHelper.Manage.Caliber.Overview);
		}


		[RelayCommand]
		internal async void ConfirmChanges()
		{

			bool isActionConfirmed = await OpenYesNoDialogAsync("Warning", "Are you sure to store changes into database?");
			if (isActionConfirmed)
			{
				bo.Name = Name;
				bo.Description = Description;
				bo.Note = Note;
				handler.Update(bo);
				ReturnToOverView();
			}
		}


		partial void OnIsEditEnabledChanged(bool oldValue, bool newValue)
		{
			IsFieldReadOnly = !newValue;
		}
	}
}
