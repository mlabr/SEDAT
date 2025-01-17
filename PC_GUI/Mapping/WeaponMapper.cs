using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using PC_GUI.Models.Weapon;
using PC_GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Mapping
{
	internal static partial class Mapper
	{
		internal static class Weapon
		{
			internal static MenuItemViewModel CPowerPrincipleBoToMenuItemModel(CPowerPrincipleBo bo)
			{
				var model = new MenuItemViewModel(bo.Name, bo.Description);
				model.DbId = bo.DbId;
				model.ParentDbId = bo.ParentDbId;

				return model;
			}

			internal static List<MenuItemViewModel> CPowerPrincipleBoListToMenuItemViewModelList(List<CPowerPrincipleBo> list)
			{
				var listModel = new List<MenuItemViewModel>();
				foreach (var bo in list)
				{
					var model = CPowerPrincipleBoToMenuItemModel(bo);
					listModel.Add(model);
				}

				return listModel;
			}

			internal static CPowerPrincipleModel CPowerPrincipleBoToCPowerPrincipleModel(CPowerPrincipleBo bo)
			{
				var model = new CPowerPrincipleModel();
				model.DbId = bo.DbId;
				model.Name = bo.Name;
				model.Description = bo.Description;
				model.Note = bo.Note;
				model.ParentDbId = bo.ParentDbId;

				return model;
			}

			internal static MenuItemViewModel CWeaponTypeBoToMenuItemViewModel(CWeaponTypeBo bo)
			{
				var model = new MenuItemViewModel(bo.Name, bo.Description);
				model.DbId = bo.DbId;
				model.ParentDbId = bo.ParentDbId;

				return model;
			}

			internal static List<MenuItemViewModel> CWeaponTypeBoListToMenuItemViewModelList(List<CWeaponTypeBo> list)
			{
				var listModel = new List<MenuItemViewModel>();
				foreach (var bo in list)
				{
					var model = CWeaponTypeBoToMenuItemViewModel(bo);
					listModel.Add(model);
				}
				return listModel;
			}


			internal static MenuItemViewModel CFiringModeBoToMenuItemViewModel(CFiringModeBo bo)
			{
				var model = new MenuItemViewModel(bo.Name, bo.Description);
				model.DbId = bo.DbId;
				model.ParentDbId = bo.DbId;

				return model;
			}


			internal static WeaponBo WeaponModelToWeaponBo()
			{

				return new WeaponBo();
			}

		}

	}
}
