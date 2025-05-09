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
	public class CFiringModeRepository : ICodeRepository<CFiringMode>
	{

		DbHelper helper;
		private string connectionString;

		public CFiringModeRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}


		public CFiringModeRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}


		public CFiringMode GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<CFiringMode> GetAllList()
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CFiringMode> item)
		{
			throw new NotImplementedException();
		}

		public List<CFiringMode> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from cfiringMode in conn.Table<CFiringMode>()
						   where cfiringMode.IsUsed == true
						   select cfiringMode;

				return list.ToList();

			}
		}

		public void Insert(CFiringMode item)
		{
			throw new NotImplementedException();
		}

		public void Update(CFiringMode item)
		{
			throw new NotImplementedException();
		}

		public int GetTotalItemsCount()
		{
			throw new NotImplementedException();
		}
	}
}
