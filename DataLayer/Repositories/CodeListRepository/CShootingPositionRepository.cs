using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using SQLite;

namespace DataLayer.Repositories.CodeListRepository
{
	public class CShootingPositionRepository : ICodeRepository<CShootingPosition>
	{
		DbHelper helper;

        public CShootingPositionRepository()
        {
            helper = new DbHelper();
        }

        public CShootingPosition GetByID(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var item = from position in conn.Table<CShootingPosition>()
						   where position.CShootingPositionId == id
						   select position;

				return item.FirstOrDefault();

			}
		}

		public List<CShootingPosition> GetAllList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from position in conn.Table<CShootingPosition>()
						   select position;

				return list.ToList();

			}
		}

		public List<CShootingPosition> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from position in conn.Table<CShootingPosition>()
						   where position.IsUsed == true
						   select position;

				return list.ToList();

			}
		}

		public void Insert(CShootingPosition item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CShootingPosition> item)
		{
			throw new NotImplementedException();
		}

		public void Update(CShootingPosition item)
		{
			throw new NotImplementedException();
		}

		public int GetTotalItemsCount()
		{
			throw new NotImplementedException();
		}

		public List<CShootingPosition> GetReferencedList()
		{
			throw new NotImplementedException();
		}
	}
}
