using Business.BusinessObjects.CodeList;
using Business.Mapping;
using DataLayer.Repositories.CodeListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.CodeHandlers
{
	public class CDisciplineTypeHandler : ICodeHandler<CDisciplineTypeBo>
	{

		private CDisciplineRepository repo;
		public CDisciplineTypeHandler()
		{
			repo = new CDisciplineRepository();
		}

		public List<CDisciplineTypeBo> GetAllList()
		{
			var list = repo.GetAllList();
			var boList = new List<CDisciplineTypeBo>();
			boList = Mapper.Code.DisciplineType.CDisciplineListToCDisciplineBoList(list);
			return boList;
		}

		public List<CDisciplineTypeBo> GetUsedOnlyList()
		{
			var list = repo.GetUsedOnlyList();
			var boList = new List<CDisciplineTypeBo>();
			boList = Mapper.Code.DisciplineType.CDisciplineListToCDisciplineBoList(list);
			return boList;
		}
	}
}
