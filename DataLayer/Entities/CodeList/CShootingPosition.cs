using SQLite;


namespace DataLayer.Entities.CodeList
{
	[Table("CShootingPosition")]
	public class CShootingPosition : EntityCodeBase
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int CShootingPositionId { get; set; }

    }
}
