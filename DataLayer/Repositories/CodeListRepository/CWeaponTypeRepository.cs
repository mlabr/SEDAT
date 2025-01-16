using DataLayer.Entities.CodeList;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.CodeListRepository
{
	public class CWeaponTypeRepository
	{

		DbHelper helper;
		private string connectionString;
		public CWeaponTypeRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public List<CWeaponType> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from principle in conn.Table<CWeaponType>()
						   where principle.IsUsed == true
						   select principle;

				return list.ToList();
			}
		}
	}
}
