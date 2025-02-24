﻿using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using DataLayer.Entities.CodeList;
using PC_GUI.Models.Weapon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Weapon
{
	internal partial class WeaponDetailViewModel : ViewModelBase
	{
		WeaponHandler handler;

		private MainWindowViewModel mainWindowViewModel;

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


		public ObservableCollection<CCaliberModel> CCaliberModelList { get; set; }

		public ObservableCollection<SightsModel> SightsModelList { get; set; }

		public WeaponDetailViewModel(MainWindowViewModel model, int id)
		{
			handler = new WeaponHandler();

			var w = handler.GetWeaponProfile(id);

			WeaponName = w.WeaponName;
			ProfileName = w.ProfileName;
			Identification = w.Identification;
			Description = w.Description;
			Note = w.Note;


			var cList = new List<CCaliberModel>();
			foreach (var cal in w.CCaliberBoList)
			{
				if (cal == null) continue;
				var c = new CCaliberModel();
				c.Name = cal.Name;
				c.Description = cal.Description;
				c.Note = cal.Note;
				cList.Add(c);
			}
			CCaliberModelList = new ObservableCollection<CCaliberModel>(cList);

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


			mainWindowViewModel = model;
			FullWeaponName = id.ToString();
		}


	}
}
