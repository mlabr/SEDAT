using SQLite;

namespace DataLayer.Entities
{
	[Table("ProfileCaliber")]
	public class ProfileCaliber
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int? ProfileCCaliberId { get; set; }

		[NotNull]
        public int WeaponProfileId { get; set; }

		[NotNull]
		public int CaliberId { get; set; }

    }
}
