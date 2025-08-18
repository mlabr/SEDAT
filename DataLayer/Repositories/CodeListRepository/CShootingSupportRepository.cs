using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using Metsys.Bson;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.CodeListRepository
{
	public class CShootingSupportRepository : ICodeRepository<CShootingSupport>
	{
		DbHelper helper;

		public CShootingSupportRepository()
		{
			helper = new DbHelper();
		}

		public List<CShootingSupport> GetAllList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from support in conn.Table<CShootingSupport>()
						   select support;

				return list.ToList();

			}
		}

		public CShootingSupport GetByID(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var item = from support in conn.Table<CShootingSupport>()
						   where support.CShootingSupportId == id
						   select support;

				return item.FirstOrDefault();

			}
		}

		public List<CShootingSupport> GetReferencedList()
		{
			throw new NotImplementedException();
		}

		public int GetTotalItemsCount()
		{
			throw new NotImplementedException();
		}

		public List<CShootingSupport> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from support in conn.Table<CShootingSupport>()
						   where support.IsUsed == true
						   select support;

				return list.ToList();

			}
		}

		public void Insert(CShootingSupport item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CShootingSupport> item)
		{
			throw new NotImplementedException();
		}

		public void Update(CShootingSupport item)
		{
			throw new NotImplementedException();
		}
	}
}
