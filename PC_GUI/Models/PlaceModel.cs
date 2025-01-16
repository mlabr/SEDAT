using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models
{
	public class PlaceModel
	{
        public int DbId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsUsed { get; set; } 

        public int Order { get; set; }

		public string Note { get; internal set; }
	}
}
