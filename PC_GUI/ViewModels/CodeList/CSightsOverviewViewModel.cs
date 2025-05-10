using Business.Handlers.WeaponHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Helpers;
using PC_GUI.Models.CodeList;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PC_GUI.ViewModels.CodeList
{
	internal partial class CSightsOverviewViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string? _dialogResult;

		public ObservableCollection<CDisciplineTypeModel> CDisciplineTypeModelList { get; set; }

		//public Interaction<>

		private MainWindowViewModel mainWindowViewModel;

		private bool isActionConfirmed = false;

		public CSightsOverviewViewModel(MainWindowViewModel mainWindow)
		{
			Label = MenuHelper.Manage.Weapon.SightsOverview;

			mainWindowViewModel = mainWindow;

			var handler = new CSightsHandler();

			var list = handler.GetAll();

			var modelList = new List<CDisciplineTypeModel>();
			foreach (var item in list)
			{
				var model = new CDisciplineTypeModel();
				model.DbId = item.DbId;
				model.Name = item.Name;
				model.Description = item.Description;
				model.Note = item.Note;
				modelList.Add(model);

			}

			CDisciplineTypeModelList = new ObservableCollection<CDisciplineTypeModel>(modelList);
		}

	}
}
