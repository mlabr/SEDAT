using Avalonia.Controls;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;
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

		public List<Session> GetSessionListByParams()
		{
			//conditions
			var skipCount = 0;
			var takeCount = 10000;
			var yearOfSession = "";
			if (string.IsNullOrEmpty(yearOfSession))
			{
				yearOfSession = null;
			}



			var sessionList = new List<Session>();
			//filter Sesion name, Series, Place
			using (var conn = new SQLiteConnection(connectionString))
			{
				var itemList = (from seriesSession in conn.Table<SeriesSession>()
							   join session in conn.Table<Session>() on seriesSession.SessionId equals session.SessionId
							   join series in conn.Table<Series>() on seriesSession.SeriesId equals series.SeriesId
							   where yearOfSession == null || session.DateStart.StartsWith(yearOfSession)
							   
							   //add another conditions here


							   //join discipline in conn.Table<Discipline>() on session.SessionId equals discipline.SessionId
							   select new
							   { 
								   SeriesSession = seriesSession,
								   Session = session,
								   Series = series,
							   }).Skip(skipCount)
							   .Take(takeCount);





				if (itemList is null)
				{
					//return list;
				}
				itemList.ToList();


				

				foreach (var item in itemList)
				{
					var ses = sessionList.Find(x => x.SessionId == item.Session.SessionId);
					if(ses is null)
					{
						sessionList.Add(item.Session);

					}
					item.Session.SeriesList.Add(item.Series);
				}
				//Now we have all session with its series

				


				//var list = new List<WeaponProfile>();
				//foreach (var item in sessionEntity)
				//{
				//	list.Add(item);
				//}

				//var result = item.Select(m => m.Weapon).FirstOrDefault();

				//if (result is not null)
				//{
				//	if (result.Person is not null)
				//	{
				//		result.Person = item.Select(c => c.Person).FirstOrDefault();
				//	}

				//}

				
			}


			return sessionList;
		}
	}
}
