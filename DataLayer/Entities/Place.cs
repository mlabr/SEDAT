using SQLite;

namespace DataLayer.Entities
{
	[Table("Place")]
	public class Place : EntityBase
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int PlaceId { get; set; }

        public string Name { get; set; }

		public string Description { get; set; }

    }
}
