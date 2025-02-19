using DataLayer.Entities.CodeList;
using DataLayer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static SQLite.SQLite3;

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

		public WeaponProfile GetWeaponProfile(int id)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				var item = from weaponProfile in conn.Table<WeaponProfile>()
							join weapon in conn.Table<Weapon>() on weaponProfile.WeaponId equals weapon.WeaponId
							join wtype in conn.Table<CWeaponType>() on weaponProfile.CWeaponTypeId equals wtype.CWeaponTypeId
							join pPrinciple in conn.Table<CPowerPrinciple>() on weaponProfile.CPowerPrincipleId equals pPrinciple.CPowerPrincipleId
							join cFMode in conn.Table<CFiringMode>() on weaponProfile.CFiringModeId equals cFMode.CFiringModeId
							//add caliber
							//add sights
							where weaponProfile.WeaponProfileId == id
							select new WeaponProfile()
							{
								WeaponProfileId = weaponProfile.WeaponProfileId,
								Name = weaponProfile.Name,
								Description = weaponProfile.Description,
								Note = weaponProfile.Note,
								Weapon = weapon,
								CWeaponType = wtype,
								CPowerPrinciple = pPrinciple,
								CFiringMode = cFMode

							};


				if (item is null)
				{
					return null;
				}

				var caliberList = from profileCCaliber in conn.Table<ProfileCCaliber>()
								  join caliber in conn.Table<CCaliber>() on profileCCaliber.CCaliberId equals caliber.CCaliberId
								  where profileCCaliber.WeaponProfileId == id
								  select new CCaliber()
								  {
									  CCaliberId = caliber.CCaliberId,
									  Name = caliber.Name,
									  Description = caliber.Description,
									  ValueMetric = caliber.ValueMetric,
									  Note = caliber.Note,
									  Priority = caliber.Priority
								  };


				caliberList.ToList();

				var sightsList = from profileSights in conn.Table<ProfileSights>()
								  join sights in conn.Table<Sights>() on profileSights.SightsId equals sights.SightsId
								  join csightsType in conn.Table<CSightsType>() on sights.CSightsTypeId equals csightsType.CSightsTypeId
								  where profileSights.WeaponProfileId == id
								  select new Sights()
								  {
									  SightsId = sights.SightsId,
									  Name = sights.Name,
									  Description = sights.Description,
									  Note = sights.Note,
									  IsUsed = sights.IsUsed,
									  CSightsType = csightsType,
								  };
				sightsList.ToList();

				var result = item.FirstOrDefault();
				result.CCaliberList = new List<CCaliber>();
				result.CCaliberList.AddRange(caliberList);
				result.SightsList = new List<Sights>();
				result.SightsList.AddRange(sightsList);

				return result;
			}
		}

		public List<WeaponProfile> GetWeaponProfileAll()
		{
			using (var conn = new SQLiteConnection(connectionString))
			{



				var items = from weaponProfile in conn.Table<WeaponProfile>()
							join weapon in conn.Table<Weapon>() on weaponProfile.WeaponId equals weapon.WeaponId
							join wtype in conn.Table<CWeaponType>() on weaponProfile.CWeaponTypeId equals wtype.CWeaponTypeId
							join pPrinciple in conn.Table<CPowerPrinciple>() on weaponProfile.CPowerPrincipleId equals pPrinciple.CPowerPrincipleId
							join cFMode in conn.Table<CFiringMode>() on weaponProfile.CFiringModeId equals cFMode.CFiringModeId
							select new WeaponProfile()
							{
								WeaponProfileId = weaponProfile.WeaponProfileId,
								Name = weaponProfile.Name,
								Note = weaponProfile.Note,
								Weapon = weapon,
								CWeaponType = wtype,
								CPowerPrinciple = pPrinciple,
								CFiringMode = cFMode

							};


				if (items is null)
				{
					return null;
				}

				items.ToList();


				var list = new List<WeaponProfile>();
				foreach (var item in items)
				{
					list.Add(item);
				}

				//var result = item.Select(m => m.Weapon).FirstOrDefault();

				//if (result is not null)
				//{
				//	if (result.Person is not null)
				//	{
				//		result.Person = item.Select(c => c.Person).FirstOrDefault();
				//	}

				//}

				return list;
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


		public void Insert(WeaponProfile wp)
		{
			
			var sights = wp.SightsList.FirstOrDefault();
			if (!sights.SightsId.HasValue)
			{
				Insert(sights);
			}
			var ps = new ProfileSights();
			ps.SightsId = sights.SightsId.Value;
			
			var ccaliber = wp.CCaliberList.FirstOrDefault();
			if (!ccaliber.CCaliberId.HasValue)
			{
				Insert(ccaliber);
			}
			var pc = new ProfileCCaliber();
			pc.CCaliberId = ccaliber.CCaliberId.Value;

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
			ps.WeaponProfileId = wp.WeaponProfileId.Value;
			pc.WeaponProfileId = wp.WeaponProfileId.Value;
			
			//ProfileSights
			Insert(ps);
			//ProfileCaliber
			Insert(pc);

		}



		private void Insert(Sights sights)
		{
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(sights);
			}
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

		private void Insert(ProfileCCaliber pc)
		{
			pc.ProfileCCaliberId= null;
			using (var conn = new SQLiteConnection(connectionString))
			{
				conn.Insert(pc);
			}
		}

	}
}
