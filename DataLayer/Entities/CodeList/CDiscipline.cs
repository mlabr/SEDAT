using SQLite;

namespace DataLayer.Entities.CodeList
{

	[Table("CDiscipline")]
	public class CDiscipline : EntityCodeBase
    {
        [PrimaryKey]
        public int CDisciplineId { get; set; }

    }
}
