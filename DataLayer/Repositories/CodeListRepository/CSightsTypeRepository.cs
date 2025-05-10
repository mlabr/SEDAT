using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using SQLite;

namespace DataLayer.Repositories.CodeListRepository
{
	public class CSightsTypeRepository : ICodeRepository<CSightsType>
	{
		DbHelper helper;
		private string connectionString;

		public CSightsTypeRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public CSightsType GetByID(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var item = from type in conn.Table<CSightsType>()
						   where type.CSightsTypeId == id
						   select type;

				var result = item.ToList().FirstOrDefault();
				return result;
			}
		}
				


		public List<CSightsType> GetAllList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from csights in conn.Table<CSightsType>()
						   select csights;

				return list.ToList();
			}
		}

		public List<CSightsType> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from principle in conn.Table<CSightsType>()
						   where principle.IsUsed == true
						   select principle;

				return list.ToList();
			}
		}

		public void Insert(CSightsType item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CSightsType> item)
		{
			throw new NotImplementedException();
		}

		public void Update(CSightsType item)
		{
			throw new NotImplementedException();
		}

		public int GetTotalItemsCount()
		{
			throw new NotImplementedException();
		}
	}
}
