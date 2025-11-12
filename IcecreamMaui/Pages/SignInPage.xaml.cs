using IcecreamMaui.ViewModels;
using System.Threading.Tasks;

namespace IcecreamMaui.Pages;

public partial class SignInPage : ContentPage
{
	public SignInPage(AuthViewModel authViewModel)
        
	{
		InitializeComponent();
        BindingContext = authViewModel;
	}

    private async void SignupLabel_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }
}






