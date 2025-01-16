using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using SQLite;

namespace DataLayer.Repositories.CodeListRepository
{
	public class CSightsRepository : ICodeRepository<CSights>
	{
		DbHelper helper;
		private string connectionString;

		public CSightsRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public CSights Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<CSights> GetAllList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from csights in conn.Table<CSights>()
						   select csights;

				return list.ToList();
			}
		}

		public List<CSights> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from principle in conn.Table<CSights>()
						   where principle.IsUsed == true
						   select principle;

				return list.ToList();
			}
		}

		public void Insert(CSights item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CSights> item)
		{
			throw new NotImplementedException();
		}

		public void Update(CSights item)
		{
			throw new NotImplementedException();
		}
	}
}
