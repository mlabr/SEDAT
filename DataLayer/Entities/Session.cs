using SQLite;

namespace DataLayer.Entities
{
	[Table("Session")]
	public class Session : EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int? SessionId { get; set; }

        public int PlaceId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

        public string DateStart { get; set; }

		public string DateEnd { get; set; }

		[Ignore]
		public Place Place { get; set; }

    }
}
