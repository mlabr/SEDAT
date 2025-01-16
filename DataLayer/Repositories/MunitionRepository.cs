using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using SQLite;
using System;
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
						   join caliber in conn.Table<CCaliber>() on munition.CCaliberId equals caliber.CCaliberId
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
					result.CCaliber = item.Select(c => c.CCaliber).FirstOrDefault();
				}

				return result;
			}
		}





	}
}
