using DataLayer.Entities.CodeList;
using DataLayer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public void Get()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var item = from weapon in conn.Table<Weapon>()
						   join person in conn.Table<Person>() on weapon.PersonId equals person.PersonId
						   where weapon.WeaponId == 1
						   select weapon;

				var stop = 0;
			}
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


		public void Create(WeaponProfile wp)
		{
			Create(wp.Weapon);
			Create(wp.CCaliberList.FirstOrDefault());
		}


		public void Create(Weapon weapon)
		{
			weapon.WeaponId = null;
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(weapon);
			}

			//profile

			//ccaliber

			//profile ccaliber

			//other stuff
		}

		public void Create(CCaliber cc)
		{
			cc.CCaliberId = null;
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(cc);
			}


		}

	}
}
