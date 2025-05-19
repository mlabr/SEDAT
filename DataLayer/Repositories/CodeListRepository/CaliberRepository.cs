using DataLayer.Criteria;
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
	public class CaliberRepository
	{
		DbHelper helper;
		public CaliberRepository()
		{
			helper = new DbHelper();
		}

		public Caliber GetByID(int id)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var item = from caliber in conn.Table<Caliber>()
						   where caliber.CaliberId == id
						   select caliber;

				return item.FirstOrDefault();

			}
		}

		public List<Caliber> GetAllList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from caliber in conn.Table<Caliber>()
						   select caliber;

				return list.ToList();

			}
		}

		public List<Caliber> GetListByCriteria(CriteriaBase criteria)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{

				var munitionList = from caliber in conn.Table<Caliber>()
								   where !criteria.IsDbIdSelected || caliber.CaliberId == criteria.DbId
								   where !criteria.IsUsedOnlySelected || caliber.IsUsed == true
								   select caliber;

				return munitionList.ToList();
			}
		}

		public List<Caliber> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from caliber in conn.Table<Caliber>()
						   where caliber.IsUsed == true
						   select caliber;

				return list.ToList();

			}
		}

		public List<Caliber> GetReferencedList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var mlist = from munition in conn.Table<Munition>()
						   select munition;

				var calIdList = (from item in mlist
								   select item.CaliberId).Distinct().ToList();

				var list = new List<Caliber>();
				foreach (var id in calIdList)
				{
					var item = from caliber in conn.Table<Caliber>()
							   where caliber.CaliberId == id
							   select caliber;

					list.Add(item.FirstOrDefault());
				}

				return list;

			}
		}

		public void Insert(Caliber item)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				conn.Insert(item);

			}
		}

		public void InsertList(List<Caliber> item)
		{
			throw new NotImplementedException();
		}

		public void Update(Caliber item)
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				conn.Update(item);
			}
		}

		public int GetTotalItemsCount()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from caliber in conn.Table<Caliber>()
						   select caliber;

				return list.Count();

			}
		}


	}
}
