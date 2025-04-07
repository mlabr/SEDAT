using Business.BusinessObjects.CodeList;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories.CodeListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers
{
	public class SeriesHandler
	{
		private ICodeRepository<Series> repo;

		public SeriesHandler()
		{
			repo = new EventRepository();
		}

		public List<SeriesBo> GetUsedOnlyList()
		{
			var items = repo.GetUsedOnlyList();
			var list = new List<SeriesBo>();
			foreach (var item in items)
			{
				var bo = new SeriesBo();
				bo.Name = item.Name;
				bo.DbId = item.SeriesId;
				list.Add(bo);
			}

			return list;
		}

	}
}
