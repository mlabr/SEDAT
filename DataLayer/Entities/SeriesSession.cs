using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class SeriesSession
	{
		[PrimaryKey, AutoIncrement]
		public int SeriesSessionId { get; set; }

		public int SessionId { get; set; }

		public int SeriesId { get; set; }	
    }
}
