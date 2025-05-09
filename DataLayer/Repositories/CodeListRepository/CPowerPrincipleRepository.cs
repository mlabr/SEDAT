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
	public class CPowerPrincipleRepository : ICodeRepository<CPowerPrinciple>
	{
		DbHelper helper;
		private string connectionString;

		public CPowerPrincipleRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public CPowerPrinciple GetByID(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var item = from principle in conn.Table<CPowerPrinciple>()
						   where principle.CPowerPrincipleId == id
						   select principle;

				return item.FirstOrDefault();
			}

		}

		public List<CPowerPrinciple> GetAllList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from principle in conn.Table<CPowerPrinciple>()
						   select principle;

				return list.ToList();
			}
		}

		public List<CPowerPrinciple> GetAllParrents(int id)
		{
			var list = new List<CPowerPrinciple>();

			var isTopParrent = false;
			while (!isTopParrent)
			{
				var item = GetByID(id);
				list.Add(item);
				if (item.CPowerPrincipleParrentId == item.CPowerPrincipleId)
				{
					isTopParrent = true;
					break;
				}
				id = item.CPowerPrincipleParrentId;
			}
			return list;
		}

		public List<CPowerPrinciple> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from principle in conn.Table<CPowerPrinciple>()
						   where principle.IsUsed == true
						   select principle;

				return list.ToList();
			}
		}

		public void Insert(CPowerPrinciple item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CPowerPrinciple> item)
		{
			throw new NotImplementedException();
		}

		public void Update(CPowerPrinciple item)
		{
			throw new NotImplementedException();
		}

		public int GetTotalItemsCount()
		{
			throw new NotImplementedException();
		}
	}
}
