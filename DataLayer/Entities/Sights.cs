using DataLayer.Entities.CodeList;
using SQLite;

namespace DataLayer.Entities
{
	[Table("Sights")]
	public class Sights : EntityBase
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int? SightsId { get; set; }

        public string Name { get; set; }

        public int CSightsTypeId { get; set; }

        public string  Description { get; set; }

		[Ignore]
        public CSightsType CSightsType { get; set; }

		[Ignore]
		public int Id { get; set; }
    }
}
