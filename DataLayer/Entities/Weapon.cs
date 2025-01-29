using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DataLayer.Entities
{
	[SQLite.Table("Weapon")]
	public class Weapon : EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int? WeaponId { get; set; }

        public string Name { get; set; }

        public string Identification { get; set; }

		[ForeignKey(typeof(Person))]
        public int PersonId { get; set; }

		
		[Ignore]
        public Person Person {get; set; }


    }
}
