using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	[Table("Maintenance")]
	public class Maintenance
	{
		[PrimaryKey, AutoIncrement]
		public int MaintenanceId { get; set; }

		[NotNull]
		public int WeaponProfileId { get; set; }

		public string Description { get; set; }

		public string  Date { get; set; }
	}
}
