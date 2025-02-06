using Avalonia;
using Avalonia.Controls;
using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using PC_GUI.Helpers;
using PC_GUI.Mapping;
using PC_GUI.Models.Weapon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PC_GUI.ViewModels.Weapon
{
	internal partial class NewFullWeaponViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string? _dialogResult;

		private bool isActionConfirmed = false;

		WeaponHandler handler;

		private MainWindowViewModel mainWindowViewModel;

		[ObservableProperty]
		public string _weaponName = "";

		[ObservableProperty]
		public string _profileName = "";

		[ObservableProperty]
		internal MenuItemViewModel _selectedCPowerPrincipleMenuItem;

		[ObservableProperty]
		internal MenuItemViewModel _selectedCWeaponTypeMenuItem;

		#region baseviewmodel
		[ObservableProperty]
		public string _fullWeaponName = "";

		[ObservableProperty]
		internal string _identification = "";

		[ObservableProperty]
		internal string _description = "";

		[ObservableProperty]
		public string _note = "";

		[ObservableProperty]
		private CCaliberModel _selectedCaliber;

		[ObservableProperty]
		internal CSightsTypeModel _selectedCSightsType;

		[ObservableProperty]
		internal CFiringModeModel _selectedFiringMode;

		[ObservableProperty]
		internal MenuItemViewModel _selectedOwnerMenuItem;

		[ObservableProperty]
		internal SightsModel _selectedSightsModel;

		public ObservableCollection<SightsModel> SightsModelList { get; private set; }
		#endregion

		public ObservableCollection<MenuItemViewModel> OwnerMenuItemViewModelList { get; set; }
		
		public ObservableCollection<CCaliberModel> CCaliberModelList { get; set; }

		public ObservableCollection<CSightsTypeModel> CSightsTypeModelList { get; set; }

		public ObservableCollection<CFiringModeModel> CFiringModelList { get; set; }

		public ObservableCollection<MenuItemViewModel> CPowerPrincipleMenuItems { get; set; }

		[ObservableProperty]
		private string _cPowerPrincipleDisplayName = "Power principle: ";

		public ObservableCollection<MenuItemViewModel> CWeaponTypeMenuItems { get; set; }

		[ObservableProperty]
		private string _cWeaponTypeDisplayName = "Weapon type: ";


		[ObservableProperty]
		public string _sightsName = "";

		[ObservableProperty]
		public string _sightsDescription = "";

		[ObservableProperty]
		public string _sightsNote = "";

		//View specific
		[ObservableProperty]
		private bool _isExistingSightsSelected = true;


		[ObservableProperty]
		public string _caliberName = "";

		[ObservableProperty]
		public string _caliberDescription = "";

		[ObservableProperty]
		public string _caliberNote = "";

		[ObservableProperty]
		private bool _isExistingCaliberSelected = true;

		[ObservableProperty]
		private int _maintenanceIntervalDate;

		[ObservableProperty]
		private int _maintenanceIntervalShots;

		[ObservableProperty]
		private DateTimeOffset _maintenanceLastDate;

		public NewFullWeaponViewModel(MainWindowViewModel main)
		{
			mainWindowViewModel = main;
			handler = new WeaponHandler();
			//MaintenanceLastDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			MaintenanceLastDate = new DateTimeOffset(DateTime.Now);

			var cfmModelList = handler.GetCFiringModeBoList();
			var modelList = new List<CFiringModeModel>();

			foreach (var item in cfmModelList)
			{
				var model = Mapper.Weapon.CFiringModeBoToCFiringModeModel(item);
				modelList.Add(model);
			}
			CFiringModelList = new ObservableCollection<CFiringModeModel>(modelList);
			_selectedFiringMode = CFiringModelList.FirstOrDefault();

			var cCaliberModelList = handler.GetCCaliberBoList();
			var cmodelList = new List<CCaliberModel>();

			foreach (var item in cCaliberModelList)
			{
				var model = Mapper.Weapon.CCaliberBoToCCaliberModel(item);
				cmodelList.Add(model);
			}

			CCaliberModelList = new ObservableCollection<CCaliberModel>(cmodelList);
			SelectedCaliber = CCaliberModelList.FirstOrDefault();


			var cSightsModelList = handler.GetCSightsTypeBoList();
			var csightsTypeList = new List<CSightsTypeModel>();

			foreach(var item in cSightsModelList)
			{
				var model = Mapper.Weapon.CSightsTypeBoToCSightsTypeModel(item);
				csightsTypeList.Add(model);
			}

			CSightsTypeModelList = new ObservableCollection<CSightsTypeModel>(csightsTypeList);
			_selectedCSightsType = CSightsTypeModelList.FirstOrDefault();


			var sightsBoList = handler.GetSightsBoList();
			var sightsList = new List<SightsModel>();
			foreach (var item in sightsBoList)
			{
				var model = Mapper.Weapon.SightsBoToSightsModel(item);
				sightsList.Add(model);
			}

			SightsModelList = new ObservableCollection<SightsModel>(sightsList);
			_selectedSightsModel = SightsModelList.FirstOrDefault();

			var PowerPrincipleMenuItemsFlatList = Mapper.Weapon.CPowerPrincipleBoListToMenuItemViewModelList(handler.GetCPowerPrincipleBoList());
			var PowerPrincipleMenuItemNestedList = MenuHelper.CreateNestedListFromFlatList(PowerPrincipleMenuItemsFlatList);
			CPowerPrincipleMenuItems = new ObservableCollection<MenuItemViewModel>(PowerPrincipleMenuItemNestedList);
			_selectedCPowerPrincipleMenuItem = PowerPrincipleMenuItemsFlatList.FirstOrDefault();

			var WeaponTypeMenuItemFlatList = Mapper.Weapon.CWeaponTypeBoListToMenuItemViewModelList(handler.GetCWeaponTypeBoList());
			var WeaponTypeMenuItemNestedList = MenuHelper.CreateNestedListFromFlatList(WeaponTypeMenuItemFlatList);
			CWeaponTypeMenuItems = new ObservableCollection<MenuItemViewModel>(WeaponTypeMenuItemNestedList);
			_selectedCWeaponTypeMenuItem = WeaponTypeMenuItemFlatList.FirstOrDefault();

			var OwnerMenuItemFlatList = Mapper.PersonBoListToMenuItemViewModelList(handler.GetPersonBoUsedOnlyList());
			OwnerMenuItemViewModelList = new ObservableCollection<MenuItemViewModel>(OwnerMenuItemFlatList);
			_selectedOwnerMenuItem = OwnerMenuItemFlatList.FirstOrDefault();
		}


		partial void OnSelectedCPowerPrincipleMenuItemChanged(MenuItemViewModel value)
		{
			var msg = "Power principle: ";
			if(value != null)
			{
				CPowerPrincipleDisplayName = msg + _selectedCPowerPrincipleMenuItem.Name;
			}			
		}

		partial void OnSelectedCWeaponTypeMenuItemChanged(MenuItemViewModel value)
		{
			var msg = "Weapon type: ";
			if(value != null)
			{
				CWeaponTypeDisplayName = msg + _selectedCWeaponTypeMenuItem.Name;
			}
		}

		partial void OnWeaponNameChanged(string? value)
		{
			FullWeaponName = value + " " + _profileName;
		}

		partial void OnProfileNameChanged(string? value)
		{
			FullWeaponName = _weaponName + " " + value;
		}

		//BtnSubmitOnClickCommand
		[RelayCommand]
		private void BtnSubmitOnClick()
		{
			//mapping
			var model = this;
			var bo = new WeaponBo();
			bo.WeaponName = model.WeaponName;
			bo.ProfileName = model.ProfileName;
			bo.Identification = model.Identification;
			bo.Note = model.Note;
			bo.Description = model.Description;
			bo.CWeaponTypeCode = model.SelectedCWeaponTypeMenuItem.DbId;
			bo.CPowerPrincipleCode = model.SelectedCPowerPrincipleMenuItem.DbId;
			bo.CFiringModeCode = model.SelectedFiringMode.DbId;
			bo.MaintenanceIntervalDate = model.MaintenanceIntervalDate;
			bo.MaintenanceIntervalShots = model.MaintenanceIntervalShots;
			bo.MaintenanceLastDate = model.MaintenanceLastDate;

			//Caliber
			if(IsExistingCaliberSelected)
			{
				bo.CCaliberBoList.FirstOrDefault().IsExisting = true;
				bo.CCaliberBoList.FirstOrDefault().DbId = model.SelectedCaliber.DbId;
			}
			else
			{
				bo.CCaliberBoList = new List<CCaliberBo>();
				var cal = new CCaliberBo();
				cal.IsExisting = false;
				cal.Name = model.CaliberName;
				cal.Description = model.CaliberDescription;
				cal.Note = model.CaliberNote;
				bo.CCaliberBoList.Add(cal);
			}

			//Sights
			if (IsExistingSightsSelected)
			{
				bo.SightsBoList.FirstOrDefault().IsExisting = true;
				bo.SightsBoList.FirstOrDefault().DbId = model.SelectedSightsModel.DbId;
			}
			else
			{
				bo.SightsBoList = new List<SightsBo>();
				var sights = new SightsBo();
				sights.IsExisting = false;
				sights.Name = model.SightsName;
				sights.Description = model.SightsDescription;
				sights.Note = model.SightsNote;
				sights.CSightsType.DbId = model.SelectedCSightsType.DbId;
				bo.SightsBoList.Add (sights);
			}

			//TODO validate

			//Show error message in modal window

			handler.SaveNewWeaponToDataBase(bo);
			//this.FullWeaponName;
		}

		[RelayCommand]
		private void BtnTestOnClick()
		{
			var sfsfs = CPowerPrincipleMenuItems;
		}

	}
}


