using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PC_GUI.ViewModels
{
	public class MenuItemViewModel
	{

		public string Name { get; set; }

		public string Description { get; set; }

		public ObservableCollection<MenuItemViewModel> Children { get; set; }

		public int DbId { get; set; }

		public int ParentDbId { get; set; }

		public MenuItemViewModel(string name, string description)
		{
			Name = name;
			Description = description;
			Children = new ObservableCollection<MenuItemViewModel>();
		}

		public ICommand? Command { get; set; }
		public object? CommandParameter { get; set; }


	}
}
