using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.BusinessObjects.Weapon;
using DataLayer.Entities.CodeList;
using PC_GUI.Models;
using PC_GUI.Models.CodeList;
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
		internal static SeriesModel SeriesBoToEventModel(SeriesBo bo)
		{
			var model = new SeriesModel();
			model.DbId = bo.DbId;
			model.Name = bo.Name;
			model.Description = bo.Description;
			model.Note = bo.Note;
			//model.Order = bo.
			return model;
		}

		internal static List<SeriesModel> EventBoListToSeriesModelList(List<SeriesBo> list)
		{
			var modelList = new List<SeriesModel>();
			foreach (var item in list)
			{
				var model = Mapper.SeriesBoToEventModel(item);
				modelList.Add(model);
			}

			return modelList;
		}

		internal static PlaceModel PlaceBoToPlaceModel(PlaceBo bo)
		{
			var model = new PlaceModel();
			
			model.DbId = bo.DbId;
			model.Name = bo.Name;
			model.Description = bo.Description;
			model.Note = bo.Note;
			//model.Order = bo.
			return model;
		}

		internal static PlaceBo PlaceModelToPlaceBo(PlaceModel item)
		{
			var bo = new PlaceBo();

			bo.DbId = item.DbId;
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


		private static MenuItemViewModel? findById(ObservableCollection<MenuItemViewModel> items, int id)
		{
			foreach (var item in items)
			{
				if (item.DbId == id)
					return item;

				var found = findById(item.Children, id);
				if (found != null)
					return found;
			}
			return null;
		}
	}
}
