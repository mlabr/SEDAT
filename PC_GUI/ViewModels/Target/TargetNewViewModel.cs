using Avalonia;
using Business.BusinessObjects;
using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PC_GUI.ViewModels.Target
{
	internal partial class TargetNewViewModel : ViewModelBase
	{
		private MainWindowViewModel mainWindowViewModel;

		private TargetHandler handler;

		[ObservableProperty]
		public string _name = "";

		[ObservableProperty]
		public string _nameErrorMessage = "";

		[ObservableProperty]
		public string _errorMessageName = "";

		[ObservableProperty]
		public int _errorMessageNameRowHeight = 0;


		[ObservableProperty]
		public string _description = "";

		[ObservableProperty]
		public string _note = "";

		public TargetNewViewModel(MainWindowViewModel main)
		{
			mainWindowViewModel = main;
			handler = new TargetHandler();
		}

		[RelayCommand]
		private void BtnSubmitOnClick()
		{
			var bo = new TargetBo();
			bo.Name = _name;
			bo.Description = _description;
			bo.Note = _note;
			bo.IsUsed = true;
			//TODO Validation
			handler.Insert(bo);

			ReturnToOverView();
		}

		[RelayCommand]
		internal void ReturnToOverView()
		{
			mainWindowViewModel.CurrentPage = new TargetOverviewViewModel(mainWindowViewModel);
		}


	}
}
