using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models
{
	public class WeaponModel
	{
        public int Id { get; set; }

		public string Name { get; set; }

		public string Identification { get; set; }

        public WeaponModel()
        {
            Id = 0;
            Name = string.Empty;
            Identification = string.Empty;
        }
    }
}
