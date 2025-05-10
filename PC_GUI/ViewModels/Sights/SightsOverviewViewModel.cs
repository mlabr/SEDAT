using Business.Handlers;
using Business.Handlers.WeaponHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Helpers;
using PC_GUI.Models.CodeList;
using PC_GUI.Models.Weapon;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PC_GUI.ViewModels.Sights
{
	internal partial class SightsOverviewViewModel : ViewModelBase
	{

		[ObservableProperty]
		private string? _dialogResult;

		[ObservableProperty]
		private string _name;

		[ObservableProperty]
		private string _description;

		[ObservableProperty]
		private string _note;

		private MainWindowViewModel mainWindowViewModel;

		private bool isActionConfirmed = false;

		[ObservableProperty]
		private ObservableCollection<SightsModel> _sightsModelList;

		public SightsOverviewViewModel(MainWindowViewModel mainWindow)
		{
			Label = MenuHelper.Manage.Weapon.SightsOverview;

			mainWindowViewModel = mainWindow;

			var handler = new SightsHandler();

			var list = handler.GetSightsAllList();

			var modelList = new List<SightsModel>();
			foreach (var item in list)
			{
				var model = new SightsModel();
				model.DbId = item.DbId;
				model.Name = item.Name;
				model.Description = item.Description;
				model.Note = item.Note;
				model.CSightsType.Name = item.CSightsType.Name;
				modelList.Add(model);

			}

			SightsModelList = new ObservableCollection<SightsModel>(modelList);
		}
	}
}
