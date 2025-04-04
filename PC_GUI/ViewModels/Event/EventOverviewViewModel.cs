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

namespace PC_GUI.ViewModels.Event
{
	internal partial class EventOverviewViewModel : ViewModelBase
	{
		private MainWindowViewModel mainWindowViewModel;

		[ObservableProperty]
		private string? _dialogResult;

		public ObservableCollection<EventModel> EventModelList { get; set; }

		public EventOverviewViewModel(MainWindowViewModel mainView )
		{
			mainWindowViewModel = mainView;

			var handler = new EventDbHandler();
			var list = handler.GetUsedOnlyList();
			var modelList = Mapper.EventBoListToEventModelList(list);

			EventModelList = new ObservableCollection<EventModel>(modelList);


		}
	}
}
