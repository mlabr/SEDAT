﻿using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Models;
using PC_GUI.Models.Session;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Session
{
	internal partial class RecordViewModelBase : ViewModelBase
	{
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

		[ObservableProperty]
		private TimeSpan? _timeStart;

		[ObservableProperty]
		private TimeSpan? _timeEnd;

		//Auxiliery values, not stored in db.
		[ObservableProperty]
		private int _scoreTotal = 0;

		[ObservableProperty]
		private int _scorePercent = 0;

		[ObservableProperty]
		private int _shotsTotal = 0;

		public string TimeStartString
		{
			get
			{
				if (TimeStartSpan.HasValue)
				{
					//@"dd\.hh\:mm\:ss"
					return TimeStartSpan.Value.ToString(@"hh\:mm");
				}

				return string.Empty;
			}
			private set { }
		}

		public string TimeEndString
		{
			get
			{
				if (TimeStartSpan.HasValue)
				{
					return TimeEndSpan.Value.ToString(@"hh\:mm");
				}

				return string.Empty;
			}
			private set { }
		}


		public TimeSpan? TimeStartSpan { get; set; }

		public TimeSpan? TimeEndSpan { get; set; }
	}
}
