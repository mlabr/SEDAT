using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Criteria
{
	public class MunitionCriteria
	{
		private int caliberId;

		public int CaliberId
		{ get
			{
				return caliberId;
			}
			set
			{
				caliberId = value;
				IsCaliberSelected = true;
				if (caliberId < 1)
				{
					IsCaliberSelected = false;
				}
			} 
		}

		public bool IsCaliberSelected { get; private set; } = false;
	}
}
