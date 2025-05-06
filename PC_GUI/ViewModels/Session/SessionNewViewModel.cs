using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.Handlers;
using Business.Parsers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Mapping;
using PC_GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PC_GUI.ViewModels.Session
{
	internal partial class SessionNewViewModel : SessionViewModelBase
	{
		private SeriesHandler serHandler;
		private MunitionHandler mHandler;
		private WeaponHandler wHandler;
		private SessionHandler sesHandler;

		//Note: workaround
		[ObservableProperty]
		private DropDownItemModel? _selectedWeaponProfileItem;





		public SessionNewViewModel(MainWindowViewModel model)
		{
			serHandler = new SeriesHandler();
			wHandler = new WeaponHandler();
			mHandler = new MunitionHandler();
			sesHandler = new SessionHandler();

			var pHandler = new PlaceHandler();
			var placeBoList = pHandler.GetAll();


			/****************************
			 * 
			 *   SESSION
			 * 
			 ***************************/

			var list = serHandler.GetUsedOnlyList();
			var modelList = Mapper.DropDown.SeriesBoListToSeriesDropDownModelList(list);

			SeriesDropdownModelList = new ObservableCollection<DropDownItemModel>(modelList);
			SelectedSeries = SeriesDropdownModelList.FirstOrDefault();


			PlaceList = new List<DropDownItemModel>();
			foreach (var item in placeBoList)
			{
				var place = new DropDownItemModel();
				place.Name = item.Name;
				place.Description = item.Description;
				place.DbId = item.DbId;
				PlaceList.Add(place);
			}
			SelectedPlaceItem = PlaceList.FirstOrDefault();

			/****************************
			 * 
			 *   DISCIPLINE
			 * 
			 ***************************/
			var cDList = sesHandler.GetCDisciplineUsedOnlyList();
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

			var tList = sesHandler.GetTargetUsedOnlyList();
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

			var cspList = sesHandler.GetCShootingPositionUsedOnlyList();
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
			SelectedWeaponProfileItem = WeaponProfileList.FirstOrDefault();



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
			SelectedMunitionItem = MunitionList.FirstOrDefault();

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
		private void btnSaveSession()
		{
			//SessionNewViewModel model = this;
			var sessionBo = Mapper.SessionMapper.SessionNewViewModelToSessionBo(this);
			foreach (var item in RecordModelList)
			{
				var bo = new RecordBo();
				bo.Score = item.Score;
				bo.ShotsCount = item.ShotsCount;
				bo.WeaponProfileId = SelectedWeaponProfileItem.DbId;
				sessionBo.DisciplineBoList.FirstOrDefault().RecordBoList.Add(bo);
			}
			var stop = 0;
			
			sesHandler.InsertSession(sessionBo);
		}


		[RelayCommand]
		private void btnAddTempRecordOnClick()
		{
			var rm = new RecordModel();
			rm.ShotsCount = Shots;
			rm.Score = Score;
			rm.TimeStartSpan = TimeStart;
			rm.TimeEndSpan = TimeEnd;
			//rm.TimeStart = "";
			//rm.TimeEnd = "";
			rm.TempId = getTempId();


			if (!(Shots < 1))
			{
				RecordModelList.Add(rm);
			}
			clearTempRecord();

			ScoreTotal = 0;
			ShotsTotal = 0;
			foreach (var item in RecordModelList)
			{
				ScoreTotal += item.Score;
				ShotsTotal += item.ShotsCount;
			}

			
			//RecordModelList.Add(tt);
		}

		[RelayCommand]
		private void btnDeleteTempRecord(int tempId)
		{
			var item = RecordModelList.FirstOrDefault(x => x.TempId.Equals(tempId));
			RecordModelList.Remove(item);
			refreshTempRecordList();
		}


		private void refreshTempRecordList()
		{
			var list = new List<RecordModel>();
			var count = 0;
			foreach (var model in RecordModelList)
			{
				count++;
				model.TempId = count;
				list.Add(model);
			}
			tmpId = 0;
			RecordModelList = new ObservableCollection<RecordModel>(list);
		}

		private int tmpId = 0;
		private int getTempId()
		{
			tmpId++;
			return tmpId;
		}


		private void clearTempRecord()
		{
			Shots = 10;
			Score = 0;

		}

		private void setDefaultValues()
		{
			ScoreMax = "10";
			RoundsMax = "50";

			Shots = 10;
			Score = 0;


		}
	}
}
