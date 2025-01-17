using Business.BusinessObjects.CodeList;
using Business.Mapping;
using DataLayer.Repositories.CodeListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.CodeHandler
{
	public class CSightsHandler : CodeBoBase
	{
		private readonly MapperService _mapService;
		public List<CSightsTypeBo> GetAll()
		{
			var repo = new CSightsRepository();

			var csightsList = repo.GetAllList();

			var boList = new List<CSightsTypeBo>();

			foreach (var csight in csightsList)
			{

				//var bo = _mapService.CSightToCSightsBo(csight);
				var bo = new CSightsTypeBo();
				bo.Name = csight.Name;
				bo.Description = csight.Description;
				bo.Note = csight.Note;
				bo.IsUsed = csight.IsUsed;
				boList.Add(bo);
			}

			return boList;
		}
	}
}
