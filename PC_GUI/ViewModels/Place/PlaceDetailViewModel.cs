using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Mapping;
using PC_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Place
{
	internal partial class PlaceDetailViewModel : ViewModelBase
	{
		private MainWindowViewModel mainWindowViewModel;
		private PlaceModel model;

		[ObservableProperty]
		private string _description = "";

		[ObservableProperty]
		private string _name ="";
		
		[ObservableProperty]
		private string _note = "";

		public PlaceDetailViewModel(MainWindowViewModel main, int id)
		{
			var handler = new PlaceHandler();
			mainWindowViewModel = main;
			model = Mapper.PlaceBoToPlaceModel(handler.GetById(id));
			_description = model.Description;
			_name = model.Name;
			_note = model.Note;
		}


		[RelayCommand]
		internal void ReturnToOverView()
		{
			mainWindowViewModel.GoToPlaceOverview();
		}


		[RelayCommand]
		internal async void ConfirmChanges()
		{

			bool isActionConfirmed = await OpenYesNoDialogAsync("Warning", "Are you sure to store changes into database?");
			if (isActionConfirmed)
			{
				model.Name = _name;
				model.Description = _description;
				model.Note = _note;
				var handler = new PlaceHandler();
				handler.Update(Mapper.PlaceModelToPlaceBo(model));
				mainWindowViewModel.GoToPlaceOverview();
			}
		}
	}
}
