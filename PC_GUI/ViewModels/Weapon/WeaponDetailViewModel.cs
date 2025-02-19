using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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

		public WeaponDetailViewModel(MainWindowViewModel model, int id)
		{
			handler = new WeaponHandler();

			var w = handler.GetWeaponProfile(id);

			WeaponName = w.WeaponName;
			ProfileName = w.ProfileName;
			Identification = w.Identification;
			Description = w.Description;
			Note = w.Note;


			mainWindowViewModel = model;
			FullWeaponName = id.ToString();
		}


	}
}
