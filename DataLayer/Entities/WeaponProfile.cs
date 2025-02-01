using DataLayer.Entities.CodeList;
using SQLite;

namespace DataLayer.Entities
{
	[Table("WeaponProfile")]
	public class WeaponProfile : EntityBase
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int? WeaponProfileId { get; set; }

        public string Name { get; set; }

        public int WeaponId { get; set; }

        public int CWeaponTypeId { get; set; }

        public int CPowerPrincipleId { get; set; }

		public int CFiringModeId { get; set; }

		[Ignore]
        public Weapon Weapon { get; set; }

        [Ignore]
        public CWeaponType CWeaponType { get; set; }

        [Ignore]
        public CPowerPrinciple CPowerPrinciple { get; set; }

        [Ignore]
        public CFiringMode CFiringMode { get; set; }

        [Ignore]
        public List<CCaliber> CCaliberList { get; set; }

        [Ignore]
        public List<Sights> SightsList { get; set; }



    }
}
