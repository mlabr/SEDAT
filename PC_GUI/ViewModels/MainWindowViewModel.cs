using Business.Mapping;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Helpers;
using PC_GUI.ViewModels.CodeList;
using PC_GUI.ViewModels.CodeList.CDiscipline;
using PC_GUI.ViewModels.Place;
using PC_GUI.ViewModels.Series;
using PC_GUI.ViewModels.Session;
using PC_GUI.ViewModels.Target;
using PC_GUI.ViewModels.Weapon;
using System;

namespace PC_GUI.ViewModels
{
	public partial class MainWindowViewModel : ViewModelBase
	{
		[ObservableProperty]
		private bool _isPaneOpen = true;

		[ObservableProperty]
		public ViewModelBase _currentPage = new HomePageViewModel();

		[ObservableProperty]
		private string _contentString = "CONTENT";

		[ObservableProperty]
		private ListItemTemplate _selectedListItem;


		//public MainWindowViewModel(MapperService mapService)
		public MainWindowViewModel( )
		{

		}

		partial void OnSelectedListItemChanged(ListItemTemplate? value)
		{
			if (value is null) return;
			var instance = Activator.CreateInstance(value.ModelType);
			if (instance is null) return;

			CurrentPage = (ViewModelBase)instance;
		}

		//Takhle volat veskere menu, umre nejmene kotatek
		[RelayCommand]
		public void ChangeView(string value)
		{
			CurrentPage = value switch
			{
				MenuHelper.Event.EventOverview => new SeriesOverviewViewModel(this),
				MenuHelper.Session.SessionOverview => new SessionOverviewViewModel(this),
				MenuHelper.Session.SessionNew => new SessionNewViewModel(this),
				MenuHelper.Weapon.WeaponOverview => new WeaponOverviewViewModel(this),
				MenuHelper.Weapon.WeaponNew => new WeaponNewViewModel(this),
				MenuHelper.Manage.CSightsOverview => new CSightsOverviewViewModel(this),
				MenuHelper.Manage.CDisciplineOverview => new CDisciplineOverviewViewModel(this),
				MenuHelper.Manage.PlacesOverview => new PlaceOverviewViewModel(this),
				MenuHelper.Manage.TargetsOverview => new TargetOverviewViewModel(this),

				//"PlacesOverView" => new PlaceOverviewViewModel(this),
				_ => new HomePageViewModel()
			}; 
		}

		[RelayCommand]
		public void GoToPlaceOverview()
		{
			CurrentPage = new PlaceOverviewViewModel(this);
		}

		[RelayCommand]
		public void GoToMainWindow()
		{
			CurrentPage = new HomePageViewModel();
		}

		[RelayCommand]
		public async void OpenInfoDialog()
		{
			var message = "SEDAT - Shooter's Electronic Data Analysis Tool" +
				"\nVersion 0.0.1";
			var isActionConfirmed = await OpenInfoDialogAsync("Info", message);
			if (isActionConfirmed)
			{

			}
		}

	}

	public class ListItemTemplate
	{
		public ListItemTemplate(Type type, string name)
		{
			ModelType = type;
			//Label = type.Name.Replace("PageViewModel", "");
			Label = name;
		}

		public string Label { get; set; }
		public Type ModelType { get; set; }		
    }


}
