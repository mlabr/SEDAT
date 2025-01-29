using DataLayer.Entities.CodeList;
using SQLite;

namespace DataLayer.Entities
{
	[Table("Discipline")]
	public class Discipline : EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int DisciplineId { get; set; }

        public int CDisciplineId { get; set; }

        public int CShootingPositionId { get; set; }

        public int TargetId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Range { get; set; }

        public double ScoreMax { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly TimeStart { get; set; }

        public TimeOnly TimeEnd { get; set;}

        [Ignore]
        public CDiscipline  CDiscipline { get; set; }

        [Ignore]
        public Target Target { get; set; }

        [Ignore]
        public Session Session { get; set; }

        [Ignore]
        public CShootingPosition CShootingPosition { get; set; }



    }
}
