using Business.BusinessObjects.CodeList;
using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Models;
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
		private MunitionHandler mHandler;
		private WeaponHandler wHandler;
		private SessionHandler sHandler;

		[ObservableProperty]
		public int _eventId;

		[ObservableProperty]
		public string _eventName = "";

		[ObservableProperty]
		public string _sessionName = "";

		[ObservableProperty]
		public string _sessionDescription = "";

		[ObservableProperty]
		public string _sessionNote = "";

		[ObservableProperty]
		public DateTimeOffset _sessionDateStart = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public DateTimeOffset _sessionDateEnd = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public bool _isSessionDateEndEnabled = false;

		[ObservableProperty]
		public List<DropDownItemModel> _placeList;

		[ObservableProperty]
		public DropDownItemModel? _selectedPlaceItem;


		[ObservableProperty]
		public string _disciplineDescription = "";

		[ObservableProperty]
		public string _disciplineNote = "";

		[ObservableProperty]
		public List<DropDownItemModel> _cDisciplineList;

		[ObservableProperty]
		public DropDownItemModel _selectedCDisciplineItem;


		[ObservableProperty]
		public DateTimeOffset _eventDate = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public bool _isEventDateSameAsSessionDate = true;

		[ObservableProperty]
		public int _scoreMax = 0;

		[ObservableProperty]
		public int _roundsMax = 0;





		[ObservableProperty]
		public List<DropDownItemModel> _weaponProfileList;

		[ObservableProperty]
		public DropDownItemModel? _selectedWeaponProfileItem;

		[ObservableProperty]
		public ObservableCollection<DropDownItemModel> _munitionList = new ObservableCollection<DropDownItemModel>();

		[ObservableProperty]
		public DropDownItemModel? _selectedMunitionItem;

		[ObservableProperty]
		public ObservableCollection<RecordModel> _recordModelList;

		[ObservableProperty]
		public int _score = 0;

		[ObservableProperty]
		public int _shots = 0;

		public SessionNewViewModel(MainWindowViewModel model)
		{

			wHandler = new WeaponHandler();
			mHandler = new MunitionHandler();
			sHandler = new SessionHandler();

			var pHandler = new PlaceHandler();
			var placeBoList = pHandler.GetAll();

			_placeList = new List<DropDownItemModel>();
			foreach (var item in placeBoList)
			{
				var place = new DropDownItemModel();
				place.Name = item.Name;
				place.Description = item.Description;
				place.DbId = item.PlaceId;
				_placeList.Add(place);
			}
			_selectedPlaceItem = _placeList.FirstOrDefault();


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
