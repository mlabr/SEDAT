using Business.BusinessObjects.Weapon;
using Business.Handlers.WeaponHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Helpers;
using PC_GUI.Mapping;
using PC_GUI.Models;
using PC_GUI.Models.Weapon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Weapon.Munition
{
	internal partial class MunitionOverviewViewModel : ViewModelBase
	{
		private MunitionHandler handler;

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
		public ObservableCollection<DropDownItemModel> _caliberDropDownModelList = new ObservableCollection<DropDownItemModel>();

		[ObservableProperty]
		public ObservableCollection<DropDownItemModel> _filterCaliberDropDownModelList = new ObservableCollection<DropDownItemModel>(); 

		[ObservableProperty]
		private DropDownItemModel _selectedCaliber;


		[ObservableProperty]
		private DropDownItemModel _selectedFilterCaliber; //new ObservableCollection<DropDownItemModel>();


		[ObservableProperty]
		private ObservableCollection<MunitionModel> _munitionModelList;

		public MunitionOverviewViewModel(MainWindowViewModel mainWindow)
		{

			handler = new MunitionHandler();
			var chandler = new CaliberHandler();
			Label = MenuHelper.Weapon.Munition.Overview;

			mainWindowViewModel = mainWindow;
			updateMunitionModelList();
			updateFilter();
			var cCaliberBoList = chandler.GetAllList();
			//var cCaliberDropDownItemList = new List<DropDownItemModel>();

			foreach (var c in cCaliberBoList)
			{
				var model = new DropDownItemModel();
				model.Name = c.Name;
				model.Description = c.Description;
				model.DbId = c.DbId;
				CaliberDropDownModelList.Add(model);
			}
			//CaliberDropDownModelList = new ObservableCollection<DropDownItemModel>(cCaliberDropDownItemList);
			SelectedCaliber = CaliberDropDownModelList.FirstOrDefault();
			//var 

		}


		[RelayCommand]
		protected void AddNewMunitionCommand()
		{
			//var bo = new SightsBo();
			//bo.Name = Name;
			//bo.Description = Description;
			//bo.Note = Note;
			//bo.IsUsed = true;
			//bo.CSightsType.DbId = SelectedCSightsType.DbId;
			//handler.Insert(bo);
			var bo = new MunitionBo();
			bo.Name = Name;
			bo.Description = Description;
			bo.Note = Note;
			bo.CaliberId = SelectedCaliber.DbId;
			handler.Insert(bo);

			updateMunitionModelList();
			updateFilter();
		}

		private void updateMunitionModelList()
		{
			var list = handler.GetAllList();
			var modelList = new List<MunitionModel>();

			foreach (var item in list)
			{
				var model = new MunitionModel();
				model.DbId = item.DbId;
				model.Name = item.Name;
				model.Description = item.Description;
				model.Note = item.Note;
				model.CaliberModel.Name = item.CaliberBo.Name;
				model.CaliberModel.DbId = item.CaliberBo.DbId;
				modelList.Add(model);

			}
			MunitionModelList = new ObservableCollection<MunitionModel>(modelList);
		}

		private void updateFilter()
		{
			FilterCaliberDropDownModelList.Clear();
			var chandler = new CaliberHandler();
			var boList = chandler.GetMunitionCaliberList();

			//var cCaliberModelList = new List<DropDownItemModel>();
			//var modelList = new List<CaliberModel>();
			foreach (var item in boList)
			{
	
				var model = new DropDownItemModel();
				model.Name = item.Name;
				model.Description = item.Description;
				model.DbId = item.DbId;
				FilterCaliberDropDownModelList.Add(model);
			}

			//FilterCaliberModelList = new ObservableCollection<CaliberModel>(modelList);
			SelectedFilterCaliber = FilterCaliberDropDownModelList.FirstOrDefault();
			var ttt = FilterCaliberDropDownModelList.FirstOrDefault();
		}


	}
}
