using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
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

		public List<CDisciplineTypeBo> GetCDisciplineUsedOnlyList()
		{
			var list = new List<CDisciplineTypeBo>();
			ICodeRepository<CDisciplineType> repo = new CDisciplineRepository();
			var items = repo.GetUsedOnlyList();

			foreach (var item in items)
			{
				var cd = new CDisciplineTypeBo();
				cd.DbId = item.CDisciplineTypeId;
				cd.Name = item.Name;
				cd.Description = item.Description;
				cd.Note = item.Note;
				cd.Priority = item.Priority;

				list.Add(cd);

			}
			list.OrderBy(x => x.Priority);

			return list;
		}

		public List<CDisciplineTypeBo> GetCDisciplineAllList()
		{
			var list = new List<CDisciplineTypeBo>();
			ICodeRepository<CDisciplineType> repo = new CDisciplineRepository();
			var items = repo.GetAllList();

			foreach (var item in items)
			{
				var cd = new CDisciplineTypeBo();
				cd.DbId = item.CDisciplineTypeId;
				cd.Name = item.Name;
				cd.Description = item.Description;
				cd.Note = item.Note;
				cd.Priority = item.Priority;

				list.Add(cd);

			}
			list.OrderBy(x => x.Priority);

			return list;
		}


		public List<CShootingPositionBo> GetCShootingPositionUsedOnlyList()
		{
			var list = new List<CShootingPositionBo>();
			ICodeRepository<CShootingPosition> repo = new CShootingPositionRepository();
			var items = repo.GetUsedOnlyList();

			foreach (var item in items)
			{
				var cd = new CShootingPositionBo();
				cd.DbId = item.CShootingPositionId;
				cd.Name = item.Name;
				cd.Description = item.Description;
				cd.Note = item.Note;
				cd.Priority = item.Priority;

				list.Add(cd);

			}
			list.OrderBy(x => x.Priority);

			return list;
		}

		public List<TargetBo> GetTargetUsedOnlyList()
		{
			var list = new List<TargetBo>();
			var repo = new TargetRepository();
			var items = repo.GetUsedOnlyList();
			foreach (var item in items)
			{
				var t = new TargetBo();
				t.DbId = item.TargetId;
				t.Name = item.Name;
				t.Description = item.Description;
				t.Note = item.Note;
				list.Add(t);
			}

			return list;
		}

	}
}
