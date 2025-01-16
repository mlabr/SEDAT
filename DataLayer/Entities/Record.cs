using SQLite;

namespace DataLayer.Entities
{
	[Table("Record")]
	public class Record : EntityBase
	{
		[PrimaryKey]
		public int RecordId { get; set; }

	}
}
