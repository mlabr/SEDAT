using Business.BusinessObjects;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers
{
	public class TargetHandler
	{

		public TargetHandler()
		{

		}
		public List<TargetBo> GetAllList()
		{
			var repo = new TargetRepository();
			var tList = new List<TargetBo>();
			var list = repo.GetUsedAllList();
			foreach (var item in list)
			{
				var t = new TargetBo();
				t.DbId = item.TargetId;
				t.Name = item.Name;
				t.Description = item.Description;
				t.Note = item.Note;
				tList.Add(t);
			}
			return tList;
		}

		public List<TargetBo> GetUsedOnlyList()
		{
			var repo = new TargetRepository();
			var tList = new List<TargetBo>();
			var list = repo.GetUsedOnlyList();
			foreach (var item in list)
			{
				var t = new TargetBo();
				t.DbId = item.TargetId;
				t.Name = item.Name;
				t.Description = item.Description;
				t.Note = item.Note;
				tList.Add(t);
			}
			return tList;
		}
	}
}
