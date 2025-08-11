using Avalonia.Controls;
using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.Handlers;
using Business.Handlers.WeaponHandlers;
using Business.Parsers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Mapping;
using PC_GUI.Models;
using PC_GUI.Models.Session;
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

		[ObservableProperty]
		private TimeSpan? _recordTimeStart;

		[ObservableProperty]
		private TimeSpan? _recordTimeEnd;



		//summary
		private RecordSummaryModel summary;

		[ObservableProperty]
		private string _scorePercent = "0 %";

		[ObservableProperty]
		private string _scoreTotal = "0/0";

		[ObservableProperty]
		private string _shotsTotal = "0/0";

		[ObservableProperty]
		private BatchDataViewModel _batchData;

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
			summary = new RecordSummaryModel();
			_batchData = new BatchDataViewModel();

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

			BatchDataModelList = new ObservableCollection<BatchDataViewModel>();

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

			var bor = new RecordBo();

			bor.WeaponProfileId = SelectedWeaponProfileItem.DbId;

			if (BatchDataModelList.Any())
			{
				if(BatchDataModelList.Count < 2)
				{
					//no data
					//bor.Score = BatchDataModelList.FirstOrDefault().Score;
					//bor.ShotsCount = BatchDataModelList.FirstOrDefault().ShotsCount;
					//bor.XCount = BatchDataModelList.FirstOrDefault().XCount;
				}
				else
				{
					// batch type data
					foreach (var item in BatchDataModelList)
					{
						bor.Score += item.Score;
						bor.ShotsCount += item.ShotsCount;
						bor.XCount += item.Score;
					}
					//TODO: Make this to data json

				}
			}
			else
			{
				//bor.Score = Score;
				//bor.ShotsCount = Shots;
				//bor.XCount = BatchDataModelList.FirstOrDefault().XCount;
			}
			//bor.Score = ScoreTotal;
			//bor.ShotsCount = ShotsTotal;
			bor.TimeStart = RecordTimeStart;
			bor.TimeEnd = RecordTimeEnd;
			sessionBo.DisciplineBoList.FirstOrDefault().RecordBoList.Add(bor);


			var stop = 0;
			
			//sesHandler.InsertSession(sessionBo);
		}


		[RelayCommand]
		private void btnAddBatchDataOnClick()
		{
			var batch = new BatchDataViewModel();
			batch.ShotsCount = BatchData.ShotsCount;
			batch.Score = BatchData.Score;
			batch.XCount = BatchData.XCount;
			batch.TempId = getTempId();

			if (!(BatchData.ShotsCount < 1))
			{
				BatchDataModelList.Add(batch);
			}
			//clearTempRecord();
			updateTemporaryRecordValues();
			
			//RecordModelList.Add(tt);
		}

		[RelayCommand]
		private void btnDeleteTempRecord(int tempId)
		{
			var item = BatchDataModelList.FirstOrDefault(x => x.TempId.Equals(tempId));
			BatchDataModelList.Remove(item);
			refreshTempRecordList();
		}


		private void refreshTempRecordList()
		{
			var list = new List<BatchDataViewModel>();
			var count = 0;
			foreach (var model in BatchDataModelList)
			{
				count++;
				model.TempId = count;
				list.Add(model);
			}
			tmpId = 0;
			BatchDataModelList = new ObservableCollection<BatchDataViewModel>(list);
			updateTemporaryRecordValues();
		}

		private int tmpId = 0;
		private int getTempId()
		{
			tmpId++;
			return tmpId;
		}


		private void clearTempRecord()
		{
			BatchData.ShotsCount = 10;
			BatchData.Score = 0;
			BatchData.XCount = 0;
			ScorePercent = "0.00 %";
			ShotsTotal = "0";
			summary.ShotsCurrentCount = 0;
			summary.Score = 0;
			summary.XCount = 0;
		}

		private void updateTemporaryRecordValues()
		{
			clearTempRecord();
			
			foreach (var item in BatchDataModelList)
			{
				summary.ShotsCurrentCount += item.ShotsCount;
				summary.Score += item.Score;
				
			}
			
			if (summary.ShotsCurrentCount > 0)
			{
				ScorePercent = ((summary.Score * 10.0) / summary.ShotsCurrentCount).ToString("F2") +" %";
			}

			ScoreTotal = summary.Score.ToString();
			ShotsTotal = summary.ShotsCurrentCount.ToString();

		}

		private void setDefaultValues()
		{
			ScoreMax = "10";
			RoundsMax = "50";


			BatchData.ShotsCount = 10;
			BatchData.Score = 0;



		}
	}
}
