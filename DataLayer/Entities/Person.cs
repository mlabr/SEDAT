using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DataLayer.Entities
{
	[Table("Person")]
	public class Person
	{
		[PrimaryKey, AutoIncrement]
		public int PersonId { get; set; }

		[NotNull, Unique]
		public string Nickname { get; set; }

		public string Firstame { get; set; }

        public string Surname { get; set; }

        public string Note { get; set; }

		[NotNull]
        public bool IsUsed { get; set; }

		[OneToMany]
		public List<Weapon> Weapons { get; set; }
    }
}
