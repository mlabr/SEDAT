using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
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
		public string _fullWeaponName = "";

		[ObservableProperty]
		internal string _identification = "";

		[ObservableProperty]
		internal string _description = "";

		[ObservableProperty]
		public string _note = "";


		public ObservableCollection<CCaliberModel> CCaliberModelList { get; set; }

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


			mainWindowViewModel = model;
			FullWeaponName = id.ToString();
		}


	}
}
