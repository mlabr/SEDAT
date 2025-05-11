using Business.BusinessObjects;
using Business.BusinessObjects.Weapon;
using Business.Handlers;
using Business.Handlers.WeaponHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Helpers;
using PC_GUI.Mapping;
using PC_GUI.Models;
using PC_GUI.Models.CodeList;
using PC_GUI.Models.Weapon;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;

namespace PC_GUI.ViewModels.Sights
{
	internal partial class SightsOverviewViewModel : ViewModelBase
	{
		private SightsHandler handler;

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

		public ObservableCollection<CSightsTypeModel> CSightsTypeModelList { get; set; }

		[ObservableProperty]
		internal CSightsTypeModel _selectedCSightsType;



		[ObservableProperty]
		private ObservableCollection<SightsModel> _sightsModelList;

		public SightsOverviewViewModel(MainWindowViewModel mainWindow)
		{
			handler = new SightsHandler();
			Label = MenuHelper.Weapon.Sights.Overview;

			mainWindowViewModel = mainWindow;

			updateSightsList();

			var cSightsModelList = handler.GetCSightsTypeUsedOnlyList();
			var csightsTypeList = new List<CSightsTypeModel>();

			foreach (var item in cSightsModelList)
			{
				var model = Mapper.Weapon.CSightsTypeBoToCSightsTypeModel(item);
				csightsTypeList.Add(model);
			}

			CSightsTypeModelList = new ObservableCollection<CSightsTypeModel>(csightsTypeList);
			_selectedCSightsType = CSightsTypeModelList.FirstOrDefault();
		}


		[RelayCommand]
		protected void AddNewSightsCommand()
		{
			var bo = new SightsBo();
			bo.Name = Name;
			bo.Description = Description;
			bo.Note = Note;
			bo.IsUsed = true;
			bo.CSightsType.DbId = SelectedCSightsType.DbId;
			handler.Insert(bo);
			updateSightsList();
		}

		private void updateSightsList()
		{
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
