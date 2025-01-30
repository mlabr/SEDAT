using SQLite;

namespace DataLayer.Entities
{
	[Table("ProfileCCaliber")]
	public class ProfileCCaliber
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int? ProfileCCaliberId { get; set; }

		[NotNull]
        public int WeaponProfileId { get; set; }

		[NotNull]
		public int CCaliberId { get; set; }

    }
}
