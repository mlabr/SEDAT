using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Event
{
	internal class EventOverviewViewModel : ViewModelBase
	{
		private MainWindowViewModel mainWindowViewModel;


		public EventOverviewViewModel(MainWindowViewModel mainView )
		{
			mainWindowViewModel = mainView;
		}
	}
}
