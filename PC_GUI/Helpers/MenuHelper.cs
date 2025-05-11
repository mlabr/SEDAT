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
			public const string EventOverview = "EventOverview";
			public const string EventNew = "EventNew";
		}

		public static class Session
		{

			public const string SessionNew = "SessionNew";
			public const string SessionOverview = "SessionOverview";

		}

		public static class Weapon
		{

			public const string WeaponOverview = "WeaponOverview";
			public const string WeaponNew = "WeaponNew";

			public static class Sights
			{
				public const string Overview = "SightsOverview";
			}

			public static class Caliber
			{
				public const string Overview = "CaliberOverview";
				public const string New = "CaliberNew";
			}

		}

		public static class Manage
		{
			
			public const string TargetsOverview = "TargetsOverview";
			public const string CSightsOverview = "CSightsOverview";
			public const string CDisciplineOverview = "CDisciplineOverview";

			public static class Place
			{
				public const string Overview = "PlacesOverview";
			}

		}

		public static class Settings
		{
			public static class CodeList
			{
				public const string CSightsOverview = "CSightsOverview";
				
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
