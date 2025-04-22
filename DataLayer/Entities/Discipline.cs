using DataLayer.Entities.CodeList;
using SQLite;

namespace DataLayer.Entities
{
	[Table("Discipline")]
	public class Discipline : EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int DisciplineId { get; set; }

        public int SessionId { get; set; }

        public int CDisciplineTypeId { get; set; }

        public int CShootingPositionId { get; set; }

        public int TargetId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Range { get; set; }

        public bool IsRangeInMeters { get; set; }

		public float ScoreMax { get; set; }

		public int Shotsmax { get; set; }

		public string Date { get; set; }

        public string TimeStart { get; set; }

        public string TimeEnd { get; set;}

		[Ignore]
		public List<Record> RecordList { get; set; } = new List<Record>();

		[Ignore]
        public CDisciplineType  CDiscipline { get; set; }

        [Ignore]
        public Target Target { get; set; }

        [Ignore]
        public Session Session { get; set; }

        [Ignore]
        public CShootingPosition CShootingPosition { get; set; }

	}
}
