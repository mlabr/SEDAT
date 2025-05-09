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
	public class CaliberRepository : ICodeRepository<Caliber>
	{
		DbHelper helper;
		public CaliberRepository()
		{
			helper = new DbHelper();
		}

		public Caliber GetByID(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var item = from caliber in conn.Table<Caliber>()
						   where caliber.CaliberId == id
						   select caliber;

				return item.FirstOrDefault();

			}
		}

		public List<Caliber> GetAllList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from caliber in conn.Table<Caliber>()
						   select caliber;

				return list.ToList();

			}
		}



		public List<Caliber> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from caliber in conn.Table<Caliber>()
						   where caliber.IsUsed == true
						   select caliber;

				return list.ToList();

			}
		}

		public void Insert(Caliber item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<Caliber> item)
		{
			throw new NotImplementedException();
		}

		public void Update(Caliber item)
		{
			throw new NotImplementedException();
		}
	}
}
