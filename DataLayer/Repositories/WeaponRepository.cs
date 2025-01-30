using DataLayer.Entities.CodeList;
using DataLayer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataLayer.Repositories
{
	public class WeaponRepository
	{
		DbHelper helper;
		private string connectionString; 
		public WeaponRepository()
		{
			helper = new DbHelper();
			connectionString = helper.ConnectionString;
		}

		public WeaponRepository(string connectionString)
		{
			this.connectionString = connectionString; 
		}
		//CRUD


		public Weapon Get(int id)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var item = from weapon in conn.Table<Weapon>()
						   join person in conn.Table<Person>() on weapon.PersonId equals person.PersonId
						   where weapon.WeaponId == id
						   select new
						   {
							   Weapon = weapon,
							   Person = person
						   };

				if (item is null)
				{
					return null;
				}

				var result = item.Select(m => m.Weapon).FirstOrDefault();

				if (result is not null)
				{
					if(result.Person is not null)
					{
						result.Person = item.Select(c => c.Person).FirstOrDefault();
					}
					
				}

				return result;
			}
		}

		public List<WeaponProfile> GetWeaponProfileList()
		{
			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from profile in conn.Table<WeaponProfile>()
						   where profile.IsUsed == true
						   select profile;

				list.ToList();
				return list.ToList();
			}

			//return new List<WeaponProfile>();
		}

		public List<CFiringMode> GetFiringModeListUsedOnly()
		{

			using (var conn = new SQLiteConnection(helper.ConnectionString))
			{
				var list = from cFiringMode in conn.Table<CFiringMode>()
						   where cFiringMode.IsUsed == true
						   select cFiringMode;

				return list.ToList();
			}
		}


		public void Insert(WeaponProfile wp)
		{
			
			var sights = wp.SightsList.FirstOrDefault();
			if (!sights.SightsId.HasValue)
			{
				Insert(sights);
			}
			var id = sights.SightsId;
			
			var ccaliber = wp.CCaliberList.FirstOrDefault();
			if (!ccaliber.CCaliberId.HasValue)
			{
				Insert(ccaliber);
			}

			var weapon = wp.Weapon;
			if (!weapon.WeaponId.HasValue)
			{
				Insert(wp.Weapon);
			}
			wp.WeaponId = wp.Weapon.WeaponId.Value;

			//ProfileItself
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(wp);
			}

			//ProfileSights

			//ProfileCaliber


			//other stuff
		}



		private void Insert(Sights sights)
		{

		}

		public void Insert(Weapon weapon)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(weapon);
			}		
		}

		public void Insert(CCaliber cc)
		{
			cc.CCaliberId = null;
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(cc);
			}
		}

		public void Insert(ProfileSights ps)
		{
			ps.ProfileSightsId = null;
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(ps);
			}
		}

	}
}
