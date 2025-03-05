using DataLayer.Entities.CodeList;
using SQLite;


namespace DataLayer.Entities
{
	[Table("Munition")]
	public class Munition : EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int MunitionId { get; set; }

        public int CaliberId { get; set; }

        public string Name { get; set; }

		public string Description { get; set; }

		[Ignore]
        public Caliber Caliber { get; set; }
    }
}
