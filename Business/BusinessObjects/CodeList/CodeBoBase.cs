using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects.CodeList
{
	public class CodeBoBase
	{
		public int DbId { get; set; } = 1; //default value

		public string Name { get; set; }

		public string Description { get; set; }

		public string Note { get; set; }

		public int Priority { get; set; }

		public bool IsUsed { get; set; }

	}
}
