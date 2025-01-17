using Business.BusinessObjects.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects.Weapon
{
	public class SightsBo : CodeBoBase
	{
		public SightsBo()
		{
			CSightsType = new CSightsTypeBo();
			IsExisting = true;

		}

		public CSightsTypeBo CSightsType { get; set; }
		public bool IsExisting { get; set; }

	}
}
