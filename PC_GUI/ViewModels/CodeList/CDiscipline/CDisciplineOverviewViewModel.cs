using Business.Handlers;
using Business.Handlers.WeaponHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Helpers;
using PC_GUI.Models.CodeList;
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

		public ObservableCollection<CDisciplineTypeModel> CDisciplineTypeModelList { get; set; }

		//public Interaction<>

		private MainWindowViewModel mainWindowViewModel;

		private bool isActionConfirmed = false;

		public CDisciplineOverviewViewModel(MainWindowViewModel mainWindow)
		{
			Label = MenuHelper.Weapon.Sights.Overview;

			mainWindowViewModel = mainWindow;

			var handler = new SightsHandler();

			var list = handler.GetCSightsTypeAllList();

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
