using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
	public class PlaceRepository
	{
		DbHelper helper;
		private string connectionString;
		public PlaceRepository()
        {
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

        public PlaceRepository(string connectionString)
        {
			this.connectionString = connectionString;
        }

		public void Delete(int id)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				//conn.Delete(id);

				conn.Delete<Place>(id);
			}
		}

		public Place Get(int id)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var item = from place in conn.Table<Place>()
						   where place.PlaceId == id
						   select place;

				var result = item.ToList().FirstOrDefault();
				return result;
			}
		}


		public List<Place> GetAllList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from place in conn.Table<Place>()
						   select place;

				return list.ToList();
			}
		}

		public List<Place> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from place in conn.Table<Place>()
						   where place.IsUsed == true
						   select place;

				return list.ToList();
			}
		}

		public void Insert(Place place)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(place);
			}
		}

		public void Update(Place item)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Update(item);
			}
		}
    }
}
