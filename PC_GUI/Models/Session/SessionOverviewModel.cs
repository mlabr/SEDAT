using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models.Session
{
	public class SessionOverviewModel
	{
		public string Name { get; set; }

		public string SeriesName { get; set; }

		public string SeriesToolTip { get; set; }

		public DateTimeOffset DateStart { get; set; }

		public DateTimeOffset DateEnd { get; set; }

		public string DisciplineName { get; set; }

		public string DisciplineTooltip { get; set; }

		public string PlaceName { get; set; }
	}
}
