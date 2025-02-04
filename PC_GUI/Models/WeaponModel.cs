using Business.BusinessObjects.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Models
{
	public class WeaponModel
	{
        public int ProfileDbId { get; set; }

        public int WeaponDbId { get; set; }

		public string Name { get; set; }

        public string WeaponProfileName { get; set; }

		public string Identification { get; set; }
		public string Caliber { get; internal set; }

		public WeaponModel()
        {
            ProfileDbId = 0;
            Name = string.Empty;
            Identification = string.Empty;
        }
    }
}
