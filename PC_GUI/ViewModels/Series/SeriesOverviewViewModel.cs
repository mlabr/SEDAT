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

		public ObservableCollection<SeriesModel> EventModelList { get; set; }

		private SeriesHandler handler;

		public SeriesOverviewViewModel(MainWindowViewModel mainView )
		{
			mainWindowViewModel = mainView;

			handler = new SeriesHandler();
			var list = handler.GetUsedOnlyList();
			var modelList = Mapper.EventBoListToSeriesModelList(list);

			EventModelList = new ObservableCollection<SeriesModel>(modelList);


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

	}
}
