using Business.BusinessObjects;
using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PC_GUI.ViewModels.Place
{
	internal partial class PlaceNewViewModel : ViewModelBase
	{
		[ObservableProperty]
		public string _name = "";

		[ObservableProperty]
		public string _nameErrorMessage = "";

		[ObservableProperty]
		public string _errorMessageName = "";

		[ObservableProperty]
		public int _errorMessageNameRowHeight = 0;


		[ObservableProperty]
		public string _description = "";

		[ObservableProperty]
		public string _note = "";

		private MainWindowViewModel mainWindowViewModel;


		public PlaceNewViewModel(MainWindowViewModel main)
		{
			mainWindowViewModel = main;
		}

        [RelayCommand]
        private void GoToDetail(int id)
		{
			mainWindowViewModel.CurrentPage = new PlaceDetailViewModel(mainWindowViewModel, id);
			//mainWindowViewModel.GoToPlaceDetail(id);
		}


        [RelayCommand]
		private void BtnSubmitOnClick()
		{
			var bo = new PlaceBo();
			bo.Name = _name;
			bo.Description = _description;
			bo.Note = _note;

			if(!bo.IsValid())
			{
				ErrorMessageName = bo.GetErrorMessageName();
				if (!string.IsNullOrEmpty(ErrorMessageName))
				{
					ErrorMessageNameRowHeight = 20;
				}

				return;
			}

			//store in db
			var handler = new PlaceHandler();
			handler.InsertPlace(bo);

			//clearing
			var stop = 0;
			NameErrorMessage = "";
			Name = "";
			Description = "";
			Note = "";
								
			mainWindowViewModel.GoToPlaceOverview();
		}

		[RelayCommand]
		internal void ReturnToOverView()
		{
			mainWindowViewModel.GoToPlaceOverview();
		}

	}
}
