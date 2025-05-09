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
	public class CWeaponTypeRepository : ICodeRepository<CWeaponType>
	{

		DbHelper helper;
		private string connectionString;
		public CWeaponTypeRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public List<CWeaponType> GetUsedOnlyList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from principle in conn.Table<CWeaponType>()
						   where principle.IsUsed == true
						   select principle;

				return list.ToList();
			}
		}

		public List<CWeaponType> GetAllParrents(int id)
		{
			var list = new List<CWeaponType>();

			var isTopParrent = false;
			while(!isTopParrent)
			{
				var item = GetByID(id);
				list.Add(item);
				if (item.CWeaponTypeParrentId == item.CWeaponTypeId)
				{
					isTopParrent = true;
					break;
				}
				id = item.CWeaponTypeParrentId;
			}
			return list;
		}

		public CWeaponType GetByID(int id)
		{
			CWeaponType type;

			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{

				var item = from cWeaponType in conn.Table<CWeaponType>()
						   where cWeaponType.CWeaponTypeId == id
						   select new CWeaponType()
						   {
							   CWeaponTypeId = cWeaponType.CWeaponTypeId,
							   CWeaponTypeParrentId = cWeaponType.CWeaponTypeParrentId,
							   Name = cWeaponType.Name,
							   Description = cWeaponType.Description,
							   Note = cWeaponType.Note
						   };

				type = item.FirstOrDefault();
			}


			return type;
		}

		public List<CWeaponType> GetAllList()
		{
			throw new NotImplementedException();
		}

		public void Insert(CWeaponType item)
		{
			throw new NotImplementedException();
		}

		public void Update(CWeaponType item)
		{
			throw new NotImplementedException();
		}

		public void InsertList(List<CWeaponType> item)
		{
			throw new NotImplementedException();
		}

		public int GetTotalItemsCount()
		{
			throw new NotImplementedException();
		}
	}
}
