using Business.BusinessObjects.CodeList;
using DataLayer.Entities.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
	internal static class Mapper
	{
		internal static CPowerPrincipleBo CPowerPrincipleToCPowerPrincipleBo(CPowerPrinciple item)
		{
			var bo = new CPowerPrincipleBo();
			bo.DbId = item.CPowerPrincipleId;
			bo.ParentDbId = item.CPowerPrincipleParrentId;
			bo.Name = item.Name;
			bo.Description = item.Description;
			bo.Note = item.Note;
			bo.IsUsed = item.IsUsed;

			return bo;
				
		}
	}
}
