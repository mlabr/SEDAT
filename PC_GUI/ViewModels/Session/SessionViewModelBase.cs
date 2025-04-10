using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Session
{
	internal partial class SessionViewModelBase : DisciplineViewModelBase
	{
		/****************************
		 * 
		 *   SESSION
		 * 
		 ***************************/

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

		public ObservableCollection<DropDownItemModel> SeriesDropdownModelList { get; set; }

		[ObservableProperty]
		private DropDownItemModel _selectedSeries;

		[ObservableProperty]
		private int _seriesId;

		[ObservableProperty]
		private string _seriesName = "";

		[ObservableProperty]
		private bool _isNewSeries = false;


		[ObservableProperty]
		private string _sessionName = "";

		[ObservableProperty]
		private string _sessionDescription = "";

		[ObservableProperty]
		private string _sessionNote = "";






		
	}
}
