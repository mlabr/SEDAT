using DataLayer.Entities.CodeList;
using SQLite;


namespace DataLayer.Entities
{
	[Table("Munition")]
	public class Munition : EntityBase
	{
		[PrimaryKey]
		public int MunitionId { get; set; }

        public int CCaliberId { get; set; }

        public string Name { get; set; }

		public string Description { get; set; }

		[Ignore]
        public CCaliber CCaliber { get; set; }
    }
}
