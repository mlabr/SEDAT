using Avalonia.Controls;
using Business.BusinessObjects.CodeList;
using Business.Handlers;
using PC_GUI.Helpers;
using PC_GUI.Mapping;
using PC_GUI.Models;
using PC_GUI.Models.Weapon;
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
		public ObservableCollection<CaliberModel> CaliberModelList { get; set; }
		public CaliberOverviewViewModel(MainWindowViewModel mainWindow)
		{
			mainWindowViewModel = mainWindow;
			Label = MenuHelper.Manage.CaliberOverview;
			CaliberModelList = new ObservableCollection<CaliberModel>();
			handler = new WeaponHandler();
			List<CaliberBo> listBo = handler.GetCaliberBoList();
			foreach (CaliberBo item in listBo)
			{
				CaliberModelList.Add(Mapper.Weapon.CaliberBoToCaliberModel(item));
			}
			



		}

	}
}
