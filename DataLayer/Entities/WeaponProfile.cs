﻿using DataLayer.Entities.CodeList;
using SQLite;

namespace DataLayer.Entities
{
	[Table("WeaponProfile")]
	public class WeaponProfile : EntityBase
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int? WeaponProfileId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int WeaponId { get; set; }

        public int CWeaponTypeId { get; set; }

        public int CPowerPrincipleId { get; set; }

		public int CFiringModeId { get; set; }

		public int MaintenanceIntervalDate { get; set; }

		public int MaintenanceIntervalShots { get; set; }

		public string MaintenanceLastDate { get; set; }

		[Ignore]
        public Weapon Weapon { get; set; }

        [Ignore]
        public CWeaponType CWeaponType { get; set; }

        [Ignore]
        public CPowerPrinciple CPowerPrinciple { get; set; }

        [Ignore]
        public CFiringMode CFiringMode { get; set; }

        [Ignore]
        public List<Caliber> CaliberList { get; set; }

        [Ignore]
        public List<Sights> SightsList { get; set; }



    }
}
