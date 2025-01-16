using SQLite;

namespace DataLayer.Entities
{
	[Table("ProfileSights")]
	public class ProfileSights
	{
		[PrimaryKey]
		public int ProfileSightsId { get; set; }

        public int WeaponProfileId { get; set; }

        public int SightsId { get; set; }
    }
}
