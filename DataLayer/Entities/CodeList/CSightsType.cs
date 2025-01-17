using SQLite;

namespace DataLayer.Entities.CodeList
{
	[Table("CSightsType")]
	public class CSightsType : EntityCodeBase
	{
		[PrimaryKey]
        public int CSightsTypeId { get; set; }
    }
}
