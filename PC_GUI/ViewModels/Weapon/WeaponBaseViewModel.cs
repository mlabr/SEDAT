using CommunityToolkit.Mvvm.ComponentModel;
using PC_GUI.Models.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.ViewModels.Weapon
{
	internal partial class WeaponBaseViewModel : ViewModelBase
	{
		[ObservableProperty]
		internal CCaliberModel _selectedCaliber;
	}
}
