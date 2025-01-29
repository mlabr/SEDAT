using SQLite;

namespace DataLayer.Entities
{
	[Table("ProfileCCaliber")]
	public class ProfileCCaliber
	{
		[PrimaryKey]
		public int ProfileCCaliberId { get; set; }

		[NotNull]
        public int WeaponProfileId { get; set; }

		[NotNull]
		public int CCaliberId { get; set; }

    }
}
