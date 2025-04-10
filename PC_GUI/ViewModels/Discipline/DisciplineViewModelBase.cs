using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Session
{
	internal partial class DisciplineViewModelBase : RecordViewModelBase
	{
		/****************************
		 * 
		 *   DISCIPLINE
		 * 
		 ***************************/


		[ObservableProperty]
		private string _disciplineName = "";

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
		private DateTimeOffset _disciplineDate = new DateTimeOffset(DateTime.Now);

		[ObservableProperty]
		private bool _isDisciplineDateSameAsSessionDate = true;

		[ObservableProperty]
		private string _scoreMax = "0";

		[ObservableProperty]
		private string _range = "10.0";

		[ObservableProperty]
		private bool _rangeIsInMeters = true;

		[ObservableProperty]
		private string _roundsMax = "0";

		[ObservableProperty]
		private List<DropDownItemModel> _targetList;

		[ObservableProperty]
		private DropDownItemModel _selectedTargetItem;
	}
}
