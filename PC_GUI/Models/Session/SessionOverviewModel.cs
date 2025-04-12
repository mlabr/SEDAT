using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models.Session
{
	internal class SessionOverviewModel
	{
		public string Name { get; set; }

		public string SeriesName = "";

		public string SeriesToolTip = "";

		public DateTimeOffset DateStart;

		public DateTimeOffset DateEnd;

		public string DisciplineName = "";

		public string DisciplineTooltip = "";

		public string PlaceName = "";
	}
}
