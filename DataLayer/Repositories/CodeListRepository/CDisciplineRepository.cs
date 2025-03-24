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
    public class CDisciplineRepository : ICodeRepository<CDiscipline>
    {
        DbHelper helper;

        public CDisciplineRepository()
        {
            helper = new DbHelper();
        }

		public CDiscipline Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<CDiscipline> GetAllList()
        {
            using (var conn = new SQLiteConnection(helper.ConnectionString))
            {
                var list = from cd in conn.Table<CDiscipline>()
                           select cd;

                return list.ToList();

            }
        }

        public List<CDiscipline> GetUsedOnlyList()
        {
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from cd in conn.Table<CDiscipline>()
						   where cd.IsUsed == true
						   select cd;

				return list.ToList();

			}
		}

		public void Insert(CDiscipline item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CDiscipline> item)
		{
			throw new NotImplementedException();
		}

		public void Update(CDiscipline item)
		{
			throw new NotImplementedException();
		}


	}
}
