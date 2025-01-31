using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using Business.Mapping;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Repositories;
using DataLayer.Repositories.CodeListRepository;
using System;
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


		public void SaveNewWeaponToDataBase(WeaponBo bo)
		{
			var wp = new WeaponProfile();
			wp.CCaliberList = new List<CCaliber>();
			wp.SightsList = new List<Sights>();
			wp.Name = bo.WeaponName + " " + bo.ProfileName;
			wp.CWeaponTypeId = bo.CWeaponTypeCode;
			wp.CPowerPrincipleId = bo.CPowerPrincipleCode;
			wp.CFiringModeId = bo.CFiringModeCode;

			
			var weapon = new Weapon();
			weapon.PersonId = 1; //TODO, for test purposes
			weapon.Name = bo.WeaponName;
			weapon.Identification = bo.Identification;
			weapon.Note = bo.Note;
			weapon.IsUsed = true;
			wp.Weapon = weapon;
			
			var calBo = bo.CCaliberBoList.FirstOrDefault();

			var cal = Mapper.Weapon.CCaliberBoToCCaliber(calBo);
			wp.CCaliberList.Add(cal);

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

		public List<CCaliberBo> GetCCaliberBoList()
		{
			var repo = new CCightsRepository();
			var list = repo.GetUsedOnlyList();
			var listBo = new List<CCaliberBo>();
			foreach (var item in list)
			{
				var bo = Mapper.Weapon.CCaliberToCCaliberBo(item);
				listBo.Add(bo);
			}

			return listBo;
		}


		public List<CSightsTypeBo> GetCSightsTypeBoList()
		{
			var repo = new CSightsTypeRepository();
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
			var bo = Mapper.Weapon.CPowerPrincipleToCPowerPrincipleBo(repo.Get(id));

			return bo;
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


		public List<CFiringModeBo> GetCFiringModeBoUsedOnlyList()
		{
			var repo = new CFiringModeRepository();
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

	}
}
