using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PC_GUI.Models;


namespace PC_GUI.ViewModels
{
	internal partial class View2ViewModel : ViewModelBase
	{
		//[ObservableProperty]
		public WeaponModel Weapon { get; set; }


		[ObservableProperty]
		private string _contentString = "Content";

		[ObservableProperty]
		private int _messageRowHeight=0;

		public View2ViewModel()
        {
			//ContentString = "Default content";

			Weapon = new WeaponModel()
			{
				Id = 1,
				Name = "Moje Puska",
				Identification= "Puska"
			};
        }


  //      [ObservableProperty]
		//private string _weaponName = "";

		[RelayCommand]
		private void ButtonOnClick()
		{
			ContentString = "Changed";
			MessageRowHeight = 20;

		//IsPaneOpen = !IsPaneOpen;
		}



}
}

