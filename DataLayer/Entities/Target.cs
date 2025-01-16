using SQLite;

namespace DataLayer.Entities
{
	[Table("Target")]
	public class Target : EntityBase
	{
		[PrimaryKey]
        public int TargetId { get; set; }

		[NotNull, Unique]
        public string Name { get; set; }

		public string Description { get; set; }

		public string Data { get; set; }
    }
}
