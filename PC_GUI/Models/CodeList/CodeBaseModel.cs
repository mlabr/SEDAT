using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models.CodeList
{
	internal class CodeBaseModel
	{
		public int DbId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Note { get; set; }

		public int Priority { get; set; }

		public bool IsUsed { get; set; }
	}
}
