using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.CodeListRepository
{
	public class SeriesRepository : ICodeRepository<Series>
	{

		DbHelper helper;
		private string connectionString;

		public SeriesRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public SeriesRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<Series> GetAllList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from eventTable in conn.Table<Series>() 
						   select eventTable;

				return list.ToList();
			}
		}

		public Series GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Series> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from eventTable in conn.Table<Series>()
						   where eventTable.IsUsed == true
						   select eventTable;

				return list.ToList();

			}
		}

		public void Insert(Series item)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(item);
			}
		}

		public void InsertList(List<Series> item)
		{
			throw new NotImplementedException();
		}

		public void Update(Series item)
		{
			throw new NotImplementedException();
		}
	}
}
