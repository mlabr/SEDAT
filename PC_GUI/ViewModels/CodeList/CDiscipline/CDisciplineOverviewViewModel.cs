using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Helpers;
using PC_GUI.Models.Weapon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.CodeList.CDiscipline
{
	internal partial class CDisciplineOverviewViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string? _dialogResult;


		private MainWindowViewModel mainWindowViewModel;

		private bool isActionConfirmed = false;

		public ObservableCollection<CSightsTypeModel> CDisciplineModelList { get; set; }

		public CDisciplineOverviewViewModel(MainWindowViewModel mainWindow)
		{
			Label = MenuHelper.Manage.Weapon.SightsOverview;

			mainWindowViewModel = mainWindow;

			var handler = new SessionHandler();

			var list = handler.GetCDisciplineAllList();

			var modelList = new List<CSightsTypeModel>();
			foreach (var item in list)
			{
				var model = new CSightsTypeModel();
				model.DbId = item.DbId;
				model.Name = item.Name;
				model.Description = item.Description;
				model.Note = item.Note;
				modelList.Add(model);

			}

			CDisciplineModelList = new ObservableCollection<CSightsTypeModel>(modelList);
		}
	}
}
