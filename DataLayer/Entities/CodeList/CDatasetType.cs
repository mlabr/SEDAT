using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.CodeList
{
	[Table("CDatasetType")]
	public class CDatasetType : EntityCodeBase
	{
		[PrimaryKey]
		public int CDatasetTypeId { get; set; }

	}
}
