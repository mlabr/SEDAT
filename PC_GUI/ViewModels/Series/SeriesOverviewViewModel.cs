using Business.BusinessObjects.CodeList;
using Business.Handlers;
using Business.Handlers.CodeHandler;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Mapping;
using PC_GUI.Models.CodeList;
using PC_GUI.Models.Weapon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Series
{
	internal partial class SeriesOverviewViewModel : ViewModelBase
	{
		private MainWindowViewModel mainWindowViewModel;

		[ObservableProperty]
		private string? _dialogResult;

		[ObservableProperty]
		private string? _seriesNewName;

		public ObservableCollection<SeriesModel> SeriesModelList { get; set; }

		private SeriesHandler handler;

		public SeriesOverviewViewModel(MainWindowViewModel mainView )
		{
			mainWindowViewModel = mainView;

			handler = new SeriesHandler();
			var list = handler.GetAllList();
			var modelList = Mapper.SeriesBoListToSeriesModelList(list);

			foreach (SeriesModel model in modelList)
			{
				model.VisibleIconPath = "resm:PC_GUI.Assets.Icons.eye_inactive.ico?assembly=SEDAT";
				if(model.IsUsed)
				{
					//model.VisibleIconPath = "resm:PC_GUI.Assets.Icons.eye_active.ico?assembly=SEDAT";
					model.VisibleIconPath = "Assets/Icons/eye_active.ico";
					//model.VisibleIconPath = "resm:PC_GUI.Assets.Icons.eye_inactive.ico?assembly=SEDAT";
				}
			}

			SeriesModelList = new ObservableCollection<SeriesModel>(modelList);


		}

		[RelayCommand]
		private void AddNewSeries()
		{
			var bo = new SeriesBo();
			bo.Name = SeriesNewName;
			handler.InsertSeries(bo);

			//reset page to update
			mainWindowViewModel.CurrentPage = new SeriesOverviewViewModel(mainWindowViewModel);
		}

		[RelayCommand]
		private void TogleVisibility(int id)
		{
			if(id <= 1)
			{
				//no hiding default item allowed, hehe
				return;
			}

			handler.TogleVisibility(id);
		}

		[RelayCommand]
		private void Delete(int id)
		{
			if (id <= 1)
			{
				//no deleting default item allowed
				return;
			}

			//handler.Delete(id);
		}

	}
}
