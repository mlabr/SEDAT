using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Weapon
{
	internal class WeaponOverviewViewModel : ViewModelBase
	{
		private bool isActionConfirmed = false;

		WeaponHandler handler;

		private MainWindowViewModel mainWindowViewModel;


		public ObservableCollection<WeaponModel> WeaponModelList {  get; set; }

		public WeaponOverviewViewModel(MainWindowViewModel main)
		{
			mainWindowViewModel = main;
			handler = new WeaponHandler();

			var list = handler.GetWeaponProfiles();

			var modelList = new ObservableCollection<WeaponModel>();
			foreach (var item in list)
			{
				var model = new WeaponModel();
				model.WeaponProfileName = item.ProfileName;
				model.Name = item.WeaponName;
				model.Identification = item.Identification;
				model.Caliber = item.CCaliberBoList.FirstOrDefault().Name;
				modelList.Add(model);

			}
			WeaponModelList = new ObservableCollection<WeaponModel>(modelList);
		}
	}
}
