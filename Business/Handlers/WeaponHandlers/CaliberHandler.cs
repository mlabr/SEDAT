using Business.BusinessObjects.CodeList;
using Business.Mapping;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using DataLayer.Repositories.CodeListRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.WeaponHandlers
{
	public class CaliberHandler
	{

		public CaliberBo GetCaliberById(int id)
		{
			var repo = new CaliberRepository();
			var bo = Mapper.Weapon.CaliberToCaliberBo(repo.GetByID(id));
			return bo;
		}

		public void Insert(CaliberBo bo)
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

		public List<CaliberBo> GetAllList()
		{
			ICodeRepository<Caliber> repo = new CaliberRepository();

			var caliberList = repo.GetAllList();

			var boList = new List<CaliberBo>();

			foreach (var cal in caliberList)
			{

				//var bo = _mapService.CSightToCSightsBo(csight);
				var bo = new CaliberBo();
				bo.Name = cal.Name;
				bo.Description = cal.Description;
				bo.Note = cal.Note;
				bo.IsUsed = cal.IsUsed;
				bo.DbId = cal.CaliberId.Value;
				boList.Add(bo);
			}

			return boList;
		}

		public List<CaliberBo> GetUsedOnlyList()
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

		public List<CaliberBo> GetMunitionCaliberList()
		{
			ICodeRepository<Caliber> repo = new CaliberRepository();
			var list = repo.GetReferencedList();
			var listBo = new List<CaliberBo>();
			foreach (var item in list)
			{
				var bo = Mapper.Weapon.CaliberToCaliberBo(item);
				listBo.Add(bo);
			}

			return listBo;
		}




		public void Update(CaliberBo bo)
		{
			ICodeRepository<Caliber> repo = new CaliberRepository();
			repo.Update(Mapper.Weapon.CaliberBoToCCaliber(bo));
		}


	}
}
