using SQLite;

namespace DataLayer.Entities
{
	[Table("ProfileCCaliber")]
	public class ProfileCCaliber
	{
		[PrimaryKey]
		public int ProfileCCaliberId { get; set; }

        public int WeaponProfileId { get; set; }

        public int CCaliberId { get; set; }

    }
}
