using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using DataLayer.Entities;
using DataLayer.Repositories;
using DataLayer.Repositories.CodeListRepository;

namespace Business.Handlers
{
	public class SessionHandler
	{


		public SessionHandler() { }


		public void InsertSession(SessionBo bo)
		{
			var repo = new SessionRepository();

			var session = new Session();


			//mapping

			session.Name = bo.Name;
			session.PlaceId = bo.PlaceId;
			session.Description = bo.Description;
			session.DateStart = bo.DateStart;
			session.DateEnd = bo.DateEnd;
			session.Note = bo.Note;
			session.IsUsed = bo.IsUsed;
			


			repo.InsertSession(session);
		}

		public List<CDisciplineBo> GetCDisciplineUsedOnlyList()
		{
			var list = new List<CDisciplineBo>();
			var repo = new CDisciplineRepository();
			var items = repo.GetUsedOnlyList();

			foreach (var item in items)
			{
				var cd = new CDisciplineBo();
				cd.DbId = item.CDisciplineId;
				cd.Name = item.Name;
				cd.Description = item.Description;
				cd.Note = item.Note;
				cd.Priority = item.Priority;

				list.Add(cd);

			}
			list.OrderBy(x => x.Priority);

			return list;
		}

	}
}
