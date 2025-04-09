using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers
{
	public class MunitionHandler
	{
		private MunitionRepository repo;

		public MunitionHandler()
		{
			repo = new MunitionRepository();
		}

		public List<MunitionBo> GetUsedOnlyList()
		{
			var list = new List<MunitionBo>();

			var result = repo.GetUsedOnlyList();
			foreach (var item in result)
			{
				var m = new MunitionBo();
				m.Name = item.Name;
				m.CaliberId = item.CaliberId;
				m.Description = item.Description;
				m.Note = item.Note;
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


			if(result.Count < 1)
			{
				result = repo.GetDefaultAmunition();
			}

			foreach (var item in result)
			{
				var m = new MunitionBo();
				m.Name = item.Name;
				m.CaliberId = item.CaliberId;
				m.DbId = item.MunitionId;
				m.Description = item.Description;
				m.Note = item.Note;
				list.Add(m);
			}


			return list;
		}
	}
}
