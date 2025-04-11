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

		public Series GetSeriesById(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from series in conn.Table<Series>()
						   where series.SeriesId == id
						   select series;

				return list.ToList().FirstOrDefault();
			}
		}

		public void InsertFullSession(Session session)
		{
			Insert(session);
			foreach (var series in session.SeriesList)
			{
				//series exits?
				if(series.SeriesId < 1)
				{
					insert(series);
				}
				var serses = new SeriesSession();
				serses.SeriesId = series.SeriesId;
				serses.SessionId = session.SessionId.Value;
				insert(serses);

			}
		}


		public void Insert(Session session)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				conn.Insert(session);
			}
		}

		private void insert(Series series)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				conn.Insert(series);
			}
		}

		private void insert(SeriesSession serses)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				conn.Insert(serses);
			}
		}
    }
}
