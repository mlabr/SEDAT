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

		public CSightsBo CSights { get; set; } = new CSightsBo();
		public bool IsExisting { get; set; } = true;

		public int CSightsType { get; set; } = 1;
	}
}
