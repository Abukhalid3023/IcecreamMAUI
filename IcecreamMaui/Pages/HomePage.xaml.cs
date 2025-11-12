
using IcecreamMaui.ViewModels;


namespace IcecreamMaui.Pages;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _homeViewModel;
	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		_homeViewModel = homeViewModel;
		BindingContext = _homeViewModel;
	}

	protected async override void OnAppearing()
	{
        base.OnAppearing();

        // Run initialization in the background so UI is not blocked
        _ = _homeViewModel.InitializeAsync();
    }
}