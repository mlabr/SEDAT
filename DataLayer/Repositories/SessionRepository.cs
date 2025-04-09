using DataLayer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DataLayer.Repositories
{
	public class SessionRepository
	{
		DbHelper helper;
		private string connectionString;

        public SessionRepository()
        {
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public SessionRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<Session> GetListBySeriesId(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from session in conn.Table<Session>()
						   join seriesSession in conn.Table<SeriesSession>() on session.SessionId equals seriesSession.SessionId
						   join series in conn.Table<Series>() on seriesSession.SeriesId equals series.SeriesId
						   where seriesSession.SeriesId == id
						   select session;

				return list.ToList();
			}
		}

		public void InsertSession(Session session)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				conn.Insert(session);
			}
		}
    }
}
