using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models.Session
{
	public class NewSessionModel
	{

		public string Name { get; set; }

		public string Description { get; set; }

		public DateOnly DateStart { get; set; }
	}
}
