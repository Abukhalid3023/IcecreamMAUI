using IcecreamMaui.ViewModels;

namespace IcecreamMaui.Pages;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(AuthViewModel authviewmodel)
	{
		InitializeComponent();
		BindingContext =authviewmodel;
	}

    private async void SigninLabel_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(SignInPage));
    }
}