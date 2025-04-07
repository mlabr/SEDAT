using Business.Handlers;
using Business.Handlers.CodeHandler;
using CommunityToolkit.Mvvm.ComponentModel;
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

		public ObservableCollection<SeriesModel> EventModelList { get; set; }

		public SeriesOverviewViewModel(MainWindowViewModel mainView )
		{
			mainWindowViewModel = mainView;

			var handler = new SeriesHandler();
			var list = handler.GetUsedOnlyList();
			var modelList = Mapper.EventBoListToSeriesModelList(list);

			EventModelList = new ObservableCollection<SeriesModel>(modelList);


		}
	}
}
