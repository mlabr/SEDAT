using Business.Handlers.WeaponHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLayer.Entities.CodeList;
using PC_GUI.Models.Weapon;
using PC_GUI.ViewModels.Place;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Weapon
{
	internal partial class WeaponDetailViewModel : ViewModelBase
	{
		WeaponHandler handler;

		private MainWindowViewModel mainWindowViewModel;

		[ObservableProperty]
		public int _weaponId = 0;

		[ObservableProperty]
		public int _weaponProfileId = 0;

		[ObservableProperty]
		public string _weaponName = "";

		[ObservableProperty]
		public string _profileName = "";
		
		[ObservableProperty]
		CWeaponTypeModel _weaponTypeModel = new CWeaponTypeModel();

		[ObservableProperty]
		public string _weaponTypeName = "";

		[ObservableProperty]
		public string _powerPrinciple = "";

		[ObservableProperty]
		public string _cFiringMode = "";

		[ObservableProperty]
		public string _fullWeaponName = "";

		[ObservableProperty]
		internal string _identification = "";

		[ObservableProperty]
		internal string _description = "";

		[ObservableProperty]
		public string _note = "";


		public ObservableCollection<CaliberModel> CCaliberModelList { get; set; }

		public ObservableCollection<SightsModel> SightsModelList { get; set; }

		[ObservableProperty]
		internal string totalShots = "";

		[ObservableProperty]
		internal string totalShootinTime = "";

		public WeaponDetailViewModel(MainWindowViewModel model, int id)
		{
			handler = new WeaponHandler();

			var w = handler.GetWeaponProfile(id);

			WeaponName = w.WeaponName;
			WeaponId = w.WeaponId;
			ProfileName = w.ProfileName;
			Identification = w.Identification;
			Description = w.Description;
			Note = w.Note;


			var cList = new List<CaliberModel>();
			foreach (var cal in w.CCaliberBoList)
			{
				if (cal == null) continue;
				var c = new CaliberModel();
				c.Name = cal.Name;
				c.Description = cal.Description;
				c.Note = cal.Note;
				cList.Add(c);
			}
			CCaliberModelList = new ObservableCollection<CaliberModel>(cList);

			var sList = new List<SightsModel>();
			foreach (var sig in w.SightsBoList)
			{
				if (sig == null) continue;
				var s = new SightsModel();
				s.Name = sig.Name;
				s.Description = sig.Description;
				s.Note = sig.Note;
				sList.Add(s);

			}
			SightsModelList = new ObservableCollection<SightsModel>(sList);

			if(w.WeaponTypeList.Count > 1)
			{
				_weaponTypeName = w.WeaponTypeList[0].Name + ", "+ w.WeaponTypeList[1].Name;
			}
			else
			{
				_weaponTypeName = w.WeaponType.Name;
			}


			var j = w.PowerPrincipleBoList.Count;
			for (int i = 0; i < j; i++)
			{
				_powerPrinciple += w.PowerPrincipleBoList[i].Name;
				if(i < (j - 1))
				{
					_powerPrinciple += ", ";
				}
			}

			_cFiringMode = w.CFiringMode.Name;


			handler.GetWeaponStats(id);

			mainWindowViewModel = model;
			FullWeaponName = id.ToString();
		}


		[RelayCommand]
		public void CreateNewProfile(int dbid)
		{
			var i = dbid;
			mainWindowViewModel.CurrentPage = new WeaponNewViewModel(mainWindowViewModel, dbid);
		}

		[RelayCommand]
		public void Back()
		{
			mainWindowViewModel.CurrentPage = new WeaponOverviewViewModel(mainWindowViewModel);
			//mainWindowViewModel.CurrentPage = new NewFullWeaponViewModel(mainWindowViewModel, dbid);
		}


	}
}
