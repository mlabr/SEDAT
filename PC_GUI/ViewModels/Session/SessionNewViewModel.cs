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
		public string _sessionDescription = "";

		[ObservableProperty]
		public string _sessionNote = "";

		[ObservableProperty]
		public DateTimeOffset _sessionDateStart = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public DateTimeOffset _sessionDateEnd = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public bool _isSessionDateEndEnabled = false;




		[ObservableProperty]
		public string _disciplineDescription = "";

		[ObservableProperty]
		public string _disciplineNote = "";

		[ObservableProperty]
		public DateTimeOffset _eventDate = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public bool _isEventDateSameAsSessionDate = true;




		public SessionNewViewModel(MainWindowViewModel model)
		{
			
		}
	}
}
