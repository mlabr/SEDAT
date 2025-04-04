﻿using Business.BusinessObjects.CodeList;
using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Mapping;
using PC_GUI.Models;
using PC_GUI.Models.CodeList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Session
{
	internal partial class SessionNewViewModel : ViewModelBase
	{
		private EventDbHandler eHandler;
		private MunitionHandler mHandler;
		private WeaponHandler wHandler;
		private SessionHandler sHandler;



		/****************************
		 * 
		 *   SESSION
		 * 
		 ***************************/

		public ObservableCollection<DropDownItemModel> EventDropdownModelList { get; set; }

		[ObservableProperty]
		private DropDownItemModel _selectedEvent;

		[ObservableProperty]
		private int _eventId;

		[ObservableProperty]
		private string _eventName = "";

		[ObservableProperty]
		private string _sessionName = "";

		[ObservableProperty]
		private string _sessionDescription = "";

		[ObservableProperty]
		private string _sessionNote = "";

		[ObservableProperty]
		private DateTimeOffset _sessionDateStart = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		private DateTimeOffset _sessionDateEnd = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		private bool _isSessionDateEndEnabled = false;

		[ObservableProperty]
		private List<DropDownItemModel> _placeList;

		[ObservableProperty]
		private DropDownItemModel? _selectedPlaceItem;

		/****************************
		 * 
		 *   DISCIPLINE
		 * 
		 ***************************/
		[ObservableProperty]
		private string _disciplineDescription = "";

		[ObservableProperty]
		private string _disciplineNote = "";

		[ObservableProperty]
		private List<DropDownItemModel> _cDisciplineList;

		[ObservableProperty]
		private DropDownItemModel _selectedCDisciplineItem;

		[ObservableProperty]
		private List<DropDownItemModel> _cShootingPositionList;

		[ObservableProperty]
		private DropDownItemModel _selectedCShootingPositionItem;


		[ObservableProperty]
		private DateTimeOffset _eventDate = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		private bool _isEventDateSameAsSessionDate = true;

		[ObservableProperty]
		private int _scoreMax = 0;

		[ObservableProperty]
		private int _roundsMax = 0;

		[ObservableProperty]
		private List<DropDownItemModel> _targetList;

		[ObservableProperty]
		private DropDownItemModel _selectedTargetItem;


		/****************************
		 * 
		 *   RECORD
		 * 
		 ***************************/
		[ObservableProperty]
		private List<DropDownItemModel> _weaponProfileList;

		[ObservableProperty]
		private DropDownItemModel? _selectedWeaponProfileItem;

		[ObservableProperty]
		private ObservableCollection<DropDownItemModel> _munitionList = new ObservableCollection<DropDownItemModel>();

		[ObservableProperty]
		private DropDownItemModel? _selectedMunitionItem;

		[ObservableProperty]
		private ObservableCollection<RecordModel> _recordModelList;

		[ObservableProperty]
		private int _score = 0;

		[ObservableProperty]
		private int _shots = 0;

		public SessionNewViewModel(MainWindowViewModel model)
		{
			eHandler = new EventDbHandler();
			wHandler = new WeaponHandler();
			mHandler = new MunitionHandler();
			sHandler = new SessionHandler();

			var pHandler = new PlaceHandler();
			var placeBoList = pHandler.GetAll();


			/****************************
			 * 
			 *   SESSION
			 * 
			 ***************************/

			var list = eHandler.GetUsedOnlyList();
			var modelList = Mapper.DropDown.EventBoListToEventDropDownModelList(list);

			EventDropdownModelList = new ObservableCollection<DropDownItemModel>(modelList);
			SelectedEvent = EventDropdownModelList.FirstOrDefault();


			_placeList = new List<DropDownItemModel>();
			foreach (var item in placeBoList)
			{
				var place = new DropDownItemModel();
				place.Name = item.Name;
				place.Description = item.Description;
				place.DbId = item.DbId;
				_placeList.Add(place);
			}
			_selectedPlaceItem = _placeList.FirstOrDefault();

			/****************************
			 * 
			 *   DISCIPLINE
			 * 
			 ***************************/
			var cDList = sHandler.GetCDisciplineUsedOnlyList();
			CDisciplineList = new List<DropDownItemModel>();
			foreach (var item in cDList)
			{
				var cd = new DropDownItemModel();
				cd.Name = item.Name;
				cd.Description = item.Description;
				cd.DbId	= item.DbId;
				CDisciplineList.Add(cd);
			}
			SelectedCDisciplineItem = CDisciplineList.FirstOrDefault();

			var tList = sHandler.GetTargetUsedOnlyList();
			TargetList = new List<DropDownItemModel>();
			foreach (var item in tList)
			{
				 var t = new DropDownItemModel();
				t.Name = item.Name;
				t.Description = item.Description;
				t.DbId = item.DbId;
				TargetList.Add(t);
			}
			SelectedTargetItem = TargetList.FirstOrDefault();

			var cspList = sHandler.GetCShootingPositionUsedOnlyList();
			CShootingPositionList = new List<DropDownItemModel>();
			foreach (var item in cspList)
			{
				var csp = new DropDownItemModel();
				csp.Name = item.Name;
				csp.Description = item.Description;
				csp.DbId = item.DbId;
				CShootingPositionList.Add(csp);
			}
			SelectedCShootingPositionItem = CShootingPositionList.FirstOrDefault();



			/****************************
			 * 
			 *   RECORD
			 * 
			 ***************************/
			var weaponBoList = wHandler.GetWeaponProfileList();
			WeaponProfileList = new List<DropDownItemModel>();
			foreach (var item in weaponBoList)
			{
				var weapon = new DropDownItemModel();
				weapon.Name = item.ProfileName;
				weapon.Description = item.Description;
				weapon.DbId = item.ProfileDdId;
				WeaponProfileList.Add(weapon);
			}
			SelectedWeaponProfileItem = _weaponProfileList.FirstOrDefault();



			var munitionBoList = mHandler.GetUsedOnlyListByCaliberList(wHandler.GetWeaponProfile(SelectedWeaponProfileItem.DbId).CCaliberBoList);
			MunitionList.Clear();
			foreach (var item in munitionBoList)
			{
				var m = new DropDownItemModel();
				m.Name = item.Name;
				m.Description = item.Description;
				m.DbId = item.DbId;

				MunitionList.Add(m);
			}
			SelectedMunitionItem = _munitionList.FirstOrDefault();

			RecordModelList = new ObservableCollection<RecordModel>();

			setDefaultValues();
		}

		partial void OnSelectedWeaponProfileItemChanged(DropDownItemModel value)
		{
			if (value == null)
			{
				return;
			}

			var tt = wHandler.GetWeaponProfile(value.DbId).CCaliberBoList;
			var aa = mHandler.GetUsedOnlyListByCaliberList(tt);
			var munitionBoList = mHandler.GetUsedOnlyListByCaliberList(wHandler.GetWeaponProfile(value.DbId).CCaliberBoList);
			MunitionList.Clear();
			foreach (var item in munitionBoList)
			{
				var m = new DropDownItemModel();
				m.Name = item.Name;
				m.Description = item.Description;
				m.DbId = item.DbId;

				MunitionList.Add(m);
			}
			//_selectedMunitionItem = null;
			SelectedMunitionItem = MunitionList.FirstOrDefault();
		}


		[RelayCommand]
		private void btnAddRecordOnClick()
		{
			var tt = new RecordModel();
			tt.Shots = Shots;
			tt.Score = Score;
			tt.TempId = getTempId();


			if (!(Shots < 1))
			{
				RecordModelList.Add(tt);
			}
			clearRecord();
			//RecordModelList.Add(tt);
		}

		[RelayCommand]
		private void btnDeleteRecord(int tempId)
		{
			var item = RecordModelList.FirstOrDefault(x => x.TempId.Equals(tempId));
			RecordModelList.Remove(item);
		}

		private void clearRecord()
		{
			Shots = 10;
			Score = 0;
			
		}

		private int tmpId = 0;
		private int getTempId()
		{
			tmpId++;
			return tmpId;
		}

		private void setDefaultValues()
		{
			ScoreMax = 10;
			RoundsMax = 50;

			Shots = 10;
			Score = 0;


		}
	}
}
