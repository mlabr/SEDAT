using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
	public class MunitionRepository
	{
		DbHelper helper;
		private string connectionString;
		public MunitionRepository()
        {
            helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

        public MunitionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //CRUD


        public Munition Get(int id)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var item = from munition in conn.Table<Munition>()
						   join caliber in conn.Table<Caliber>() on munition.CaliberId equals caliber.CaliberId
						   where munition.MunitionId == id
						   select new
						   {
							   Munition = munition,
							   CCaliber = caliber
						   };

				if(item is null)
				{
					return null;
				}

				var result = item.Select(m => m.Munition).FirstOrDefault();
				
				if(result is not null)
				{
					result.Caliber = item.Select(c => c.CCaliber).FirstOrDefault();
				}

				return result;
			}
		}

		public List<Munition> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var list = from munition in conn.Table<Munition>()
						   where munition.IsUsed == true
						   select munition;

				if (list is null)
				{
					return null;
				}

				return list.ToList();
			}

		}

		public List<Munition> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<Munition> GetUsedOnlyListByCaliberList(List<int> idList)
		{
			var munitionList = new List<Munition>();

			using (var conn = new SQLiteConnection(connectionString))
			{

				foreach (var id in idList)
				{
					var list = from munition in conn.Table<Munition>()
							   where munition.IsUsed == true &&
							   munition.CaliberId == id
							   select munition;

					if (list is not null)
					{
						list.ToList();
						munitionList.AddRange(list);
					}

					
				}


				return munitionList.ToList();
			}
		}

		public List<Munition> GetDefaultAmunition()
		{
			var munitionList = new List<Munition>();
			using (var conn = new SQLiteConnection(connectionString))
			{

				var defaultMunition = from munition in conn.Table<Munition>()
						   where munition.MunitionId == 1
						   select munition;
				defaultMunition.ToList().FirstOrDefault();
				munitionList.AddRange(defaultMunition);

				return munitionList.ToList();
			}
		}
	}
}
