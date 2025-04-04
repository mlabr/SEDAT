using PC_GUI.ViewModels;
using PC_GUI.ViewModels.Weapon;
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
		public static class Event
		{
			public const string EventOverview = "EventOverviewView";
			public const string EventNew = "EventNewView";
		}

		public static class Session
		{

			public const string SessionNew = "SessionNewView";

		}

		public static class Weapon
		{

			public const string WeaponOverview = "WeaponOverviewView";
			public const string WeaponNew = "WeaponNewView";
			
		}

		public static class Manage
		{
			public const string PlacesOverview = "PlacesOverView";
			public const string TargetsOverView = "TargetsOverView";
			public const string CSightsOverview = "CSightsOverView";

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
