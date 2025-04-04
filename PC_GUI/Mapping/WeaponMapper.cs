using Avalonia;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using PC_GUI.Models.CodeList;
using PC_GUI.Models.Weapon;
using PC_GUI.ViewModels;
using PC_GUI.ViewModels.Weapon;
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

			internal static CSightsTypeModel CSightsTypeBoToCSightsTypeModel(CSightsTypeBo bo)
			{
				var model = new CSightsTypeModel();
				model.DbId = bo.DbId;
				model.Name = bo.Name;
				model.Description = bo.Description;
				return model;
			}

			internal static SightsModel SightsBoToSightsModel(SightsBo bo)
			{
				var model = new SightsModel();
				model.DbId = bo.DbId;
				model.Name = bo.Name;
				model.Description = bo.Description;
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

			internal static CaliberModel CCaliberBoToCCaliberModel(CaliberBo bo)
			{
				var model = new CaliberModel();
				model.DbId = bo.DbId;
				model.Name = bo.Name;
				model.Description = bo.Description;
				return model;
			}

			internal static CFiringModeModel CFiringModeBoToCFiringModeModel(CFiringModeBo bo)
			{
				var model = new CFiringModeModel();
				model.DbId = bo.DbId;
				model.Name = bo.Name;
				model.Description = bo.Description;
				return model;
			}


			internal static WeaponBo WeaponModelToWeaponBo()
			{

				return new WeaponBo();
			}

			internal static void UpdateWeaponViewModelByWeaponBo(WeaponNewViewModel model, WeaponBo bo)
			{

				//weapon mapping
				model.WeaponName = bo.WeaponName;
				model.ProfileName = bo.ProfileName;
				model.Description = bo.Description;
				//model..Note = bo.Note;
				model.SelectedCWeaponTypeMenuItem = findById(model.CWeaponTypeMenuItems, bo.CWeaponTypeCode);
				model.SelectedCPowerPrincipleMenuItem = findById(model.CPowerPrincipleMenuItems, bo.CPowerPrincipleCode);
				model.SelectedFiringMode = model.CFiringModelList.FirstOrDefault(x => x.DbId == bo.CFiringModeCode);

				model.SelectedCSightsType = model.CSightsTypeModelList.FirstOrDefault(x => x.DbId == bo.SightsBoList.FirstOrDefault().CSightsTypeId);
				model.SightsName = bo.SightsBoList.FirstOrDefault().Name;
				model.SightsDescription = bo.SightsBoList.FirstOrDefault().Description;
				model.SightsNote = bo.SightsBoList.FirstOrDefault().Note;
				model.IsExistingSightsSelected = false;
				model.IsNewSightsSelected = true;

				model.CaliberName = bo.CCaliberBoList.FirstOrDefault().Name;
				model.CaliberDescription = bo.CCaliberBoList.FirstOrDefault().Description;
				model.CaliberNote = bo.CCaliberBoList.FirstOrDefault().Note;
				model.IsExistingCaliberSelected = false;
				model.IsNewCaliberSelected = true;
				//MaintenanceIntervalShots = 

			}

		}

	}
}
