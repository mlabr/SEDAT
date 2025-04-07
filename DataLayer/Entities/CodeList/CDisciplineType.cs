using SQLite;

namespace DataLayer.Entities.CodeList
{

	[Table("CDisciplineType")]
	public class CDisciplineType : EntityCodeBase
    {
        [PrimaryKey]
        public int CDisciplineTypeId { get; set; }

    }
}
