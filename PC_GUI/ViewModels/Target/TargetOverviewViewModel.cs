using Business.Handlers;
using PC_GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Target
{
	internal class TargetOverviewViewModel : ViewModelBase
	{
		private bool isActionConfirmed = false;

		TargetHandler handler;

		private MainWindowViewModel mainWindowViewModel;

		public ObservableCollection<TargetModel> TargetModelList { get; set; }

		public TargetOverviewViewModel(MainWindowViewModel model)
		{
			mainWindowViewModel = model;

			handler = new TargetHandler();

			var list = handler.GetAllList();
			var modelList = new ObservableCollection<TargetModel>();
			foreach (var item in list)
			{
				var t = new TargetModel();
				t.DbId = item.DbId;
				t.Name = item.Name;
				t.Description = item.Description;
				t.Note = item.Note;
				modelList.Add(t);
			}
			TargetModelList = new ObservableCollection<TargetModel>(modelList);

		}
	}
}
