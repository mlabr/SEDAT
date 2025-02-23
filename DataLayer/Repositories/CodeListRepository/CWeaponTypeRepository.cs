using DataLayer.Entities.CodeList;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.CodeListRepository
{
	public class CWeaponTypeRepository
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

		public CWeaponType Get(int id)
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


		public List<CWeaponType> GetAllParrents(int id)
		{
			var list = new List<CWeaponType>();

			var isTopParrent = false;
			while(!isTopParrent)
			{
				var item = Get(id);
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

	}
}
