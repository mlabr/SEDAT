using SQLite;

namespace DataLayer.Entities
{
	[Table("ProfileSights")]
	public class ProfileSights
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int? ProfileSightsId { get; set; }

		[NotNull]
		public int WeaponProfileId { get; set; }

		[NotNull]
		public int SightsId { get; set; }
    }
}
