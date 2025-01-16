using SQLite;


namespace DataLayer.Entities.CodeList
{
	[Table("CShootingPosition")]
	public class CShootingPosition : EntityCodeBase
	{
		[PrimaryKey]
		public int CShootingPositionId { get; set; }

    }
}
