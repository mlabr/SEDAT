using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models.Session
{
	internal partial class BatchDataViewModel : ViewModelBase
	{
		public int TempId { get; set; }

		[ObservableProperty]
		private int _score;

		[ObservableProperty]
		private int _xCount;

		[ObservableProperty]
		private int _shotsCount;

		public string Data { get; set; }
	}
}
