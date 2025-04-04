using DataLayer.Entities;
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
	public class SightsRepository : ICodeRepository<Sights>
	{
		DbHelper helper;
		private string connectionString;

		public SightsRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public Sights GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Sights> GetAllList()
		{
			throw new NotImplementedException();
		}

		public List<Sights> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from sights in conn.Table<Sights>()
						   where sights.IsUsed == true
						   select sights;

				return list.ToList();
			}
		}

		public void Insert(Sights item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<Sights> item)
		{
			throw new NotImplementedException();
		}

		public void Update(Sights item)
		{
			throw new NotImplementedException();
		}
	}
}
