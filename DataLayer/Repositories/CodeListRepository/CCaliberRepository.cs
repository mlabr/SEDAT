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
	public class CCightsRepository
	{
		DbHelper helper;
		public CCightsRepository()
		{
			helper = new DbHelper();
		}

		public CCaliber Get(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var item = from caliber in conn.Table<CCaliber>()
						   where caliber.CCaliberId == id
						   select caliber;

				return item.FirstOrDefault();

			}
		}

		public List<CCaliber> GetAllList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from caliber in conn.Table<CCaliber>()
						   select caliber;

				return list.ToList();

			}
		}

		public List<CCaliber> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from caliber in conn.Table<CCaliber>()
						   where caliber.IsUsed == true
						   select caliber;

				return list.ToList();

			}
		}

		public void InsertList(List<CCaliber> item)
		{
			throw new NotImplementedException();
		}
	}
}
