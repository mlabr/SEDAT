using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DataLayer.Entities
{
	[SQLite.Table("Weapon")]
	public class Weapon : EntityBase
	{
		[SQLite.PrimaryKey]
		public int WeaponId { get; set; }

        public string Name { get; set; }

        public string Identification { get; set; }

		[ForeignKey(typeof(Person))]
        public int PersonId { get; set; }

		
		[SQLite.Ignore]
        public Person Person {get; set; }


    }
}
