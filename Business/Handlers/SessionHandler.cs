using Business.BusinessObjects;
using DataLayer.Entities;
using DataLayer.Repositories;

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

	}
}
