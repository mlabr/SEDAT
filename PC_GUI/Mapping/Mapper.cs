using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using DataLayer.Entities.CodeList;
using PC_GUI.Models;
using PC_GUI.Models.Weapon;
using PC_GUI.ViewModels;
using PC_GUI.ViewModels.Weapon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Mapping
{
	internal static partial class Mapper
	{

		
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


		private static MenuItemViewModel? FindById(ObservableCollection<MenuItemViewModel> items, int id)
		{
			foreach (var item in items)
			{
				if (item.DbId == id)
					return item;

				var found = FindById(item.Children, id);
				if (found != null)
					return found;
			}
			return null;
		}
	}
}
