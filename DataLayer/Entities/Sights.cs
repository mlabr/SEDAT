using DataLayer.Entities.CodeList;
using SQLite;

namespace DataLayer.Entities
{
	[Table("Sights")]
	public class Sights : EntityBase
	{
		[PrimaryKey]
		public int SightsId { get; set; }

        public string Name { get; set; }

        public int CSightsId { get; set; }

        public string  Description { get; set; }

		[Ignore]
        public CSights CSights { get; set; }
    }
}
