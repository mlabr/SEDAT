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

		public WeaponDetailViewModel(MainWindowViewModel model, int id)
		{
			handler = new WeaponHandler();

			handler.GetWeaponProfile(id);

			mainWindowViewModel = model;
			FullWeaponName = id.ToString();
		}

		[ObservableProperty]
		public string _fullWeaponName = "Detail of weapon";


	}
}
