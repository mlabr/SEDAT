using DataLayer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
	public class RecordRepository
	{
		DbHelper helper;
		private string connectionString;

		public RecordRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public RecordRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<Record> GetRecordListByWeaponProfile(int id)
		{
			var recordList = new List<Record>();
			
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from record in conn.Table<Record>()
						   where record.WeaponProfileId == id
						   select record;

				if(list is not null)
				{
					recordList = list.ToList();
				}
			}

			return recordList;
		}
	}
}
