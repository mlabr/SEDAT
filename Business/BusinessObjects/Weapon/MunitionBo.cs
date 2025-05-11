using Business.BusinessObjects.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessObjects.Weapon
{
	public class MunitionBo : CodeBoBase
	{
		public int CaliberId { get; set; }

		public CaliberBo CaliberBo { get; set; }
	}
}
