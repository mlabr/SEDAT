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
	public class EventDbHandler
	{
		private ICodeRepository<Event> repo;

		public EventDbHandler()
		{
			repo = new EventRepository();
		}

		public List<EventBo> GetUsedOnlyList()
		{
			var items = repo.GetUsedOnlyList();
			var list = new List<EventBo>();
			foreach (var item in items)
			{
				var bo = new EventBo();
				bo.Name = item.Name;
				bo.DbId = item.EventId;
				list.Add(bo);
			}

			return list;
		}

	}
}
