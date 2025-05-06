using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models
{
	internal class RecordModel
	{	
		public int TempId { get; set; }

		public int Score { get; set; }

		public int ShotsCount { get; set; }

		public string TimeStart
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

		public string TimeEnd
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
