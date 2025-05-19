using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Criteria
{
	public class CriteriaBase
	{
		private int dbId;

		public int DbId
		{
			get
			{
				return dbId;
			}
			set
			{
				dbId = value;
				IsDbIdSelected = true;
				if (dbId < 1)
				{
					IsDbIdSelected = false;
				}
			}
		}

		public bool IsDbIdSelected { get; private set; } = false;


		public bool IsUsedOnlySelected { get; set; } = false;
	}
}
