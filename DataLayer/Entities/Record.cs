using SQLite;

namespace DataLayer.Entities
{
	[Table("Record")]
	public class Record : EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int RecordId { get; set; }

		public int DisciplineId { get; set; }

		public int PersonId { get; set; }

		public int WeaponProfileId { get; set; }

		public int MunitionId { get; set; }

		public int SightsId { get; set; }

		public float Score { get; set; }

		public int ShotsCount { get; set; }

		public int XCount { get; set; }

		public string TimeStart { get; set; }

		public string TimeEnd { get; set; }


		public string Data { get; set; }

	}
}
