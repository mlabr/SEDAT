using DataLayer.Entities;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
	public class TargetRepository
	{
		DbHelper helper;
		private string connectionString;
		public TargetRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public List<Target> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from place in conn.Table<Target>()
						   where place.IsUsed == true
						   select place;

				return list.ToList();

			}

		}
	}
}
