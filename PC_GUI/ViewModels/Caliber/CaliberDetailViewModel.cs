using Business.Handlers;
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

		WeaponHandler handler;

		public CaliberDetailViewModel(MainWindowViewModel main, int id)
		{
			handler = new WeaponHandler();
			mainWindowViewModel = main;
			var bo = handler.GetCaliberById(id);
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
				//model.Name = _name;
				//model.Description = _description;
				//model.Note = _note;
				//var handler = new PlaceHandler();
				//handler.Update(Mapper.PlaceModelToPlaceBo(model));
				//mainWindowViewModel.GoToPlaceOverview();
			}
		}


		partial void OnIsEditEnabledChanged(bool oldValue, bool newValue)
		{
			IsFieldReadOnly = !newValue;
		}
	}
}
