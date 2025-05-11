using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.CodeList
{
	[Table("CScoreSupport")]
	public class CShootingSupport : EntityCodeBase
	{
		[PrimaryKey, NotNull, AutoIncrement]
		public int CShootingSupportId { get; set; }
	}
}
