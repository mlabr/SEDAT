using Business.BusinessObjects.CodeList;
using DataLayer.Entities.CodeList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
	internal static partial class Mapper
	{
		internal static class Code
		{
			internal static class DisciplineType
			{

				internal static CDisciplineTypeBo CDisciplineToCDisciplineBo(CDisciplineType item)
				{
					var bo = new CDisciplineTypeBo();
					bo.DbId = item.CDisciplineTypeId;
					bo.Name = item.Name;
					bo.Priority = item.Priority;
					bo.Description = item.Description;
					bo.Note = item.Note;
					bo.IsUsed = item.IsUsed;

					return bo;

				}

				internal static List<CDisciplineTypeBo> CDisciplineListToCDisciplineBoList(List<CDisciplineType> list)
				{
					var boList = new List<CDisciplineTypeBo>();

					foreach (var item in list)
					{
						var bo = new CDisciplineTypeBo();
						bo.DbId = item.CDisciplineTypeId;
						bo.Name = item.Name;
						bo.Priority = item.Priority;
						bo.Description = item.Description;
						bo.Note = item.Note;
						bo.IsUsed = item.IsUsed;
						boList.Add(bo);
					}
					boList.OrderBy(x => x.Priority).ToList();

					return boList;

				}
			}



		}
	}
}
