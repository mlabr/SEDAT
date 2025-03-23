using Business.Handlers;
using CommunityToolkit.Mvvm.ComponentModel;
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
		public DateTimeOffset _eventDate = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		public bool _isEventDateSameAsSessionDate = true;




		[ObservableProperty]
		public List<DropDownItemModel> _weaponProfileList;

		[ObservableProperty]
		public DropDownItemModel? _selectedWeaponProfileItem;

		[ObservableProperty]
		public ObservableCollection<DropDownItemModel> _munitionList = new ObservableCollection<DropDownItemModel>();

		[ObservableProperty]
		public DropDownItemModel? _selectedMunitionItem;

		public SessionNewViewModel(MainWindowViewModel model)
		{
			
			wHandler = new WeaponHandler();
			mHandler = new MunitionHandler();
			
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


			
			var weaponBoList = wHandler.GetWeaponProfileList();
			WeaponProfileList = new List<DropDownItemModel>();
			foreach (var item in weaponBoList)
			{
				var weapon = new DropDownItemModel();
				weapon.Name = item.ProfileName;
				weapon.Description = item.Description;
				weapon.DbId = item.ProfileDdId;
				_weaponProfileList.Add(weapon);
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


		}

		partial void OnSelectedWeaponProfileItemChanged(DropDownItemModel value)
		{
			if(value == null)
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
	}
}
