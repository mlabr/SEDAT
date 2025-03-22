using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Session
{
	internal partial class SessionNewViewModel : ViewModelBase
	{
		[ObservableProperty]
		public int _eventId;

		[ObservableProperty]
		public string _eventName = "";

		[ObservableProperty]
		public string _sessionName = "";

		[ObservableProperty]
		public string _description = "";

		[ObservableProperty]
		public string _note = "";

		[ObservableProperty]
		public DateTimeOffset _dateStart = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public DateTimeOffset _dateEnd = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public bool _isDateEnd = false;


		public SessionNewViewModel(MainWindowViewModel model)
		{
			
		}
	}
}
