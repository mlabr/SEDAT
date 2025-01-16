using DataLayer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public void InsertSession(Session session)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{

				conn.Insert(session);

				//var list = from place in conn.Table<Place>()
				//		   where place.IsUsed == true
				//		   select place;

				//return list.ToList();

			}
		}
    }
}
