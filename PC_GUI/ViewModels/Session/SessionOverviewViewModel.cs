using Business.Handlers;
using System.Collections.ObjectModel;
using PC_GUI.Models.Session;

namespace PC_GUI.ViewModels.Session
{
	internal partial class SessionOverviewViewModel : ViewModelBase
	{
		private SessionHandler sesHandler;

		public ObservableCollection<SessionOverviewModel> SessionModelList { get; set; }

		//Filter: Sesion name, Series, Place

		public SessionOverviewViewModel(MainWindowViewModel mainWindow)
		{
			sesHandler = new SessionHandler();

			sesHandler.GetSessionOverviewList();
		}
	}
}
