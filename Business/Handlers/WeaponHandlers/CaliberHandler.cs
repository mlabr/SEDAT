using Business.BusinessObjects.CodeList;
using Business.Mapping;
using DataLayer.Criteria;
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
			var repo = new CaliberRepository();
			var cal = Mapper.Weapon.CaliberBoToCCaliber(bo);
			var priority = repo.GetTotalItemsCount();
			cal.Priority = priority;

			repo.Insert(cal);
		}

		public List<CaliberBo> GetAllList()
		{
			var repo = new CaliberRepository();
			var caliberList = repo.GetAllList();
			var boList = new List<CaliberBo>();

			foreach (var cal in caliberList)
			{
				var bo = Mapper.Weapon.CaliberToCaliberBo(cal);
				boList.Add(bo);
			}

			return boList;
		}

		public List<CaliberBo> GetUsedOnlyList()
		{

			var repo = new CaliberRepository();
			var crit = new CriteriaBase();
			crit.IsUsedOnlySelected = true;
			var list = repo.GetListByCriteria(crit);
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
			var repo = new CaliberRepository();
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
			var repo = new CaliberRepository();
			repo.Update(Mapper.Weapon.CaliberBoToCCaliber(bo));
		}


	}
}
