using PC_GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Helpers
{
	public static class MenuHelper
	{

		public static class Weapon
		{
			public static class OverView
			{
				public const string WeaponOverview = "WeaponOverviewView";
			}

			public static class New
			{
				public const string NewFullWeapon = "NewFullWeaponView";
			}

			
		}

		public static class Manage
		{
			public const string PlacesOverview = "PlacesOverView";

			public static class Weapon
			{
				public const string SightsOverview = "SightsOverView";
			}
		}

		public static class Settings
		{
			public static class CodeList
			{
				public const string CSightsOverview = "CSightsOverView";
			}
		}



		public static List<MenuItemViewModel> CreateNestedListFromFlatList(List<MenuItemViewModel> flatList)
		{

			var lookup = flatList.ToLookup(item => item.ParentDbId);

			return flatList
				.Where(item => item.DbId == item.ParentDbId)
				.Select(root => addChildrenToParent(root, lookup))
				.ToList();
		}


		private static MenuItemViewModel addChildrenToParent(MenuItemViewModel parent, ILookup<int, MenuItemViewModel> lookup)
		{
			parent.Children = new ObservableCollection<MenuItemViewModel>(
				lookup[parent.DbId]
				.Where(child => child.DbId != child.ParentDbId)
				.Select(child => addChildrenToParent(child, lookup))
				);
			return parent;
		}

	}
}
