using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.CodeList
{
	[Table("CFiringMode")]
	public class CFiringMode : EntityCodeBase
	{
        [PrimaryKey]
        public int CFiringModeId { get; set; }

    }
}
