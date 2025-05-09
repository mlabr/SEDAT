using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using Business.Mapping;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using DataLayer.Repositories.CodeListRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers
{
	public class WeaponHandler
	{
		private WeaponRepository repo;

		public WeaponHandler()
		{
			repo = new WeaponRepository();
		}


		public List<WeaponBo> GetWeaponProfileList()
		{
			var list = new List<WeaponBo>();
			var result = repo.GetWeaponProfileAll();
			foreach (var item in result)
			{
				var bo = new WeaponBo();
				bo.ProfileName = item.Name;
				bo.WeaponName = item.Weapon.Name;
				bo.ProfileDdId = item.WeaponProfileId.Value;
				bo.Identification = item.Weapon.Identification;
				list.Add(bo);
			}

			return list;
		}

		public WeaponBo GetWeaponProfile(int id)
		{
			var result = repo.GetWeaponProfile(id);
			var w = new WeaponBo();
			w.ProfileName = result.Name;
			w.WeaponId = result.WeaponId;
			w.WeaponName = result.Weapon.Name;
			w.ProfileDdId = result.WeaponProfileId.Value;
			w.Identification = result.Weapon.Identification;
			w.Description = result.Description;

			w.CCaliberBoList = new List<CaliberBo>();
			foreach (var cal in result.CaliberList)
			{
				if (cal == null) continue;
				var c = new CaliberBo();
				c.Name = cal.Name;
				c.DbId = cal.CaliberId.Value;
				c.Description = cal.Description;
				c.Note = cal.Note;
				w.CCaliberBoList.Add(c);
			}

			w.SightsBoList = new List<SightsBo>();
			foreach (var sig in result.SightsList)
			{
				if (sig == null) continue;
				var c = new SightsBo();
				c.Name = sig.Name;
				c.Description = sig.Description;
				c.Note = sig.Note;
				w.SightsBoList.Add(c);
			}

			w.WeaponType = new CWeaponTypeBo();
			w.WeaponType.Name = result.CWeaponType.Name;
			w.WeaponType.Description = result.CWeaponType.Description;
			w.WeaponType.Note = result.CWeaponType.Note;

			w.WeaponTypeList = GetCWeaponTypeBoAllParrentsList(result.CWeaponType.CWeaponTypeId);
			w.PowerPrincipleBoList = GetCPowerPrincipleBoAllParrentsList(result.CPowerPrinciple.CPowerPrincipleId);


			w.CFiringMode = new CFiringModeBo();
			w.CFiringMode.Name = result.CFiringMode.Name;
			w.CFiringMode.Description = result.CFiringMode.Description;
			w.CFiringMode.Note = result.CFiringMode.Note;
			w.CFiringMode.DbId = result.CFiringMode.CFiringModeId;


			//get some stats
			//TODO
			//Get shots count total
			//get shots count from last maintanence
			//maybe in another query?
			return w;
		}

		public WeaponBo GetWeaponBaseById(int id)
		{
			var result = repo.GetWeaponBaseById(id);
			var bo = new WeaponBo();
			bo.WeaponId = result.WeaponId.Value;
			bo.Identification = result.Identification;
			bo.WeaponName = result.Name;

			return bo;

		}



		public void SaveNewWeaponToDataBase(WeaponBo bo)
		{
			var wp = new WeaponProfile();
			wp.CaliberList = new List<Caliber>();
			wp.SightsList = new List<Sights>();
			wp.Name = bo.WeaponName + " " + bo.ProfileName;
			wp.Description = bo.Description;
			wp.CWeaponTypeId = bo.CWeaponTypeCode;
			wp.CPowerPrincipleId = bo.CPowerPrincipleCode;
			wp.CFiringModeId = bo.CFiringModeCode;
			wp.MaintenanceIntervalDate = bo.MaintenanceIntervalDate;
			wp.MaintenanceIntervalShots = bo.MaintenanceIntervalShots;
			wp.MaintenanceLastDate = bo.MaintenanceLastDate.ToString(format:("yyyy-MM-dd"));

			var weapon = new Weapon();
			weapon.PersonId = 1; //TODO, for test purposes
			weapon.Name = bo.WeaponName;
			weapon.Identification = bo.Identification;
			weapon.Note = bo.Note;
			weapon.IsUsed = true;
			//weapon is exists
			if (bo.WeaponId > 0)
			{
				weapon.WeaponId = bo.WeaponId;
			}
			wp.Weapon = weapon;


			var calBo = bo.CCaliberBoList.FirstOrDefault();

			var cal = Mapper.Weapon.CCaliberBoToCCaliber(calBo);
			wp.CaliberList.Add(cal);

			var sightsBo = bo.SightsBoList.FirstOrDefault();
			var sights = Mapper.Weapon.SightsBoToSights(sightsBo);
			wp.SightsList.Add(sights);





			repo.Insert(wp);
			
		}



		public List<CFiringModeBo> GetCFiringModeBoList()
		{
			var list = repo.GetFiringModeListUsedOnly();
			var listBo = new List<CFiringModeBo>();
			foreach (var firingModeBo in list)
			{
				var fm = Mapper.Weapon.CFiringModeToCFiringModeBo(firingModeBo);
				listBo.Add(fm);
			}

			return listBo;
		}

		public List<CaliberBo> GetCaliberBoList()
		{
			ICodeRepository<Caliber> repo = new CaliberRepository();
			var list = repo.GetUsedOnlyList();
			var listBo = new List<CaliberBo>();
			foreach (var item in list)
			{
				var bo = Mapper.Weapon.CaliberToCaliberBo(item);
				listBo.Add(bo);
			}

			return listBo;
		}

		public void SaveNewCaliber(CaliberBo bo)
		{
			ICodeRepository<Caliber> repo = new CaliberRepository();
			var cal = new Caliber();
			cal.Name = bo.Name;
			cal.Description = bo.Description;
			cal.Note = bo.Note;
			cal.IsUsed = bo.IsUsed;

			var priority = repo.GetTotalItemsCount();
			cal.Priority = priority;

			repo.Insert(cal);

		}


		public List<CSightsTypeBo> GetCSightsTypeBoList()
		{
			ICodeRepository<CSightsType> repo = new CSightsTypeRepository();
			var list = repo.GetUsedOnlyList();
			var listBo = new List<CSightsTypeBo>();
			foreach (var sights in list)
			{
				var bo = Mapper.Weapon.CSightsTypeToCSightsTypeBo(sights);
				listBo.Add(bo);
			}

			return listBo;
		}

		public List<SightsBo> GetSightsBoList()
		{
			var repo = new SightsRepository();
			var list = repo.GetUsedOnlyList();
			var listBo = new List<SightsBo>();
			foreach (var sights in list)
			{
				var bo = Mapper.Weapon.SightsToSightsBo(sights);
				listBo.Add(bo);
			}

			return listBo;

		}


		public List<CPowerPrincipleBo> GetCPowerPrincipleBoList()
		{
			var repo = new CPowerPrincipleRepository();
			var list = repo.GetUsedOnlyList();
			var flatListBo = new List<CPowerPrincipleBo>();
			foreach (var item in list)
			{
				var bo = Mapper.Weapon.CPowerPrincipleToCPowerPrincipleBo(item);
				flatListBo.Add(bo);
			}

			return flatListBo;
		}

		public CPowerPrincipleBo GetCPowerPrincipleById(int id)
		{
			var repo = new CPowerPrincipleRepository();
			var bo = Mapper.Weapon.CPowerPrincipleToCPowerPrincipleBo(repo.GetByID(id));

			return bo;
		}

		public List<CPowerPrincipleBo> GetCPowerPrincipleBoAllParrentsList(int id)
		{
			var repo = new CPowerPrincipleRepository();
			var list = repo.GetAllParrents(id);
			var flatListBo = new List<CPowerPrincipleBo>();
			foreach (var item in list)
			{
				var bo = Mapper.Weapon.CPowerPrincipleToCPowerPrincipleBo(item);
				flatListBo.Add(bo);
			}

			return flatListBo;
		}


		public List<CWeaponTypeBo> GetCWeaponTypeBoList()
		{
			var repo = new CWeaponTypeRepository();
			var list = repo.GetUsedOnlyList();
			var flatListBo = new List<CWeaponTypeBo>();
			foreach (var item in list)
			{
				var bo = Mapper.Weapon.CWeaponTypeToCWeaponTypeBo(item);
				flatListBo.Add(bo);
			}

			return flatListBo;
		}

		public List<CWeaponTypeBo> GetCWeaponTypeBoAllParrentsList(int id)
		{
			var repo = new CWeaponTypeRepository();
			var list = repo.GetAllParrents(id);
			var flatListBo = new List<CWeaponTypeBo>();
			foreach (var item in list)
			{
				var bo = Mapper.Weapon.CWeaponTypeToCWeaponTypeBo(item);
				flatListBo.Add(bo);
			}

			return flatListBo;
		}


		public List<CFiringModeBo> GetCFiringModeBoUsedOnlyList()
		{
			ICodeRepository<CFiringMode> repo = new CFiringModeRepository();
			var list = repo.GetUsedOnlyList();
			var boList = new List<CFiringModeBo>();

			foreach(var item in list)
			{
				var bo = Mapper.Weapon.CFiringModeToCFiringModeBo(item);
				boList.Add(bo);
			}

			return boList;
		}


		public List<PersonBo> GetPersonBoUsedOnlyList()
		{
			var repo = new PersonRepository();
			var list = repo.GetUsedOnlyList();
			var boList = new List<PersonBo>();

			foreach (var bo in list)
			{
				var p = Mapper.PersonToPersonBo(bo);
				boList.Add(p);
			}

			return boList;
		}




		//statistics
		public void GetWeaponStats(int weaponProfileId)
		{
			var repo = new RecordRepository();
			var list = repo.GetRecordListByWeaponProfile(weaponProfileId);

			int totalShots = 0;
			int totalTimeInMinutes = 0;
			int totalTimeInMinutesAprox = 0;

			foreach (var item in list)
			{
				totalShots += item.ShotsCount;

				totalTimeInMinutes += calculateTotalTime(item);

			}

		}


		private int calculateTotalTime(Record record)
		{
			int totalTime = 0;
			if(string.IsNullOrEmpty(record.TimeStart))
			{
				return 0;
			}

			if (string.IsNullOrEmpty(record.TimeEnd))
			{
				return 0;
			}
			totalTime = (int)(DateTime.Parse(record.TimeEnd) - DateTime.Parse(record.TimeStart)).TotalMinutes;

			if(totalTime < 0)
			{
				totalTime = 0;
			}


			return totalTime;	
		}


	}
}
