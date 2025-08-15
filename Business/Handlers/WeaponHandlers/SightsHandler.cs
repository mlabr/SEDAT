using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using Business.Mapping;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using DataLayer.Repositories.CodeListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.WeaponHandlers
{
	public class SightsHandler
	{
		ICodeRepository<CSightsType> cstRepo;

		SightsRepository sRepo;

		public SightsHandler()
		{
			cstRepo = new CSightsTypeRepository();
			sRepo = new SightsRepository();
		}

		public List<CSightsTypeBo> GetCSightsTypeAllList()
		{
			var csightsList = cstRepo.GetAllList();

			var boList = new List<CSightsTypeBo>();

			foreach (var csight in csightsList)
			{
				var bo = Mapper.Weapon.SightsTypeToCSightsTypeBo(csight);
				boList.Add(bo);
			}

			return boList;
		}

		public List<CSightsTypeBo> GetCSightsTypeUsedOnlyList()
		{
			var csightsList = cstRepo.GetUsedOnlyList();

			var boList = new List<CSightsTypeBo>();

			foreach (var csight in csightsList)
			{
				var bo = Mapper.Weapon.SightsTypeToCSightsTypeBo(csight);
				boList.Add(bo);
			}

			return boList;
		}

		public List<SightsBo> GetSightsAllList()
		{
			var sightsList = sRepo.GetAllList();

			var boList = new List<SightsBo>();

			foreach (var sight in sightsList)
			{

				//var bo = _mapService.CSightToCSightsBo(csight);
				var bo = new SightsBo();
				bo.Name = sight.Name;
				bo.Description = sight.Description;
				bo.Note = sight.Note;
				bo.IsUsed = sight.IsUsed;
				bo.CSightsType = Mapper.Weapon.SightsTypeToCSightsTypeBo(cstRepo.GetByID(sight.CSightsTypeId));
				boList.Add(bo);
			}

			return boList;
		}

		public List<SightsBo> GetSightsUsedOnlyByWeaponProfileId(int weaponProfileid)
		{
			var sightsList = sRepo.GetListByWeaponProfileId(weaponProfileid);

			var boList = new List<SightsBo>();

			foreach(var sights in sightsList)
			{
				if(sights.IsUsed)
				{
					var bo = Mapper.Weapon.SightsToSightsBo(sights);
					boList.Add(bo);
				}
			}


			return boList;
		}


		public void Insert(SightsBo bo)
		{
			sRepo.Insert(Mapper.Weapon.SightsBoToSights(bo));
		}

		internal List<SightsBo> GetSightsusedOnlyList()
		{
			var sightsList = sRepo.GetUsedOnlyList();

			var boList = new List<SightsBo>();

			foreach (var csight in sightsList)
			{

				//var bo = _mapService.CSightToCSightsBo(csight);
				var bo = new SightsBo();
				bo.Name = csight.Name;
				bo.Description = csight.Description;
				bo.Note = csight.Note;
				bo.IsUsed = csight.IsUsed;
				bo.CSightsType = Mapper.Weapon.SightsTypeToCSightsTypeBo(cstRepo.GetByID(csight.CSightsTypeId));
				boList.Add(bo);
			}

			return boList;
		}


	}
}
