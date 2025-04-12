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
			//Session
			var repo = new SessionRepository();
			var session = new Session();
			//mapping  
			session.Name = bo.Name;
			session.PlaceId = bo.PlaceId;
			session.Description = bo.Description;
			session.DateStart = bo.DateStart.ToString(format: ("yyyy-MM-dd"));
			session.DateEnd = bo.DateEnd.ToString(format: ("yyyy-MM-dd"));
			session.Note = bo.Note;
			session.IsUsed = bo.IsUsed;
			session.DisciplineList = new List<Discipline>();

			foreach (var item in bo.SeriesBoList)
			{
				var ser = new Series();
				ser.Name = item.Name;
				ser.IsUsed = item.IsUsed;
				session.SeriesList.Add(ser);
				//Item is new
				if (item.DbId > 0)
				{
					ser.SeriesId = item.DbId;
				}
			}

			foreach (var item in bo.DisciplineBoList)
			{
				var dis = new Discipline();
				dis.DisciplineId = item.DbId;
				dis.Name = item.Name;
				dis.CDisciplineTypeId = item.CDisciplineTypeId;
				dis.CShootingPositionId = item.CShootingPositionId;
				dis.Description = item.Description;
				dis.TargetId = item.TargetId;
				dis.Range = item.Range;
				dis.IsRangeInMeters = item.IsRangeInMeters;
				dis.ScoreMax = item.ScoreMax;
				dis.Shotsmax = item.ShotsMax;
				dis.Date = item.Date.ToString(format: ("yyyy-MM-dd"));
				dis.IsUsed = true;
				dis.Note = item.Note;
				//dis.TimeStart
				//dis.TimeEnd


				session.DisciplineList.Add(dis);
			}


			repo.InsertFullSession(session);

			//Series
			var serRepo = new SeriesRepository();

			//serRepo.Insert()


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

		public void GetSessionOverviewList()
		{

			var repo = new SessionRepository();
			var lsit = repo.GetSessionListByParams();
		}
	}
}
