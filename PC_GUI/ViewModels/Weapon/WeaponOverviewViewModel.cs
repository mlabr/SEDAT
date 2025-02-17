using Business.Handlers;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PC_GUI.ViewModels.Weapon
{
	internal partial class WeaponOverviewViewModel : ViewModelBase
	{
		private bool isActionConfirmed = false;

		WeaponHandler handler;

		private MainWindowViewModel mainWindowViewModel;


		public ObservableCollection<WeaponModel> WeaponModelList {  get; set; }

		public WeaponOverviewViewModel(MainWindowViewModel main)
		{
			mainWindowViewModel = main;
			handler = new WeaponHandler();

			var list = handler.GetWeaponProfileList();

			var modelList = new ObservableCollection<WeaponModel>();
			foreach (var item in list)
			{
				var model = new WeaponModel();
				model.ProfileDbId = item.ProfileDdId;
				model.WeaponProfileName = item.ProfileName;
				model.Name = item.WeaponName;
				model.Identification = item.Identification;
				model.Caliber = item.CCaliberBoList.FirstOrDefault().Name;
				modelList.Add(model);

			}
			WeaponModelList = new ObservableCollection<WeaponModel>(modelList);
		}

		[RelayCommand]
		protected void GoToDetail(int id)
		{
			mainWindowViewModel.CurrentPage = new WeaponDetailViewModel(mainWindowViewModel, id);
			//mainWindowViewModel.GoToPlaceDetail(id);
		}

		[RelayCommand]
		protected void NewPlace()
		{
			//mainWindowViewModel.CurrentPage = new WeaponDetailViewModel(mainWindowViewModel);
			//mainWindowViewModel.GoToPlaceDetail(id);
		}
	}
}
