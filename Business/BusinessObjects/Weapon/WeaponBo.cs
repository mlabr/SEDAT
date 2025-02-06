using Business.BusinessObjects.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects.Weapon
{
	public class WeaponBo
	{
		private static int _defaultDbValue = 1;

		public WeaponBo()
		{
			CCaliberBoList = new List<CCaliberBo>();
			CCaliberBoList.Add(new CCaliberBo());
			SightsBoList = new List<SightsBo>();
			SightsBoList.Add(new SightsBo());
		}


		public int ProfileDdId { get; set; }

		public string WeaponName { get; set; }

		public string ProfileName { get; set; }

		public string Identification { get; set; }

		public string Note { get; set; }

		public string Description { get; set; }

		public CWeaponTypeBo WeaponType { get; set; }

		public int CWeaponTypeCode { get; set; } = _defaultDbValue;

		public CPowerPrincipleBo PowerPrinciple { get; set; }

		public int CPowerPrincipleCode { get; set; } = _defaultDbValue;

		public CFiringModeBo CFiringMode { get; set; }
		public int CFiringModeCode { get; set; } = _defaultDbValue;

		public List<CCaliberBo> CCaliberBoList { get; set; }

		public List<SightsBo> SightsBoList { get; set; }

		public int MaintenanceIntervalDate { get; set; }

		public int MaintenanceIntervalShots { get; set; }

		public DateTimeOffset MaintenanceLastDate { get; set; }

	}
}
