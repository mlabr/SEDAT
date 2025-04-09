using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers
{
	public class HandlerBase
	{
		public bool IsNewItem(int id)
		{
			if(id > 0)
			{
				return false;
			}

			return true;

		}
	}
}
