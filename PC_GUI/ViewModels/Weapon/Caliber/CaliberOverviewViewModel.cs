using Avalonia.Controls;
using Business.BusinessObjects.CodeList;
using Business.Handlers.WeaponHandlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Helpers;
using PC_GUI.Mapping;
using PC_GUI.Models;
using PC_GUI.Models.Weapon;
using PC_GUI.ViewModels.Place;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Caliber
{
	internal partial class CaliberOverviewViewModel : ViewModelBase
	{
		private MainWindowViewModel mainWindowViewModel;
		WeaponHandler handler;

		[ObservableProperty]
		private ObservableCollection<CaliberModel> _caliberModelList;

		[ObservableProperty]
		private string _name;

		[ObservableProperty]
		private string _description;

		[ObservableProperty]
		private string _note;


		public CaliberOverviewViewModel(MainWindowViewModel mainWindow)
		{
			mainWindowViewModel = mainWindow;
			Label = MenuHelper.Weapon.Caliber.Overview;
			CaliberModelList = new ObservableCollection<CaliberModel>();
			updateCaliberList();
		}



		[RelayCommand]
		protected void GoToDetail(int id)
		{
			mainWindowViewModel.CurrentPage = new CaliberDetailViewModel(mainWindowViewModel, id);
		}

		[RelayCommand]
		protected void AddNewCaliber()
		{
			var bo = new CaliberBo();
			bo.Name = Name;
			bo.Description = Description;
			bo.Note = Note;
			bo.IsUsed = true;
			handler.SaveNewCaliber(bo);
			updateCaliberList();
		}


		private void updateCaliberList()
		{
			var listModel = new List<CaliberModel>();
			handler = new WeaponHandler();
			List<CaliberBo> listBo = handler.GetCaliberBoList();
			foreach (CaliberBo item in listBo)
			{
				listModel.Add(Mapper.Weapon.CaliberBoToCaliberModel(item));
			}

			CaliberModelList = new ObservableCollection<CaliberModel>(listModel);

			Name = "";
			Description = "";
			Note = "";
		}
	}
}
