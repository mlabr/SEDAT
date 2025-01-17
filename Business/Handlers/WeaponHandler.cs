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


		public void SaveWeaponToDataBase(WeaponBo bo)
		{
			//TODO
			var weapon = new Weapon();
			weapon.PersonId = 1; //TODO, for test purposes
			weapon.Name = bo.WeaponName;
			weapon.Identification = bo.Identification;
			weapon.Note = bo.Note;
			weapon.IsUsed = true;

			repo.Create(weapon);

			//must addd new profileSights, weapon can have more than one sights at time 

			
		}


		public List<CFiringModeBo> GetCFiringModeBoList()
		{
			var list = repo.GetFiringModeListUsedOnly();
			var listBo = new List<CFiringModeBo>();
			foreach (var firingModeBo in list)
			{
				var fm = new CFiringModeBo();
				fm.DbId = firingModeBo.CFiringModeId;
				fm.Name = firingModeBo.Name;
				fm.Description = firingModeBo.Description;
				fm.Note = firingModeBo.Note;
				fm.IsUsed = firingModeBo.IsUsed;
				listBo.Add(fm);
			}
			return listBo;
		}

		public List<CCaliberBo> GetCCaliberBoList()
		{
			var repo = new CCightsRepository();
			var list = repo.GetUsedOnlyList();
			var listBo = new List<CCaliberBo>();
			foreach (var firingModeBo in list)
			{
				var fm = new CCaliberBo();
				fm.DbId = firingModeBo.CCaliberId;
				fm.Name = firingModeBo.Name;
				fm.Description = firingModeBo.Description;
				fm.Note = firingModeBo.Note;
				fm.IsUsed = firingModeBo.IsUsed;
				listBo.Add(fm);
			}
			return listBo;
		}


		public List<CSightsTypeBo> GetCSightsTypeBoList()
		{
			var repo = new CSightsRepository();
			var list = repo.GetUsedOnlyList();
			var listBo = new List<CSightsTypeBo>();
			foreach (var sight in list)
			{
				
				var fm = new CSightsTypeBo();
				fm.DbId = sight.CSightsId;
				fm.Name = sight.Name;
				fm.Description = sight.Description;
				fm.Note = sight.Note;
				fm.IsUsed = sight.IsUsed;
				listBo.Add(fm);
			}
			return listBo;

		}


		public List<CPowerPrincipleBo> GetCPowerPrincipleBoList()
		{
			var repo = new CPowerPrincipleRepository();
			var list = repo.GetUsedOnlyList();
			var flatListBo = new List<CPowerPrincipleBo>();
			foreach (var firingModeBo in list)
			{
				var pp = new CPowerPrincipleBo();
				pp.DbId = firingModeBo.CPowerPrincipleId;
				pp.ParentDbId = firingModeBo.CPowerPrincipleParrentId;
				pp.Name = firingModeBo.Name;
				pp.Description = firingModeBo.Description;
				pp.Note = firingModeBo.Note;
				pp.IsUsed = firingModeBo.IsUsed;
				flatListBo.Add(pp);
			}


			return flatListBo;

		}

		public CPowerPrincipleBo GetCPowerPrincipleById(int id)
		{
			var repo = new CPowerPrincipleRepository();
			var bo = Mapper.CPowerPrincipleToCPowerPrincipleBo(repo.Get(id));

			return bo;
		}


		public List<CWeaponTypeBo> GetCWeaponTypeBoList()
		{
			var repo = new CWeaponTypeRepository();
			var list = repo.GetUsedOnlyList();
			var flatListBo = new List<CWeaponTypeBo>();
			foreach (var firingModeBo in list)
			{
				var pp = new CWeaponTypeBo();
				pp.DbId = firingModeBo.CWeaponTypeId;
				pp.ParentDbId = firingModeBo.CWeaponTypeParrentId;
				pp.Name = firingModeBo.Name;
				pp.Description = firingModeBo.Description;
				pp.Note = firingModeBo.Note;
				pp.IsUsed = firingModeBo.IsUsed;
				flatListBo.Add(pp);
			}


			return flatListBo;
		}


		public List<CFiringModeBo> GetCFiringModeBoUsedOnlyList()
		{
			var repo = new CFiringModeRepository();
			var list = repo.GetUsedOnlyList();
			var boList = new List<CFiringModeBo>();

			foreach(var firingModeBo in list)
			{
				var fm = new CFiringModeBo();
				fm.Name = firingModeBo.Name;
				fm.Description = firingModeBo.Description;
				fm.DbId = firingModeBo.CFiringModeId;
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
				var p = new PersonBo();
				p.Id = bo.PersonId;
				p.NickName = bo.Nickname;
				p.FirstName = bo.Firstame;
				p.LastName = bo.Surname;
				p.Note = bo.Note;
				p.IsUsed = bo.IsUsed;
				boList.Add(p);
			}

			return boList;

		}


	}
}
