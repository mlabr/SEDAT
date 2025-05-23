﻿using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.CodeListRepository
{
	public class CDisciplineRepository : ICodeRepository<CDisciplineType>
    {
        DbHelper helper;

        public CDisciplineRepository()
        {
            helper = new DbHelper();
        }

		public CDisciplineType GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<CDisciplineType> GetAllList()
        {
            using (var conn = new SQLiteConnection(helper.ConnectionString))
            {
                var list = from cd in conn.Table<CDisciplineType>()
                           select cd;

                return list.ToList();

            }
        }

        public List<CDisciplineType> GetUsedOnlyList()
        {
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from cd in conn.Table<CDisciplineType>()
						   where cd.IsUsed == true
						   select cd;

				return list.ToList();

			}
		}

		public void Insert(CDisciplineType item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CDisciplineType> item)
		{
			throw new NotImplementedException();
		}

		public void Update(CDisciplineType item)
		{
			throw new NotImplementedException();
		}

		public int GetTotalItemsCount()
		{
			throw new NotImplementedException();
		}

		public List<CDisciplineType> GetReferencedList()
		{
			throw new NotImplementedException();
		}
	}
}
