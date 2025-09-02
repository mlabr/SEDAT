using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using Business.Filters;
using Business.Mapping;
using DataLayer.Criteria;
using DataLayer.Repositories;
using DataLayer.Repositories.CodeListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.WeaponHandlers
{
	public class MunitionHandler
	{
		private MunitionRepository repo;
		private CaliberRepository crepo; 

		public MunitionHandler()
		{
			repo = new MunitionRepository();
			crepo = new CaliberRepository();
		}

		public List<MunitionBo> GetUsedOnlyList()
		{
			var list = new List<MunitionBo>();

			//var result = repo.GetUsedOnlyList();
			var crit = new MunitionCriteria();
			crit.IsUsedOnlySelected = true;
			var result = repo.GetMunitionListByCriteria(crit);

			foreach (var item in result)
			{
				var bo = Mapper.Weapon.MunitionToMunitionBo(item);
				bo.CaliberBo = Mapper.Weapon.CaliberToCaliberBo(crepo.GetByID(item.CaliberId));
				list.Add(bo);
			}


			return list;
		}

		public List<MunitionBo> GetAllList()
		{
			var list = new List<MunitionBo>();

			var result = repo.GetAllList();
			foreach (var item in result)
			{
				var bo = Mapper.Weapon.MunitionToMunitionBo(item);
				bo.CaliberBo = Mapper.Weapon.CaliberToCaliberBo(crepo.GetByID(item.CaliberId));
				list.Add(bo);
			}

			return list;
		}

		public List<MunitionBo> GetListByFilter(MunitionFilter filter)
		{
			var criteria = new MunitionCriteria();
			criteria.CaliberId = filter.CaliberId;

			var list = new List<MunitionBo>();
			var result = repo.GetMunitionListByCriteria(criteria);
			foreach (var item in result)
			{
				var bo = Mapper.Weapon.MunitionToMunitionBo(item);
				bo.CaliberBo = Mapper.Weapon.CaliberToCaliberBo(crepo.GetByID(item.CaliberId));
				list.Add(bo);
			}

			return list;
		}

		public List<MunitionBo> GetUsedOnlyListByCaliberList(List<CaliberBo> caliberList)
		{
			var list = new List<MunitionBo>();
			var idList = new List<int>();
			foreach (var item in caliberList)
			{
				idList.Add(item.DbId);
			}


			var result = repo.GetUsedOnlyListByCaliberList(idList);


			if (result.Count < 1)
			{
				result = repo.GetDefaultAmunition();
			}

			foreach (var item in result)
			{
				var m = new MunitionBo();
				m.Name = item.Name;
				m.CaliberId = item.CaliberId;
				m.DbId = item.MunitionId.Value;
				m.Description = "(" + caliberList.Where(c => c.DbId == item.CaliberId).Select(d => d.Name).FirstOrDefault().ToString() + ") ";
				m.Description += item.Description;
				m.Note = item.Note;
				list.Add(m);
			}


			return list;
		}

		public void Insert(MunitionBo bo)
		{
			var item = Mapper.Weapon.MunitionBoToMunition(bo);
			item.MunitionId = null;
			repo.Insert(item);
			
		}


	}
}
