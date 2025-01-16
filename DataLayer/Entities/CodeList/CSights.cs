using SQLite;

namespace DataLayer.Entities.CodeList
{
	[Table("CSights")]
	public class CSights : EntityCodeBase
	{
		[PrimaryKey]
        public int CSightsId { get; set; }
    }
}
