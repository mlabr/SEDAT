using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using DataLayer.Entities.CodeList;
using PC_GUI.Models;
using PC_GUI.Models.Weapon;
using PC_GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Mapping
{
	internal static class Mapper
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

		internal static PlaceModel PlaceBoToPlaceModel(PlaceBo bo)
		{
			var model = new PlaceModel();
			
			model.DbId = bo.PlaceId;
			model.Name = bo.Name;
			model.Description = bo.Description;
			model.Note = bo.Note;
			//model.Order = bo.
			return model;
		}

		internal static PlaceBo PlaceModelToPlaceBo(PlaceModel item)
		{
			var bo = new PlaceBo();

			bo.PlaceId = item.DbId;
			bo.Name = item.Name;
			bo.Description = item.Description;
			bo.Note = item.Note;
			//model.Order = bo.
			return bo;
		}


		internal static List<PlaceModel> PlaceBoListToPlaceModelList(List<PlaceBo> list)
		{
			var listModel = new List<PlaceModel>();
			var i = 1;
			foreach (var bo in list)
			{
				var item = PlaceBoToPlaceModel(bo);
				item.Order = i;
				i++;
				listModel.Add(item);
			}

			return listModel;

		}

		internal static List<MenuItemViewModel> PersonBoListToMenuItemViewModelList(List<PersonBo> list)
		{
			var listModel = new List<MenuItemViewModel>();
			foreach (var bo in list)
			{
				var model = PersonBoToMenuItemViewModel(bo);
				listModel.Add(model);
			}
			return listModel;
		}

		internal static MenuItemViewModel PersonBoToMenuItemViewModel(PersonBo bo)
		{
			var desc = bo.FirstName + " " + bo.LastName;
			var item = new MenuItemViewModel(bo.NickName, desc);
			item.DbId = bo.Id;
			return item;
		}

	}
}
