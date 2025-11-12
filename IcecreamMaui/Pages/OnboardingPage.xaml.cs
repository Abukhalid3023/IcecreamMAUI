using IcecreamMaui.Services;

namespace IcecreamMaui.Pages;

public partial class OnboardingPage : ContentPage
{
    private readonly AuthService _authService;
	public OnboardingPage(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;
	}

    protected async override void OnAppearing()
    {
        if(_authService.User is not null && _authService.User.Id != default
            && !string.IsNullOrWhiteSpace(_authService.Token))
        {
            //user is loggeg in 
            //Navigate user to HomePage
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }

    private async void Signin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignInPage));
    }

    private async void Signup_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }
}