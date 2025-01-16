using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models
{
	internal class PersonModel
	{
		public int Id { get; set; }

		public string NickName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Note { get; set; }

		public bool IsUsed { get; set; }
	}
}
