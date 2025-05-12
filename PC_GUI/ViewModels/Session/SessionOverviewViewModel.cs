using Business.Handlers;
using System.Collections.ObjectModel;
using PC_GUI.Models.Session;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Models;

namespace PC_GUI.ViewModels.Session
{
	internal partial class SessionOverviewViewModel : ViewModelBase
	{
		private SessionHandler sesHandler;

		[ObservableProperty]
		private ObservableCollection<SessionOverviewModel> _sessionModelList;

		//Filter: Sesion name, Series, Place

		public SessionOverviewViewModel(MainWindowViewModel mainWindow)
		{
			sesHandler = new SessionHandler();
			var list= new ObservableCollection<SessionOverviewModel>();

			var boList = sesHandler.GetSessionOverviewList();

			foreach (var bo in boList)
			{
				var model = new SessionOverviewModel();
				model.Name = bo.Name;
				model.PlaceName = bo.PlaceBo.Name;

				var namesList = new List<string>();
				foreach (var ser in bo.SeriesBoList)
				{
					namesList.Add(ser.Name);
				}
				model.SeriesName = namesList.FirstOrDefault();
				if (namesList.Count> 1)
				{
					foreach (var name in namesList.Skip(1))
					{
						model.SeriesName += ", " + name;
					}
				}

				list.Add(model);


			}

			SessionModelList = new ObservableCollection<SessionOverviewModel>(list);

		}
	}
}
