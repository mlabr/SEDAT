using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects
{
	public class DisciplineBo
	{
		public DisciplineBo()
		{
			RecordBoList = new List<RecordBo>();
		}

		public int DbId { get; set; }

		public int CDisciplineTypeId { get; set; }

		public int CShootingPositionId { get; set; }

		public int TargetId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Note { get; set; }

		public float Range { get; set; }

		public bool IsRangeInMeters { get; set; }

		public float ScoreMax { get; set; }

		public int ShotsMax { get; set; }

		public DateTimeOffset Date { get; set; }


		public List<RecordBo> RecordBoList { get; set; }
	}
}
