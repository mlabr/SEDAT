using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models.Session
{
	internal class RecordBatchDataModel
	{
		public int TempId { get; set; }

		public int Score { get; set; }

		public int XCount { get; set; }

		public int ShotsCount { get; set; }

		public string Data { get; set; }
	}
}
