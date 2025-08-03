using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects
{
	public class RecordBo
	{
		public int DbId { get; set; }

		public int WeaponProfileId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Note {  get; set; }

		public float Score { get; set; }

		public int ShotsCount { get; set; }

		public int XCount { get; set; }

		public TimeSpan? TimeStart { get; set; }

		public TimeSpan? TimeEnd { get; set; }

		public string Data { get; set; }

		public bool IsUsed { get; set; }

	}
}
