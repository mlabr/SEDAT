using Business.BusinessObjects.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects
{
	public class WeaponBo
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public CFiringModeBo CFiringMode { get; set; } = new CFiringModeBo();

		public CPowerPrincipleBo PowerPrinciple { get; set; } = new CPowerPrincipleBo();

		public CWeaponTypeBo WeaponType { get; set; } = new CWeaponTypeBo();
	}
}
