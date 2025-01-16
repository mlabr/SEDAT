using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class SessionGroup : EntityBase
	{
		[PrimaryKey]
		public int SessionGroupId { get; set; }

		public int SessionId { get; set; }

		public int GroupId { get; set; }	
    }
}
