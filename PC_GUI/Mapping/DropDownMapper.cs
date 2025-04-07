using Business.BusinessObjects.CodeList;
using PC_GUI.Models;
using PC_GUI.Models.CodeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Mapping
{
	internal static partial class Mapper
	{
		internal static class DropDown
		{
			internal static DropDownItemModel EventBoToEventDropDownModel(SeriesBo bo)
			{
				var model = new DropDownItemModel();
				model.DbId = bo.DbId;
				model.Name = bo.Name;
				model.Description = bo.Description;
				//model.Order = bo.
				return model;
			}

			internal static List<DropDownItemModel> EventBoListToEventDropDownModelList(List<SeriesBo> list)
			{
				var modelList = new List<DropDownItemModel>();
				foreach (var item in list)
				{
					var model = EventBoToEventDropDownModel(item);
					modelList.Add(model);
				}

				return modelList;
			}
		}
		

	}
}
