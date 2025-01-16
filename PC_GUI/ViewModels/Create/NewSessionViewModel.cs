using Business.BusinessObjects;
using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Mapping;
using PC_GUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PC_GUI.ViewModels
{
	internal partial class NewSessionViewModel : ViewModelBase
	{
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

		[ObservableProperty]
		public DateTimeOffset _dateStart = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public DateTimeOffset _dateEnd = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public string _errorMessageDate = "";

		[ObservableProperty]
		public int _errorMessageDateRowHeight = 0;

		[ObservableProperty]
		public List<PlaceModel> _placeList;

		[ObservableProperty]
		public PlaceModel? _selectedItem;

		[ObservableProperty]
		public string _errorMessage = "All clear";



		public NewSessionViewModel()
        {
			//Mocked DB
			var handler = new PlaceHandler();

			var list = handler.GetAll();

			_placeList = new List<PlaceModel>();
			string[] names = { "Unknown", "Garage", "Dnesice" };
			var i = 1;
			foreach (string name in names)
			{
				var item = new PlaceModel();
				item.DbId = i;
				item.Name = name;
				item.Order = i;
				i++;
				_placeList.Add(item);
			}

			_placeList = Mapper.PlaceBoListToPlaceModelList(list);
			_selectedItem = _placeList.FirstOrDefault();
			//_selectedItem = ttt;

		}


		[RelayCommand]
        private void BtnSubmitOnClick()
        {
			var bo = new SessionBo();


			bo.Name = _name;
			bo.Description = _description;
			bo.Note = _note;
			bo.DateStart = _dateStart.Date; //yyyy-mm-dd
			bo.DateEnd = _dateEnd.Date;
			bo.PlaceId = _selectedItem.DbId;


			//bo.Validate();
			//validate
			if(!bo.IsValid())
			{
				ErrorMessageName = bo.GetErrorMessageName();
				if (!string.IsNullOrEmpty(ErrorMessageName))
				{
					ErrorMessageNameRowHeight = 20;
				}

				ErrorMessageDate = bo.GetErrorMessageDate();
				if (!string.IsNullOrEmpty(ErrorMessageDate))
				{
					ErrorMessageDateRowHeight = 20;

				}

				return;
			}
			


			//if pass then store in db
			var handler = new SessionHandler();

			//handler.InsertSession(bo);

			//clearing
			NameErrorMessage = "";
			ErrorMessageNameRowHeight = 0;
			ErrorMessageDateRowHeight = 0;
			Name = "";
			DateStart = new DateTimeOffset(DateTime.Now);
			DateEnd = new DateTimeOffset(DateTime.Now);

		}
    }
}
