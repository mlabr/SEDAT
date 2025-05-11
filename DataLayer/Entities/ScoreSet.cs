using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	[Table("ScoreSet")]
	public class ScoreSet
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int ScoreSetId { get; set; }

		[NotNull]
		public int RecordId { get; set; }

		[NotNull]
		public float Score { get; set; }

		[NotNull]
		public int ShotsCount { get; set; }
	}
}
