using SQLite;

namespace DataLayer.Entities
{
	[Table("Record")]
	public class Record : EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int RecordId { get; set; }

	}
}
