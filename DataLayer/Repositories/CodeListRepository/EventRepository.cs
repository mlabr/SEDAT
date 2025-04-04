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
	public class EventRepository : ICodeRepository<Event>
	{

		DbHelper helper;
		private string connectionString;

		public EventRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public EventRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<Event> GetAllList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from eventTable in conn.Table<Event>() 
						   select eventTable;

				return list.ToList();
			}
		}

		public Event GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Event> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from eventTable in conn.Table<Event>()
						   where eventTable.IsUsed == true
						   select eventTable;

				return list.ToList();

			}
		}

		public void Insert(Event item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<Event> item)
		{
			throw new NotImplementedException();
		}

		public void Update(Event item)
		{
			throw new NotImplementedException();
		}
	}
}
