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
	public class SightsRepository
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
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from sights in conn.Table<Sights>()
						   select sights;

				return list.ToList();
			}
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

		public List<Sights> GetListByWeaponProfileId(int weaponProfileId)
		{
			List<Sights> sightsList = new List<Sights>();
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from profileSights in conn.Table<ProfileSights>()
								 join sights in conn.Table<Sights>() on profileSights.SightsId equals sights.SightsId
								 join csightsType in conn.Table<CSightsType>() on sights.CSightsTypeId equals csightsType.CSightsTypeId
								 where profileSights.WeaponProfileId == weaponProfileId
								 select new Sights()
								 {
									 SightsId = sights.SightsId,
									 Name = sights.Name,
									 Description = sights.Description,
									 Note = sights.Note,
									 IsUsed = sights.IsUsed,
									 CSightsType = csightsType,
								 };
				list.ToList();

				sightsList.AddRange(list);
			}

			
			if(sightsList.Count < 1)
			{
				//select default sights
				using (var conn = new SQLiteConnection(helper.ConnectionString))
				{
					var list = from sights in conn.Table<Sights>()
							   where sights.SightsId == 1
							   select sights;

					return list.ToList();
				}
			}

			return sightsList;
		}

		public void Insert(Sights item)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(item);
			}
		}

		public void InsertList(List<Sights> item)
		{
			throw new NotImplementedException();
		}

		public void Update(Sights item)
		{
			throw new NotImplementedException();
		}

		public int GetTotalItemsCount()
		{
			throw new NotImplementedException();
		}

		public List<Sights> GetReferencedList()
		{
			throw new NotImplementedException();
		}
	}
}
