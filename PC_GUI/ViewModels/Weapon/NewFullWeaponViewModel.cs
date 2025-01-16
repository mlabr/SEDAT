using AutoMapper.Configuration.Annotations;
using Avalonia;
using Avalonia.Controls;
using Business.BusinessObjects;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PC_GUI.ViewModels.Weapon
{
	internal partial class NewFullWeaponViewModel : WeaponBaseViewModel
	{
		[ObservableProperty]
		private string? _dialogResult;

		private bool isActionConfirmed = false;

		WeaponHandler handler;

		private MainWindowViewModel mainWindowViewModel;

		[ObservableProperty]
		private MenuItemViewModel _selectedOwnerMenuItem;

		public ObservableCollection<MenuItemViewModel> OwnerMenuItemViewModelList { get; set; }


		[ObservableProperty]
		public string _profileName = "";

		
		public ObservableCollection<CCaliberModel> CCaliberModelList { get; set; }


		[ObservableProperty]
		private CSightsModel _selectedCSights;
		public ObservableCollection<CSightsModel> CSightsModelList { get; set; }


		[ObservableProperty]
		private CFiringModeModel _selectedFiringMode;
		public ObservableCollection<CFiringModeModel> CFiringModelList { get; set; }

		public ObservableCollection<MenuItemViewModel> CPowerPrincipleMenuItems { get; set; }

		[ObservableProperty]
		private MenuItemViewModel _selectedCPowerPrincipleMenuItem;

		[ObservableProperty]
		private string _cPowerPrincipleDisplayName = "Power principle: ";


		public ObservableCollection<MenuItemViewModel> CWeaponTypeMenuItems { get; set; }

		[ObservableProperty]
		private MenuItemViewModel _selectedCWeaponTypeMenuItem;

		[ObservableProperty]
		private string _cWeaponTypeDisplayName = "Weapon type: ";

		[ObservableProperty]
		public string _weaponName = "";


		[ObservableProperty]
		public string _fullWeaponName = "";


		[ObservableProperty]
		public string _identification = "";

		[ObservableProperty]
		public string _note = "";


		[ObservableProperty]
		public string _sightsName = "";

		[ObservableProperty]
		public string _sightsDescription = "";

		[ObservableProperty]
		public string _sightsNote = "";


		public NewFullWeaponViewModel(MainWindowViewModel main)
		{
			mainWindowViewModel = main;
			handler = new WeaponHandler();

			var cfmModelList = handler.GetCFiringModeBoList();
			var modelList = new List<CFiringModeModel>();

			foreach (var item in cfmModelList)
			{
				//TODO mapper
				var model = new CFiringModeModel();
				model.DbId = item.DbId;
				model.Name = item.Name;
				model.Description = item.Description;
				modelList.Add(model);

			}

			CFiringModelList = new ObservableCollection<CFiringModeModel>(modelList);
			_selectedFiringMode = CFiringModelList.FirstOrDefault();

			var cCaliberModelList = handler.GetCCaliberBoList();
			var cmodelList = new List<CCaliberModel>();

			foreach (var item in cCaliberModelList)
			{
				//TODO mapper
				var model = new CCaliberModel();
				model.DbId = item.DbId;
				model.Name = item.Name;
				model.Description = item.Description; 
				cmodelList.Add(model);

			}

			CCaliberModelList = new ObservableCollection<CCaliberModel>(cmodelList);
			_selectedCaliber = CCaliberModelList.FirstOrDefault();


			var cSightsModelList = handler.GetCSightsBoList();
			var csightses = new List<CSightsModel>();

			foreach(var item in cSightsModelList)
			{
				//TODO mapper
				var model = new CSightsModel();
				model.DbId = item.DbId;
				model.Name = item.Name;
				model.Description = item.Description;
				csightses.Add(model);
			}

			CSightsModelList = new ObservableCollection<CSightsModel>(csightses);
			_selectedCSights = CSightsModelList.FirstOrDefault();

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
			SelectedOwnerMenuItem = OwnerMenuItemFlatList.FirstOrDefault();

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
		
			var www = this;
			var w = new WeaponBo();
			w.Name = this.WeaponName;
			
			//this.FullWeaponName;

		}

		[RelayCommand]
		private void BtnTestOnClick()
		{
			var sfsfs = CPowerPrincipleMenuItems;
		}

	}
}


