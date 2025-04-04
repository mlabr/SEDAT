using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using PC_GUI.Helpers;
using PC_GUI.Models;
using PC_GUI.ViewModels.Dialogs;
using PC_GUI.Views;
using PC_GUI.Views.Place;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Place
{
	internal partial class PlaceOverviewViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string? _dialogResult;


		public ObservableCollection<PlaceModel> PlaceModelList { get; set; }

		//public Interaction<>

		private MainWindowViewModel mainWindowViewModel;

		private bool isActionConfirmed = false;

		public PlaceOverviewViewModel(MainWindowViewModel mainWindow)
		{
			Label = MenuHelper.Manage.PlacesOverview;
			
			mainWindowViewModel = mainWindow;
			//get list here
			//placeHandle.GetAll()

			var handler = new PlaceHandler();

			var list = handler.GetAll();

			var modelList = new List<PlaceModel>();
			foreach (var item in list)
			{
				var model = new PlaceModel();
				model.DbId = item.DbId;
				model.Name = item.Name;
				model.Description = item.Description;
				model.Note = item.Note;
				model.IsUsed = item.IsUsed;
				modelList.Add(model);
			}

			//remap 
			PlaceModelList = new ObservableCollection<PlaceModel>(modelList);
		}


		[RelayCommand]
		protected void NewPlace()
		{
			mainWindowViewModel.CurrentPage = new PlaceNewViewModel(mainWindowViewModel);
		}


		[RelayCommand]
		protected void GoToDetail(int id)
		{
			mainWindowViewModel.CurrentPage = new PlaceDetailViewModel(mainWindowViewModel, id);
			//mainWindowViewModel.GoToPlaceDetail(id);
		}

        [RelayCommand]
        protected async void Delete(int id)
        {
			//TODO: Check to avoid deleting object used in another db record.
			var item = PlaceModelList.Where(x => x.DbId == id).FirstOrDefault();
			//item.Name;
			isActionConfirmed = await OpenYesNoDialogAsync("Warning", $"Are you sure to delete \"{item.Name}\"?");
			if (isActionConfirmed)
			{ 
				var handler = new PlaceHandler();
				handler.Delete(id);
				mainWindowViewModel.GoToPlaceOverview();
			}
		}
    }
}
